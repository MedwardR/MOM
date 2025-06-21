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
			groupBox1 = new GroupBox();
			btnCopyHash = new Button();
			tbPassword = new TextBox();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(btnCopyHash);
			groupBox1.Controls.Add(tbPassword);
			groupBox1.Location = new Point(12, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(228, 95);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Hash password";
			// 
			// btnCopyHash
			// 
			btnCopyHash.Location = new Point(6, 59);
			btnCopyHash.Name = "btnCopyHash";
			btnCopyHash.Size = new Size(216, 30);
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
			// frmTools
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(678, 397);
			Controls.Add(groupBox1);
			Font = new Font("Segoe UI", 11F);
			Margin = new Padding(3, 4, 3, 4);
			Name = "frmTools";
			Text = "Tools";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBox1;
		private TextBox tbPassword;
		private Button btnCopyHash;
	}
}