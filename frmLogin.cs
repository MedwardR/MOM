using Microsoft.EntityFrameworkCore;

namespace MOM
{
	public partial class frmLogin : Form
	{
		public frmLogin()
		{
			InitializeComponent();
			InitializeAppAsync();
		}

		private async void InitializeAppAsync()
		{
			tableLayoutPanel1.Visible = false;
			using var log = new ListBox
			{
				Dock = DockStyle.Fill,
				IntegralHeight = false,
			};
			Controls.Add(log);

			void Log(string message, bool error = false)
			{
				log.Items.Add(message);
				if (error) Serilog.Log.Error(message);
				else Serilog.Log.Information(message);
			};

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

			Log("Connecting to database...");
			var db = AppDbContext.CreateAutomatically();
			try
			{
				await db.Database.OpenConnectionAsync();
				Log("Successfully connected to database");
				await db.Database.CloseConnectionAsync();
			}
			catch (Exception ex)
			{
				Log("Failed to connect to database: " + ex.Message, true);
				return;
			}



			Controls.Remove(log);
		}
	}
}
