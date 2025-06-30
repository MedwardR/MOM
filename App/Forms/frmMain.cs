using Serilog;

namespace MOM
{
	public partial class frmMain : Form
	{
		private readonly DataManager _dm;

		public frmMain()
		{
			try
			{
				var frm = new frmLogin();
				frm.ShowDialog();

				if (frm.DataManager is not null)
				{
					_dm = frm.DataManager;
					InitializeComponent();
					throw new Exception("Bork");
				}
				else
				{
					Log.Information("Application closed before logging in" + Environment.NewLine);
					Program.CloseLogger();
					Environment.Exit(0);
				}
			}
			catch
			{
				LogOut();
				throw;
			}
		}

		public void LogOut()
		{
			if (_dm is not null)
			{
				_dm.AuthenticatedUser.IsLoggedIn = false;
				_dm.DbContext.SaveChanges();
			}
		}
	}
}
