namespace MOM
{
	public partial class frmMain : Form
	{
		private readonly AppDbContext _db;

		public frmMain(AppDbContext db)
		{
			InitializeComponent();
			_db = db;
		}
	}
}
