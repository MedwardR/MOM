namespace MOM
{
	partial class frmLogin
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
			tableLayoutPanel1 = new TableLayoutPanel();
			tbUsername = new TextBox();
			label2 = new Label();
			label3 = new Label();
			tbPassword = new TextBox();
			lbUsernameNotFound = new Label();
			lbPasswordInvalid = new Label();
			btnLogin = new Button();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 6;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
			tableLayoutPanel1.Controls.Add(tbUsername, 1, 1);
			tableLayoutPanel1.Controls.Add(label2, 1, 0);
			tableLayoutPanel1.Controls.Add(label3, 3, 0);
			tableLayoutPanel1.Controls.Add(tbPassword, 3, 1);
			tableLayoutPanel1.Controls.Add(lbUsernameNotFound, 2, 0);
			tableLayoutPanel1.Controls.Add(lbPasswordInvalid, 4, 0);
			tableLayoutPanel1.Controls.Add(btnLogin, 1, 2);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 4;
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new Size(470, 103);
			tableLayoutPanel1.TabIndex = 1;
			// 
			// tbUsername
			// 
			tbUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.SetColumnSpan(tbUsername, 2);
			tbUsername.Location = new Point(13, 29);
			tbUsername.Name = "tbUsername";
			tbUsername.Size = new Size(221, 27);
			tbUsername.TabIndex = 0;
			tbUsername.KeyDown += tbUsername_KeyDown;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Location = new Point(13, 3);
			label2.Margin = new Padding(3);
			label2.Name = "label2";
			label2.Size = new Size(75, 20);
			label2.TabIndex = 2;
			label2.Text = "Username";
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Location = new Point(240, 3);
			label3.Margin = new Padding(3);
			label3.Name = "label3";
			label3.Size = new Size(70, 20);
			label3.TabIndex = 3;
			label3.Text = "Password";
			// 
			// tbPassword
			// 
			tbPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.SetColumnSpan(tbPassword, 2);
			tbPassword.Location = new Point(240, 29);
			tbPassword.Name = "tbPassword";
			tbPassword.PasswordChar = '*';
			tbPassword.Size = new Size(216, 27);
			tbPassword.TabIndex = 1;
			tbPassword.KeyDown += tbPassword_KeyDown;
			// 
			// lbUsernameNotFound
			// 
			lbUsernameNotFound.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lbUsernameNotFound.AutoSize = true;
			lbUsernameNotFound.ForeColor = Color.Red;
			lbUsernameNotFound.Location = new Point(94, 3);
			lbUsernameNotFound.Margin = new Padding(3);
			lbUsernameNotFound.Name = "lbUsernameNotFound";
			lbUsernameNotFound.Size = new Size(94, 20);
			lbUsernameNotFound.TabIndex = 4;
			lbUsernameNotFound.Text = "<not found>";
			lbUsernameNotFound.Visible = false;
			// 
			// lbPasswordInvalid
			// 
			lbPasswordInvalid.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lbPasswordInvalid.AutoSize = true;
			lbPasswordInvalid.ForeColor = Color.Red;
			lbPasswordInvalid.Location = new Point(316, 3);
			lbPasswordInvalid.Margin = new Padding(3);
			lbPasswordInvalid.Name = "lbPasswordInvalid";
			lbPasswordInvalid.Size = new Size(73, 20);
			lbPasswordInvalid.TabIndex = 5;
			lbPasswordInvalid.Text = "<invalid>";
			lbPasswordInvalid.Visible = false;
			// 
			// btnLogin
			// 
			btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.SetColumnSpan(btnLogin, 4);
			btnLogin.Location = new Point(13, 62);
			btnLogin.Name = "btnLogin";
			btnLogin.Size = new Size(443, 30);
			btnLogin.TabIndex = 6;
			btnLogin.Text = "Login";
			btnLogin.UseVisualStyleBackColor = true;
			btnLogin.Click += btnLogin_Click;
			// 
			// frmLogin
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(243, 243, 243);
			ClientSize = new Size(470, 103);
			Controls.Add(tableLayoutPanel1);
			Font = new Font("Segoe UI", 11F);
			Margin = new Padding(3, 4, 3, 4);
			MaximizeBox = false;
			MinimumSize = new Size(440, 142);
			Name = "frmLogin";
			Text = "Membership Office Manager";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private TableLayoutPanel tableLayoutPanel1;
		private TextBox tbPassword;
		private TextBox tbUsername;
		private Label label2;
		private Label label3;
		private Label lbUsernameNotFound;
		private Label lbPasswordInvalid;
		private Button btnLogin;
	}
}