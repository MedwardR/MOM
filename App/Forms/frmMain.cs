using Serilog;

namespace MOM
{
	public partial class frmMain : Form
	{
		private readonly AppContext _app;

		public frmMain()
		{
			try
			{
				var frm = new frmLogin();
				frm.ShowDialog();

				if (frm.AppContext is not null)
				{
					_app = frm.AppContext;
					InitializeComponent();
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
			if (_app is not null)
			{
				if (_app.AuthenticatedUser is not null)
				{
					_app.AuthenticatedUser.IsLoggedIn = false;
					_app.SaveChanges();
				}
			}
		}
	}
}
