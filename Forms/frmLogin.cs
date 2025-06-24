using Microsoft.EntityFrameworkCore;

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

			Log("Checking for updates");
			try
			{
				await Task.Delay(500); // update for real though
			}
			catch (Exception ex)
			{
				Log(ex, "An error occurred while checking for updates");
			}

			Log("Configuring database connection");
			_db = new AppDbContext();

			Log("Connecting to database");
			await _db.Database.OpenConnectionAsync();
			await _db.Database.CloseConnectionAsync();

			Log("Updating database...");
			try
			{
				await _db.Database.MigrateAsync();
			}
			catch (Exception ex)
			{
				Log(ex, "Failed to update database");
				return;
			}

			Controls.Remove(_log);
			_log.Dispose();
			_log = null;
			tableLayoutPanel1.Visible = true;
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
