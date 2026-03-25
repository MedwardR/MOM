namespace MOM.Forms
{
	partial class frmReports
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReports));
			tabControl1 = new TabControl();
			tabPage1 = new TabPage();
			tableLayoutPanel1 = new TableLayoutPanel();
			panel1 = new Panel();
			label3 = new Label();
			cmbBirthdayOrderBy = new ComboBox();
			cmbBirthdayFrom = new ComboBox();
			label1 = new Label();
			btnBirthdayGenerate = new Button();
			cmbBirthdayTo = new ComboBox();
			label2 = new Label();
			tabPage2 = new TabPage();
			tableLayoutPanel2 = new TableLayoutPanel();
			panel2 = new Panel();
			label4 = new Label();
			cmbAnniversaryOrderBy = new ComboBox();
			cmbAnniversaryFrom = new ComboBox();
			label5 = new Label();
			btnAnniversaryGenerate = new Button();
			cmbAnniversaryTo = new ComboBox();
			label6 = new Label();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			panel1.SuspendLayout();
			tabPage2.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.Location = new Point(6, 4);
			tabControl1.Margin = new Padding(3, 4, 3, 4);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(638, 284);
			tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(tableLayoutPanel1);
			tabPage1.Location = new Point(4, 29);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new Size(630, 251);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Birthdays";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Controls.Add(panel1, 1, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Size = new Size(630, 251);
			tableLayoutPanel1.TabIndex = 5;
			// 
			// panel1
			// 
			panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel1.Controls.Add(label3);
			panel1.Controls.Add(cmbBirthdayOrderBy);
			panel1.Controls.Add(cmbBirthdayFrom);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnBirthdayGenerate);
			panel1.Controls.Add(cmbBirthdayTo);
			panel1.Controls.Add(label2);
			panel1.Location = new Point(126, 40);
			panel1.Name = "panel1";
			panel1.Size = new Size(378, 170);
			panel1.TabIndex = 5;
			// 
			// label3
			// 
			label3.AutoEllipsis = true;
			label3.AutoSize = true;
			label3.Location = new Point(3, 114);
			label3.Name = "label3";
			label3.Size = new Size(67, 20);
			label3.TabIndex = 6;
			label3.Text = "Order by";
			// 
			// cmbBirthdayOrderBy
			// 
			cmbBirthdayOrderBy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmbBirthdayOrderBy.FormattingEnabled = true;
			cmbBirthdayOrderBy.Location = new Point(3, 137);
			cmbBirthdayOrderBy.MaxDropDownItems = 12;
			cmbBirthdayOrderBy.Name = "cmbBirthdayOrderBy";
			cmbBirthdayOrderBy.Size = new Size(245, 28);
			cmbBirthdayOrderBy.TabIndex = 5;
			// 
			// cmbBirthdayFrom
			// 
			cmbBirthdayFrom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmbBirthdayFrom.FormattingEnabled = true;
			cmbBirthdayFrom.Location = new Point(3, 29);
			cmbBirthdayFrom.Name = "cmbBirthdayFrom";
			cmbBirthdayFrom.Size = new Size(372, 28);
			cmbBirthdayFrom.TabIndex = 0;
			cmbBirthdayFrom.SelectedIndexChanged += cmbBirthdayFrom_SelectedIndexChanged;
			// 
			// label1
			// 
			label1.AutoEllipsis = true;
			label1.AutoSize = true;
			label1.Location = new Point(3, 6);
			label1.Name = "label1";
			label1.Size = new Size(43, 20);
			label1.TabIndex = 3;
			label1.Text = "From";
			// 
			// btnBirthdayGenerate
			// 
			btnBirthdayGenerate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnBirthdayGenerate.Location = new Point(254, 136);
			btnBirthdayGenerate.Name = "btnBirthdayGenerate";
			btnBirthdayGenerate.Size = new Size(121, 30);
			btnBirthdayGenerate.TabIndex = 2;
			btnBirthdayGenerate.Text = "Generate";
			btnBirthdayGenerate.UseVisualStyleBackColor = true;
			btnBirthdayGenerate.Click += btnBirthdayGenerate_Click;
			// 
			// cmbBirthdayTo
			// 
			cmbBirthdayTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmbBirthdayTo.FormattingEnabled = true;
			cmbBirthdayTo.Location = new Point(3, 83);
			cmbBirthdayTo.Name = "cmbBirthdayTo";
			cmbBirthdayTo.Size = new Size(372, 28);
			cmbBirthdayTo.TabIndex = 1;
			cmbBirthdayTo.SelectedIndexChanged += cmbBirthdayTo_SelectedIndexChanged;
			// 
			// label2
			// 
			label2.AutoEllipsis = true;
			label2.AutoSize = true;
			label2.Location = new Point(3, 60);
			label2.Name = "label2";
			label2.Size = new Size(25, 20);
			label2.TabIndex = 4;
			label2.Text = "To";
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(tableLayoutPanel2);
			tabPage2.Location = new Point(4, 29);
			tabPage2.Margin = new Padding(3, 4, 3, 4);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new Size(630, 251);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Anniversaries";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 3;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.Controls.Add(panel2, 1, 1);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(0, 0);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 3;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.Size = new Size(630, 251);
			tableLayoutPanel2.TabIndex = 6;
			// 
			// panel2
			// 
			panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel2.Controls.Add(label4);
			panel2.Controls.Add(cmbAnniversaryOrderBy);
			panel2.Controls.Add(cmbAnniversaryFrom);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(btnAnniversaryGenerate);
			panel2.Controls.Add(cmbAnniversaryTo);
			panel2.Controls.Add(label6);
			panel2.Location = new Point(126, 40);
			panel2.Name = "panel2";
			panel2.Size = new Size(378, 170);
			panel2.TabIndex = 5;
			// 
			// label4
			// 
			label4.AutoEllipsis = true;
			label4.AutoSize = true;
			label4.Location = new Point(3, 114);
			label4.Name = "label4";
			label4.Size = new Size(67, 20);
			label4.TabIndex = 6;
			label4.Text = "Order by";
			// 
			// cmbAnniversaryOrderBy
			// 
			cmbAnniversaryOrderBy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmbAnniversaryOrderBy.FormattingEnabled = true;
			cmbAnniversaryOrderBy.Location = new Point(3, 137);
			cmbAnniversaryOrderBy.MaxDropDownItems = 12;
			cmbAnniversaryOrderBy.Name = "cmbAnniversaryOrderBy";
			cmbAnniversaryOrderBy.Size = new Size(245, 28);
			cmbAnniversaryOrderBy.TabIndex = 5;
			// 
			// cmbAnniversaryFrom
			// 
			cmbAnniversaryFrom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmbAnniversaryFrom.FormattingEnabled = true;
			cmbAnniversaryFrom.Location = new Point(3, 29);
			cmbAnniversaryFrom.Name = "cmbAnniversaryFrom";
			cmbAnniversaryFrom.Size = new Size(372, 28);
			cmbAnniversaryFrom.TabIndex = 0;
			cmbAnniversaryFrom.SelectedIndexChanged += cmbAnniversaryFrom_SelectedIndexChanged;
			// 
			// label5
			// 
			label5.AutoEllipsis = true;
			label5.AutoSize = true;
			label5.Location = new Point(3, 6);
			label5.Name = "label5";
			label5.Size = new Size(43, 20);
			label5.TabIndex = 3;
			label5.Text = "From";
			// 
			// btnAnniversaryGenerate
			// 
			btnAnniversaryGenerate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnAnniversaryGenerate.Location = new Point(254, 136);
			btnAnniversaryGenerate.Name = "btnAnniversaryGenerate";
			btnAnniversaryGenerate.Size = new Size(121, 30);
			btnAnniversaryGenerate.TabIndex = 2;
			btnAnniversaryGenerate.Text = "Generate";
			btnAnniversaryGenerate.UseVisualStyleBackColor = true;
			btnAnniversaryGenerate.Click += btnAnniversaryGenerate_Click;
			// 
			// cmbAnniversaryTo
			// 
			cmbAnniversaryTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cmbAnniversaryTo.FormattingEnabled = true;
			cmbAnniversaryTo.Location = new Point(3, 83);
			cmbAnniversaryTo.Name = "cmbAnniversaryTo";
			cmbAnniversaryTo.Size = new Size(372, 28);
			cmbAnniversaryTo.TabIndex = 1;
			cmbAnniversaryTo.SelectedIndexChanged += cmbAnniversaryTo_SelectedIndexChanged;
			// 
			// label6
			// 
			label6.AutoEllipsis = true;
			label6.AutoSize = true;
			label6.Location = new Point(3, 60);
			label6.Name = "label6";
			label6.Size = new Size(25, 20);
			label6.TabIndex = 4;
			label6.Text = "To";
			// 
			// frmReports
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(243, 243, 243);
			ClientSize = new Size(648, 294);
			Controls.Add(tabControl1);
			Font = new Font("Segoe UI", 11F);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "frmReports";
			Padding = new Padding(6, 4, 4, 6);
			Text = "Reports";
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			tabPage2.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private Label label2;
		private Label label1;
		private Button btnBirthdayGenerate;
		private ComboBox cmbBirthdayTo;
		private ComboBox cmbBirthdayFrom;
		private TableLayoutPanel tableLayoutPanel1;
		private Panel panel1;
		private ComboBox cmbBirthdayOrderBy;
		private Label label3;
		private TableLayoutPanel tableLayoutPanel2;
		private Panel panel2;
		private Label label4;
		private ComboBox cmbAnniversaryOrderBy;
		private ComboBox cmbAnniversaryFrom;
		private Label label5;
		private Button btnAnniversaryGenerate;
		private ComboBox cmbAnniversaryTo;
		private Label label6;
	}
}