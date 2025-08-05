using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;

namespace MOM
{
	public partial class frmLogin : Form
	{
		private AppDbContext? _db;
		private ListBox? _log;

		public DataManager? DataManager { get; private set; }

		public frmLogin()
		{
			InitializeComponent();
		}

		private async void frmLogin_Shown(object sender, EventArgs e)
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

			Log("Configuring database connection");
			_db = new AppDbContext();

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
					Log("Updating application");
					await UpdateApplicationAsync(downloadUrl);
				}
			}

			Log("Updating database");
			await _db.Database.MigrateAsync();

			Controls.Remove(_log);
			_log.Dispose();
			_log = null;
			tableLayoutPanel1.Visible = true;
		}

		private async Task<(Version version, string downloadUrl)> GetLatestVersionAsync()
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

		private async Task UpdateApplicationAsync(string downloadUrl)
		{
			using var client = new HttpClient();
			var data = await client.GetByteArrayAsync(downloadUrl);

			string filePath = Path.Combine(Path.GetTempPath(), "MOMInstaller.exe");
			await File.WriteAllBytesAsync(filePath, data);

			Process.Start(new ProcessStartInfo
			{
				FileName = filePath,
				Arguments = "/silent",
				UseShellExecute = true,
			});
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
				tbPassword.Focus();
			}
			lbUsernameNotFound.Visible = false;
			lbPasswordInvalid.Visible = false;
		}

		private void tbPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				LoginAsync();
			}
			lbPasswordInvalid.Visible = false;
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			LoginAsync();
		}

		private async void LoginAsync()
		{
			if (_db is not null)
			{
				btnLogin.Enabled = false;

				string username = tbUsername.Text.Trim();
				string password = tbPassword.Text;

				var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
				if (user is not null)
				{
					Log($"Attempting to log in as '{user.Username}' ({user.Id})");

					(byte[] salt, byte[] hash) = SecurityHelper.Decode(user.PasswordHash);
					if (await SecurityHelper.VerifyPasswordAsync(password, hash, salt))
					{
						user.IsLoggedIn = true;
						await _db.SaveChangesAsync();

						DataManager = new(_db, user);
						Log($"Logged in as '{user.Username}' ({user.Id})");
						Close();
					}
					else
					{
						Log("Invalid password");
						lbPasswordInvalid.Visible = true;
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
}
