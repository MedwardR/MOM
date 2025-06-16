namespace MOM
{
	partial class frmError
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
			tbErrorMessage = new TextBox();
			label1 = new Label();
			btnContinueAnyway = new Button();
			btnCloseProgram = new Button();
			llSubmitBugReport = new LinkLabel();
			SuspendLayout();
			// 
			// tbErrorMessage
			// 
			tbErrorMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tbErrorMessage.BackColor = SystemColors.ControlLightLight;
			tbErrorMessage.Location = new Point(12, 27);
			tbErrorMessage.Multiline = true;
			tbErrorMessage.Name = "tbErrorMessage";
			tbErrorMessage.ReadOnly = true;
			tbErrorMessage.Size = new Size(404, 198);
			tbErrorMessage.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(207, 15);
			label1.TabIndex = 1;
			label1.Text = "An unhandled exception has occurred";
			// 
			// btnContinueAnyway
			// 
			btnContinueAnyway.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnContinueAnyway.Location = new Point(303, 231);
			btnContinueAnyway.Name = "btnContinueAnyway";
			btnContinueAnyway.Size = new Size(113, 23);
			btnContinueAnyway.TabIndex = 3;
			btnContinueAnyway.Text = "Continue anyway";
			btnContinueAnyway.UseVisualStyleBackColor = true;
			btnContinueAnyway.Click += btnContinueAnyway_Click;
			// 
			// btnCloseProgram
			// 
			btnCloseProgram.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnCloseProgram.Location = new Point(195, 231);
			btnCloseProgram.Name = "btnCloseProgram";
			btnCloseProgram.Size = new Size(102, 23);
			btnCloseProgram.TabIndex = 2;
			btnCloseProgram.Text = "Close program";
			btnCloseProgram.UseVisualStyleBackColor = true;
			btnCloseProgram.Click += btnCloseProgram_Click;
			// 
			// llSubmitBugReport
			// 
			llSubmitBugReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			llSubmitBugReport.AutoSize = true;
			llSubmitBugReport.Location = new Point(312, 9);
			llSubmitBugReport.Name = "llSubmitBugReport";
			llSubmitBugReport.Size = new Size(104, 15);
			llSubmitBugReport.TabIndex = 1;
			llSubmitBugReport.TabStop = true;
			llSubmitBugReport.Text = "Submit bug report";
			llSubmitBugReport.LinkClicked += llSubmitBugReport_LinkClicked;
			// 
			// frmError
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(243, 243, 243);
			ClientSize = new Size(428, 266);
			Controls.Add(llSubmitBugReport);
			Controls.Add(btnCloseProgram);
			Controls.Add(btnContinueAnyway);
			Controls.Add(label1);
			Controls.Add(tbErrorMessage);
			Name = "frmError";
			Text = "Error";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox tbErrorMessage;
		private Label label1;
		private Button btnContinueAnyway;
		private Button btnCloseProgram;
		private LinkLabel llSubmitBugReport;
	}
}