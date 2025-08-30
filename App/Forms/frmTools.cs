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

		private void btnCopyEncrypted_Click(object sender, EventArgs e)
		{
			string encrypted = SecurityHelper.Encrypt(tbPassword.Text);
			Clipboard.SetText(encrypted);
		}

		private async void btnLoadSettings_Click(object sender, EventArgs e)
		{
			btnLoadSettings.Enabled = false;
			try
			{
				var settings = await UserSettings.LoadAsync();
				pgSettings.SelectedObject = settings;
				btnSaveSettings.Enabled = true;
			}
			finally
			{
				btnLoadSettings.Enabled = true;
			}
		}

		private async void btnSaveSettings_Click(object sender, EventArgs e)
		{
			if (pgSettings.SelectedObject is UserSettings settings)
			{
				btnSaveSettings.Enabled = false;
				try
				{
					await settings.SaveAsync();
				}
				finally
				{
					btnSaveSettings.Enabled = true;
				}
			}
		}
	}
}
