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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmError));
			tbErrorMessage = new TextBox();
			btnCloseProgram = new Button();
			llReport = new LinkLabel();
			btnContinueAnyway = new Button();
			SuspendLayout();
			// 
			// tbErrorMessage
			// 
			tbErrorMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tbErrorMessage.BackColor = SystemColors.ControlLightLight;
			tbErrorMessage.Location = new Point(12, 6);
			tbErrorMessage.Multiline = true;
			tbErrorMessage.Name = "tbErrorMessage";
			tbErrorMessage.ReadOnly = true;
			tbErrorMessage.ScrollBars = ScrollBars.Both;
			tbErrorMessage.Size = new Size(496, 273);
			tbErrorMessage.TabIndex = 0;
			tbErrorMessage.WordWrap = false;
			// 
			// btnCloseProgram
			// 
			btnCloseProgram.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnCloseProgram.Location = new Point(406, 285);
			btnCloseProgram.Name = "btnCloseProgram";
			btnCloseProgram.Size = new Size(102, 23);
			btnCloseProgram.TabIndex = 3;
			btnCloseProgram.Text = "Close program";
			btnCloseProgram.UseVisualStyleBackColor = true;
			btnCloseProgram.Click += btnCloseProgram_Click;
			// 
			// llReport
			// 
			llReport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			llReport.AutoSize = true;
			llReport.Location = new Point(12, 289);
			llReport.Name = "llReport";
			llReport.Size = new Size(125, 15);
			llReport.TabIndex = 1;
			llReport.TabStop = true;
			llReport.Text = "Please report this error";
			llReport.LinkClicked += llReport_LinkClicked;
			// 
			// btnContinueAnyway
			// 
			btnContinueAnyway.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnContinueAnyway.Location = new Point(282, 285);
			btnContinueAnyway.Name = "btnContinueAnyway";
			btnContinueAnyway.Size = new Size(118, 23);
			btnContinueAnyway.TabIndex = 2;
			btnContinueAnyway.Text = "Continue anyway";
			btnContinueAnyway.UseVisualStyleBackColor = true;
			btnContinueAnyway.Click += btnContinueAnyway_Click;
			// 
			// frmError
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(243, 243, 243);
			ClientSize = new Size(520, 320);
			ControlBox = false;
			Controls.Add(btnContinueAnyway);
			Controls.Add(btnCloseProgram);
			Controls.Add(tbErrorMessage);
			Controls.Add(llReport);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MinimumSize = new Size(390, 176);
			Name = "frmError";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Error";
			Shown += frmError_Shown;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox tbErrorMessage;
		private Button btnCloseProgram;
		private LinkLabel llReport;
		private Button btnContinueAnyway;
	}
}