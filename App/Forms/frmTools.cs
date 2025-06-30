namespace MOM.Forms
{
	public partial class frmTools : Form
	{
		public frmTools()
		{
			InitializeComponent();
		}

		private async void btnCopyHash_Click(object sender, EventArgs e)
		{
			byte[] salt = SecurityHelper.GenerateSalt();
			byte[] hash = await SecurityHelper.HashPasswordAsync(tbPassword.Text, salt);
			string encoded = SecurityHelper.Encode(salt, hash);
			Clipboard.SetText(encoded);
		}
	}
}
