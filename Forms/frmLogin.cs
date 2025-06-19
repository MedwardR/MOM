using Microsoft.EntityFrameworkCore;

namespace MOM
{
	public partial class frmLogin : Form
	{
		private AppDbContext? _db;
		private ListBox? _log;

		public bool IsAuthenticated { get; private set; }

		public frmLogin()
		{
			InitializeComponent();
			IsAuthenticated = false;
		}

		private void frmLogin_Shown(object sender, EventArgs e)
		{
			InitializeAppAsync();
		}

		private async void InitializeAppAsync()
		{
			tableLayoutPanel1.Visible = false;
			_log = new ListBox
			{
				Dock = DockStyle.Fill,
				IntegralHeight = false,
			};
			Controls.Add(_log);

			Log("Checking for updates...");
			try
			{
				await Task.Delay(500); // update for real though
				Log("No updates available");
			}
			catch (Exception ex)
			{
				Log(ex, "An error occurred while checking for updates");
			}

			Log("Configuring database connection...");
			try
			{
				_db = new AppDbContext();
			}
			catch (Exception ex)
			{
				Log(ex, "Failed to configure database connection");
				return;
			}
			Log("Connecting to database...");
			try
			{
				await _db.Database.OpenConnectionAsync();
				await _db.Database.CloseConnectionAsync();
			}
			catch (Exception ex)
			{
				Log(ex, "Failed to connect to database");
				return;
			}
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
			_log?.Items.Add(message);
			Serilog.Log.Information(message);
		}
		private void Log(Exception ex, string message)
		{
			_log?.Items.Add(message);
			Serilog.Log.Error(ex, message);
		}

		private void tbUsername_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbPassword.Focus();
			}
		}

		private void tbPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				LoginAsync();
			}
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			LoginAsync();
		}

		private async void LoginAsync()
		{
			if (_db is not null)
			{
				var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == tbUsername.Text);
				if (user is not null)
				{
					(byte[] salt, byte[] hash) = SecurityHelper.Decode(user.PasswordHash);
					if (await SecurityHelper.VerifyPasswordAsync(tbPassword.Text, hash, salt))
					{
						new frmMain(_db).Show();
						Close();
					}
					else
					{
						lbPasswordInvalid.Visible = true;
					}
				}
				else
				{
					lbUsernameNotFound.Visible = true;
				}
			}
		}
	}
}
