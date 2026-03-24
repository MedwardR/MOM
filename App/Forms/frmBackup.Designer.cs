namespace MOM.Forms
{
	partial class frmBackup
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackup));
			progressBar1 = new ProgressBar();
			label1 = new Label();
			SuspendLayout();
			// 
			// progressBar1
			// 
			progressBar1.Location = new Point(12, 38);
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new Size(342, 27);
			progressBar1.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(9, 9);
			label1.Margin = new Padding(0);
			label1.Name = "label1";
			label1.Size = new Size(156, 20);
			label1.TabIndex = 2;
			label1.Text = "Backing up database...";
			// 
			// frmBackup
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(243, 243, 243);
			ClientSize = new Size(366, 77);
			Controls.Add(label1);
			Controls.Add(progressBar1);
			Font = new Font("Segoe UI", 11F);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			MaximizeBox = false;
			Name = "frmBackup";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Backup";
			FormClosing += frmBackup_FormClosing;
			Load += frmBackup_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private ProgressBar progressBar1;
		private Label label1;
	}
}