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

			if (frm.IsAuthenticated)
			{
				InitializeComponent();
				Show();
			}
			else Application.Exit();
		}
	}
}
