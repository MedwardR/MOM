using Microsoft.EntityFrameworkCore;
using MOM.Helpers;
using MOM.Services;
using System.Diagnostics;
using System.Text.Json;

namespace MOM.Forms;

public sealed partial class frmLogin : Form
{
	private AppContextFactory? _factory;
	private ListBox? _log;

	public AppContextFactory? ContextFactory { get; private set; }

	public frmLogin()
	{
		InitializeComponent();
		Text += Program.Version;
	}

	private async void frmLogin_Shown(object sender, EventArgs e)
	{
		try
		{
			tableLayoutPanel1.Visible = false;
			_log = new ListBox
			{
				Dock = DockStyle.Fill,
				IntegralHeight = false,
				BorderStyle = BorderStyle.None,
				BackColor = BackColor
			};
			Controls.Add(_log);
			_log.Focus();

			Log("Loading user settings");
			var settings = await UserSettings.LoadAsync();

			Log("Configuring database connection");
			_factory = new AppContextFactory(settings);

			Log("Checking for updates");
			Version? latestVersion = null;
			string? downloadUrl = null;
			try
			{
				(latestVersion, downloadUrl) = await GetLatestVersionAsync();
			}
			catch (Exception ex)
			{
				Log(ex, "An error occurred while checking for updates");
			}

			if (latestVersion is not null && downloadUrl is not null)
			{
				if (latestVersion > Program.Version)
				{
					var choice = MessageBox.Show(
						"An update is available. Is now a good time to update the program?", "Update available",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question
					);
					if (choice == DialogResult.Yes)
					{
						Log("Updating application");
						await UpdateApplicationAsync(downloadUrl);
					}
					else Log("Update cancelled by user");
				}
				else Log("No updates available");
			}

			Log("Updating database");
			using var context = _factory.CreateAnonymousContext();
			await context.Database.MigrateAsync();

			await tbUsername.SetSuggestionsWhereActiveAsync(context.Users, u => u.Username);

			Controls.Remove(_log);
			_log.Dispose();
			_log = null;
			tableLayoutPanel1.Visible = true;
			await Task.Delay(100);
			tbUsername.Focus();
		}
		catch (Exception ex)
		{
			Application.OnThreadException(ex);
		}
	}

	private static async Task<(Version version, string downloadUrl)> GetLatestVersionAsync()
	{
		using var client = new HttpClient();
		client.DefaultRequestHeaders.UserAgent.ParseAdd("MOM");

		string response = await client.GetStringAsync("https://api.github.com/repos/MedwardR/MOM/releases/latest");

		using var doc = JsonDocument.Parse(response);
		string? versionString = doc.RootElement.GetProperty("tag_name").GetString()?.TrimStart('v');
		if (versionString is not null)
		{
			var version = Version.Parse(versionString);
			string? downloadUrl = null;

			var assets = doc.RootElement.GetProperty("assets");
			foreach (var asset in assets.EnumerateArray())
			{
				string name = asset.GetProperty("name").GetString() ?? string.Empty;
				if (name.EndsWith(".exe"))
				{
					string? url = asset.GetProperty("browser_download_url").GetString();
					if (url is not null)
					{
						downloadUrl = url;
						break;
					}
				}
			}

			if (downloadUrl is not null)
			{
				return (version, downloadUrl);
			}
			else throw new Exception("The latest version did not link to an installer");
		}
		else throw new Exception("The latest version could not be found");
	}

	private static async Task UpdateApplicationAsync(string downloadUrl)
	{
		using var client = new HttpClient();
		byte[] data = await client.GetByteArrayAsync(downloadUrl);

		string filePath = Path.Combine(Path.GetTempPath(), "MOMInstaller.exe");
		await File.WriteAllBytesAsync(filePath, data);

		Process.Start(new ProcessStartInfo
		{
			FileName = filePath,
			Arguments = "/silent",
			UseShellExecute = true,
		});
		Program.CloseLogger();
		Environment.Exit(0);
	}

	private void Log(string message)
	{
		if (_log is not null)
		{
			_log.Items.Add(message);
			_log.SelectedIndex = _log.Items.Count - 1;
		}
		Serilog.Log.Information(message);
	}
	private void Log(Exception ex, string message)
	{
		if (_log is not null)
		{
			_log.Items.Add(message);
			_log.SelectedIndex = _log.Items.Count - 1;
		}
		Serilog.Log.Error(ex, message);
	}

	private void tbUsername_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Enter)
		{
			if (!string.IsNullOrWhiteSpace(tbUsername.Text))
			{
				tbPassword.Focus();
			}
		}
		else
		{
			lbUsernameNotFound.Visible = false;
			lbPasswordInvalid.Visible = false;
		}
	}

	private async void tbPassword_KeyDown(object sender, KeyEventArgs e)
	{
		try
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (!string.IsNullOrWhiteSpace(tbUsername.Text))
				{
					if (!string.IsNullOrWhiteSpace(tbPassword.Text))
					{
						await LoginAsync();
					}
				}
				else tbUsername.Focus();
			}
			else lbPasswordInvalid.Visible = false;
		}
		catch (Exception ex)
		{
			Application.OnThreadException(ex);
		}
	}

	private async void btnLogin_Click(object sender, EventArgs e)
	{
		try
		{
			await LoginAsync();
		}
		catch (Exception ex)
		{
			Application.OnThreadException(ex);
		}
	}

	private async Task LoginAsync()
	{
		if (_factory is not null)
		{
			btnLogin.Enabled = false;

			string username = tbUsername.Text.Trim();
			string password = tbPassword.Text;

			using var context = _factory.CreateAnonymousContext();
			var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);
			if (user is not null)
			{
				Log($"Attempting to log in as '{user.Username}' ({user.Id})");

				(byte[] salt, byte[] hash) = SecurityHelper.Decode(user.PasswordHash);
				if (await SecurityHelper.VerifyPasswordAsync(password, hash, salt))
				{
					_factory.AssignAuthenticatedUser(user);
					context.AssignAuthenticatedUser(user);

					user.IsLoggedIn = true;
					await context.SaveChangesAsync();

					ContextFactory = _factory;
					Log($"Logged in as '{user.Username}' ({user.Id})");
					Close();
				}
				else
				{
					Log("Invalid password");
					lbPasswordInvalid.Visible = true;
					tbPassword.Text = string.Empty;
					tbPassword.Focus();
				}
			}
			else
			{
				Log($"User does not exist: '{username}'");
				lbUsernameNotFound.Visible = true;
				tbUsername.Focus();
			}

			btnLogin.Enabled = true;
		}
		else throw new Exception("Attempted to log in before database was initialized");
	}
}
