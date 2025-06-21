using Serilog;

namespace MOM
{
	public partial class frmMain : Form
	{
		private readonly AppDbContext _db;

		public frmMain()
		{
			Hide();
			var frm = new frmLogin();
			frm.ShowDialog();

			if (frm.DbContext is not null)
			{
				_db = frm.DbContext;
				InitializeComponent();
				Show();
			}
			else
			{
				Log.Information("Application close" + Environment.NewLine);
				Log.CloseAndFlush();
				Environment.Exit(0);
			}
		}
	}
}
