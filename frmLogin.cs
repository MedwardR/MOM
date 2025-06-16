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

			Log("Checking for updates...");
			try
			{
				await Task.Delay(500); // update for real though
				Log("No updates available");
			}
			catch (Exception ex)
			{
				Log("An error occurred while checking for updates: " + ex.Message, true);
			}

			var connectionStringBuilder = new Npgsql.NpgsqlConnectionStringBuilder
			{
				Database = "mom",
			};
			if (Program.IsDevelopmentEnvironment)
			{
				connectionStringBuilder.Port = 5432;
				connectionStringBuilder.Host = "localhost";
				connectionStringBuilder.Username = "postgres";
				connectionStringBuilder.Password = "postgres";
			}
			else
			{
				// use real server
			}
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			string connectionString = connectionStringBuilder.ToString();
			optionsBuilder.UseNpgsql(connectionString);
			_db = new AppDbContext(optionsBuilder.Options);

			Log("Connecting to database...");
			try
			{
				await _db.Database.OpenConnectionAsync();
				Log("Successfully connected to database");
				await _db.Database.CloseConnectionAsync();
			}
			catch (Exception ex)
			{
				Log("Failed to connect to database: " + ex.Message, true);
				return;
			}

			Controls.Remove(_log);
			_log.Dispose();
			_log = null;
			tableLayoutPanel1.Visible = true;
		}

		private void Log(string message, bool error = false)
		{
			_log?.Items.Add(message);
			if (error) Serilog.Log.Error(message);
			else Serilog.Log.Information(message);
		}
	}
}
