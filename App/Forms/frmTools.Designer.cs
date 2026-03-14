namespace MOM.Forms
{
	partial class frmTools
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTools));
			groupBox1 = new GroupBox();
			btnCopyEncrypted = new Button();
			btnCopyHash = new Button();
			tbPassword = new TextBox();
			groupBox2 = new GroupBox();
			btnLoadSettings = new Button();
			btnSaveSettings = new Button();
			pgSettings = new PropertyGrid();
			groupBox3 = new GroupBox();
			btnDecryptBackup = new Button();
			btnCreateBackup = new Button();
			tbBackupPath = new TextBox();
			label1 = new Label();
			label2 = new Label();
			tbDecryptDestination = new TextBox();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(btnCopyEncrypted);
			groupBox1.Controls.Add(btnCopyHash);
			groupBox1.Controls.Add(tbPassword);
			groupBox1.Location = new Point(12, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(228, 95);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Password tools";
			// 
			// btnCopyEncrypted
			// 
			btnCopyEncrypted.Location = new Point(98, 59);
			btnCopyEncrypted.Name = "btnCopyEncrypted";
			btnCopyEncrypted.Size = new Size(124, 30);
			btnCopyEncrypted.TabIndex = 1;
			btnCopyEncrypted.Text = "Copy encrypted";
			btnCopyEncrypted.UseVisualStyleBackColor = true;
			btnCopyEncrypted.Click += btnCopyEncrypted_Click;
			// 
			// btnCopyHash
			// 
			btnCopyHash.Location = new Point(6, 59);
			btnCopyHash.Name = "btnCopyHash";
			btnCopyHash.Size = new Size(86, 30);
			btnCopyHash.TabIndex = 1;
			btnCopyHash.Text = "Copy hash";
			btnCopyHash.UseVisualStyleBackColor = true;
			btnCopyHash.Click += btnCopyHash_Click;
			// 
			// tbPassword
			// 
			tbPassword.Location = new Point(6, 26);
			tbPassword.Name = "tbPassword";
			tbPassword.PasswordChar = '*';
			tbPassword.Size = new Size(216, 27);
			tbPassword.TabIndex = 0;
			// 
			// groupBox2
			// 
			groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			groupBox2.Controls.Add(btnLoadSettings);
			groupBox2.Controls.Add(btnSaveSettings);
			groupBox2.Controls.Add(pgSettings);
			groupBox2.Location = new Point(246, 12);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(420, 373);
			groupBox2.TabIndex = 2;
			groupBox2.TabStop = false;
			groupBox2.Text = "User settings";
			// 
			// btnLoadSettings
			// 
			btnLoadSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnLoadSettings.Location = new Point(124, 337);
			btnLoadSettings.Name = "btnLoadSettings";
			btnLoadSettings.Size = new Size(142, 30);
			btnLoadSettings.TabIndex = 3;
			btnLoadSettings.Text = "Load";
			btnLoadSettings.UseVisualStyleBackColor = true;
			btnLoadSettings.Click += btnLoadSettings_Click;
			// 
			// btnSaveSettings
			// 
			btnSaveSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnSaveSettings.Enabled = false;
			btnSaveSettings.Location = new Point(272, 337);
			btnSaveSettings.Name = "btnSaveSettings";
			btnSaveSettings.Size = new Size(142, 30);
			btnSaveSettings.TabIndex = 2;
			btnSaveSettings.Text = "Save";
			btnSaveSettings.UseVisualStyleBackColor = true;
			btnSaveSettings.Click += btnSaveSettings_Click;
			// 
			// pgSettings
			// 
			pgSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			pgSettings.Location = new Point(6, 26);
			pgSettings.Name = "pgSettings";
			pgSettings.PropertySort = PropertySort.NoSort;
			pgSettings.Size = new Size(408, 305);
			pgSettings.TabIndex = 0;
			// 
			// groupBox3
			// 
			groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			groupBox3.Controls.Add(tbDecryptDestination);
			groupBox3.Controls.Add(label2);
			groupBox3.Controls.Add(label1);
			groupBox3.Controls.Add(btnDecryptBackup);
			groupBox3.Controls.Add(btnCreateBackup);
			groupBox3.Controls.Add(tbBackupPath);
			groupBox3.Location = new Point(12, 113);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(228, 272);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "Backup tools";
			// 
			// btnDecryptBackup
			// 
			btnDecryptBackup.Location = new Point(6, 178);
			btnDecryptBackup.Name = "btnDecryptBackup";
			btnDecryptBackup.Size = new Size(216, 30);
			btnDecryptBackup.TabIndex = 1;
			btnDecryptBackup.Text = "Decrypt backup";
			btnDecryptBackup.UseVisualStyleBackColor = true;
			// 
			// btnCreateBackup
			// 
			btnCreateBackup.Location = new Point(6, 24);
			btnCreateBackup.Name = "btnCreateBackup";
			btnCreateBackup.Size = new Size(216, 30);
			btnCreateBackup.TabIndex = 1;
			btnCreateBackup.Text = "Create backup";
			btnCreateBackup.UseVisualStyleBackColor = true;
			btnCreateBackup.Click += btnCreateBackup_Click;
			// 
			// tbBackupPath
			// 
			tbBackupPath.Location = new Point(6, 92);
			tbBackupPath.Name = "tbBackupPath";
			tbBackupPath.PasswordChar = '*';
			tbBackupPath.Size = new Size(216, 27);
			tbBackupPath.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(6, 69);
			label1.Name = "label1";
			label1.Size = new Size(91, 20);
			label1.TabIndex = 2;
			label1.Text = "Backup path";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(6, 122);
			label2.Name = "label2";
			label2.Size = new Size(85, 20);
			label2.TabIndex = 3;
			label2.Text = "Destination";
			// 
			// tbDecryptDestination
			// 
			tbDecryptDestination.Location = new Point(6, 145);
			tbDecryptDestination.Name = "tbDecryptDestination";
			tbDecryptDestination.PasswordChar = '*';
			tbDecryptDestination.Size = new Size(216, 27);
			tbDecryptDestination.TabIndex = 4;
			// 
			// frmTools
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(678, 397);
			Controls.Add(groupBox3);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Font = new Font("Segoe UI", 11F);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "frmTools";
			Text = "Tools";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBox1;
		private TextBox tbPassword;
		private Button btnCopyHash;
		private Button btnCopyEncrypted;
		private GroupBox groupBox2;
		private Button btnSaveSettings;
		private PropertyGrid pgSettings;
		private Button btnLoadSettings;
		private GroupBox groupBox3;
		private Button btnDecryptBackup;
		private Button btnCreateBackup;
		private TextBox tbBackupPath;
		private Label label1;
		private Label label2;
		private TextBox tbDecryptDestination;
	}
}