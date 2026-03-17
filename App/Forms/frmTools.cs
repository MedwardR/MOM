using Microsoft.VisualBasic;
using MOM.Helpers;
using System.Runtime;
using System.Threading.Tasks;

namespace MOM.Forms;

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

	private async void btnCreateBackup_Click(object sender, EventArgs e)
	{
		btnCreateBackup.Enabled = false;
		string temp = Path.GetTempFileName();
		try
		{
			if (pgSettings.SelectedObject is UserSettings settings)
			{
				string path = BackupHelper.GetBackupDestination(settings);
				string password = SecurityHelper.Decrypt(settings.BackupPassword);

				await BackupHelper.BackupAsync(settings, temp, default);
				await BackupHelper.EncryptAsync(temp, path, password);

				MessageBox.Show("Backup successful");
			}
			else MessageBox.Show("Settings must be loaded to create a backup");
		}
		finally
		{
			if (File.Exists(temp))
			{
				File.Delete(temp);
			}
			btnCreateBackup.Enabled = true;
		}
	}

	private async void btnDecryptBackup_Click(object sender, EventArgs e)
	{
		btnDecryptBackup.Enabled = false;
		try
		{
			if (pgSettings.SelectedObject is UserSettings settings)
			{
				string backupPath = tbBackupPath.Text.Trim('"');
				string directory = Path.GetDirectoryName(backupPath)!;
				string fileName = Path.GetFileNameWithoutExtension(backupPath);
				string destination = Path.Combine(directory, fileName);
				string password = SecurityHelper.Decrypt(settings.BackupPassword);

				if (!File.Exists(destination))
				{
					await BackupHelper.DecryptAsync(backupPath, destination, password);
				}
				else MessageBox.Show($"Destination file already exists: {destination}");
			}
			else MessageBox.Show("Settings must be loaded to decrypt a backup");
		}
		finally
		{
			btnDecryptBackup.Enabled = true;
		}
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