using Microsoft.EntityFrameworkCore;

namespace MOM
{
	public partial class frmLogin : Form
	{
		private AppDbContext? _db;
		private ListBox? _log;

		public frmLogin()
		{
			InitializeComponent();
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

			await UpdateProgramAsync();

			await InitializeAndUpdateDatabaseAsync();

			Controls.Remove(_log);
			_log.Dispose();
			_log = null;
			tableLayoutPanel1.Visible = true;
		}

		private async Task UpdateProgramAsync()
		{
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
		}

		private async Task InitializeAndUpdateDatabaseAsync()
		{
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
	}
}
