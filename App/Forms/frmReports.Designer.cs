namespace MOM.Forms;

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
		tabPage3 = new TabPage();
		tableLayoutPanel4 = new TableLayoutPanel();
		btnMemberGenerate = new Button();
		llMemberExport = new LinkLabel();
		tabPage4 = new TabPage();
		tableLayoutPanel5 = new TableLayoutPanel();
		panel3 = new Panel();
		llK12 = new LinkLabel();
		label7 = new Label();
		cmbMembersByAgeOrderBy = new ComboBox();
		tbMembersByAgeFrom = new MOM.Controls.DateTimeTextBox();
		label8 = new Label();
		btnMembersByAgeGenerate = new Button();
		tbMembersByAgeTo = new MOM.Controls.DateTimeTextBox();
		label9 = new Label();
		tabPage5 = new TabPage();
		tableLayoutPanel3 = new TableLayoutPanel();
		btnChurchDirectoryGenerate = new Button();
		tabControl1.SuspendLayout();
		tabPage1.SuspendLayout();
		tableLayoutPanel1.SuspendLayout();
		panel1.SuspendLayout();
		tabPage2.SuspendLayout();
		tableLayoutPanel2.SuspendLayout();
		panel2.SuspendLayout();
		tabPage3.SuspendLayout();
		tableLayoutPanel4.SuspendLayout();
		tabPage4.SuspendLayout();
		tableLayoutPanel5.SuspendLayout();
		panel3.SuspendLayout();
		tabPage5.SuspendLayout();
		tableLayoutPanel3.SuspendLayout();
		SuspendLayout();
		// 
		// tabControl1
		// 
		tabControl1.Controls.Add(tabPage1);
		tabControl1.Controls.Add(tabPage2);
		tabControl1.Controls.Add(tabPage3);
		tabControl1.Controls.Add(tabPage4);
		tabControl1.Controls.Add(tabPage5);
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
		cmbBirthdayOrderBy.Size = new Size(186, 28);
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
		btnBirthdayGenerate.Location = new Point(195, 136);
		btnBirthdayGenerate.Name = "btnBirthdayGenerate";
		btnBirthdayGenerate.Size = new Size(180, 30);
		btnBirthdayGenerate.TabIndex = 2;
		btnBirthdayGenerate.Text = "Generate report";
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
		tabPage2.Location = new Point(4, 24);
		tabPage2.Margin = new Padding(3, 4, 3, 4);
		tabPage2.Name = "tabPage2";
		tabPage2.Size = new Size(630, 256);
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
		tableLayoutPanel2.Size = new Size(630, 256);
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
		panel2.Location = new Point(126, 43);
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
		cmbAnniversaryOrderBy.Size = new Size(186, 28);
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
		btnAnniversaryGenerate.Location = new Point(195, 136);
		btnAnniversaryGenerate.Name = "btnAnniversaryGenerate";
		btnAnniversaryGenerate.Size = new Size(180, 30);
		btnAnniversaryGenerate.TabIndex = 2;
		btnAnniversaryGenerate.Text = "Generate report";
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
		// tabPage3
		// 
		tabPage3.Controls.Add(tableLayoutPanel4);
		tabPage3.Location = new Point(4, 29);
		tabPage3.Name = "tabPage3";
		tabPage3.Padding = new Padding(3);
		tabPage3.Size = new Size(630, 251);
		tabPage3.TabIndex = 3;
		tabPage3.Text = "All Members";
		tabPage3.UseVisualStyleBackColor = true;
		// 
		// tableLayoutPanel4
		// 
		tableLayoutPanel4.ColumnCount = 3;
		tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
		tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		tableLayoutPanel4.Controls.Add(btnMemberGenerate, 1, 1);
		tableLayoutPanel4.Controls.Add(llMemberExport, 1, 2);
		tableLayoutPanel4.Dock = DockStyle.Fill;
		tableLayoutPanel4.Location = new Point(3, 3);
		tableLayoutPanel4.Name = "tableLayoutPanel4";
		tableLayoutPanel4.RowCount = 4;
		tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
		tableLayoutPanel4.RowStyles.Add(new RowStyle());
		tableLayoutPanel4.RowStyles.Add(new RowStyle());
		tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
		tableLayoutPanel4.Size = new Size(624, 245);
		tableLayoutPanel4.TabIndex = 7;
		// 
		// btnMemberGenerate
		// 
		btnMemberGenerate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnMemberGenerate.Location = new Point(222, 94);
		btnMemberGenerate.Name = "btnMemberGenerate";
		btnMemberGenerate.Size = new Size(180, 30);
		btnMemberGenerate.TabIndex = 2;
		btnMemberGenerate.Text = "Generate report";
		btnMemberGenerate.UseVisualStyleBackColor = true;
		btnMemberGenerate.Click += btnMemberGenerate_Click;
		// 
		// llMemberExport
		// 
		llMemberExport.AutoSize = true;
		llMemberExport.Location = new Point(219, 130);
		llMemberExport.Margin = new Padding(0, 3, 0, 3);
		llMemberExport.Name = "llMemberExport";
		llMemberExport.Size = new Size(82, 20);
		llMemberExport.TabIndex = 3;
		llMemberExport.TabStop = true;
		llMemberExport.Text = "Export CSV";
		llMemberExport.LinkClicked += llMemberExport_LinkClicked;
		// 
		// tabPage4
		// 
		tabPage4.Controls.Add(tableLayoutPanel5);
		tabPage4.Location = new Point(4, 24);
		tabPage4.Name = "tabPage4";
		tabPage4.Padding = new Padding(3);
		tabPage4.Size = new Size(630, 256);
		tabPage4.TabIndex = 4;
		tabPage4.Text = "Members by Age";
		tabPage4.UseVisualStyleBackColor = true;
		// 
		// tableLayoutPanel5
		// 
		tableLayoutPanel5.ColumnCount = 3;
		tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
		tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		tableLayoutPanel5.Controls.Add(panel3, 1, 1);
		tableLayoutPanel5.Dock = DockStyle.Fill;
		tableLayoutPanel5.Location = new Point(3, 3);
		tableLayoutPanel5.Name = "tableLayoutPanel5";
		tableLayoutPanel5.RowCount = 3;
		tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
		tableLayoutPanel5.RowStyles.Add(new RowStyle());
		tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
		tableLayoutPanel5.Size = new Size(624, 250);
		tableLayoutPanel5.TabIndex = 7;
		// 
		// panel3
		// 
		panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		panel3.Controls.Add(llK12);
		panel3.Controls.Add(label7);
		panel3.Controls.Add(cmbMembersByAgeOrderBy);
		panel3.Controls.Add(tbMembersByAgeFrom);
		panel3.Controls.Add(label8);
		panel3.Controls.Add(btnMembersByAgeGenerate);
		panel3.Controls.Add(tbMembersByAgeTo);
		panel3.Controls.Add(label9);
		panel3.Location = new Point(123, 40);
		panel3.Name = "panel3";
		panel3.Size = new Size(378, 170);
		panel3.TabIndex = 5;
		// 
		// llK12
		// 
		llK12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		llK12.AutoSize = true;
		llK12.Location = new Point(325, 6);
		llK12.Name = "llK12";
		llK12.Size = new Size(50, 20);
		llK12.TabIndex = 7;
		llK12.TabStop = true;
		llK12.Text = "(K-12)";
		llK12.LinkClicked += llK12_LinkClicked;
		// 
		// label7
		// 
		label7.AutoEllipsis = true;
		label7.AutoSize = true;
		label7.Location = new Point(3, 114);
		label7.Name = "label7";
		label7.Size = new Size(67, 20);
		label7.TabIndex = 6;
		label7.Text = "Order by";
		// 
		// cmbMembersByAgeOrderBy
		// 
		cmbMembersByAgeOrderBy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		cmbMembersByAgeOrderBy.FormattingEnabled = true;
		cmbMembersByAgeOrderBy.Location = new Point(3, 137);
		cmbMembersByAgeOrderBy.MaxDropDownItems = 12;
		cmbMembersByAgeOrderBy.Name = "cmbMembersByAgeOrderBy";
		cmbMembersByAgeOrderBy.Size = new Size(186, 28);
		cmbMembersByAgeOrderBy.TabIndex = 5;
		// 
		// tbMembersByAgeFrom
		// 
		tbMembersByAgeFrom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		tbMembersByAgeFrom.Location = new Point(3, 29);
		tbMembersByAgeFrom.Mask = "90/90/9900";
		tbMembersByAgeFrom.Name = "tbMembersByAgeFrom";
		tbMembersByAgeFrom.Size = new Size(372, 27);
		tbMembersByAgeFrom.TabIndex = 0;
		tbMembersByAgeFrom.ValidatingType = typeof(DateTime);
		tbMembersByAgeFrom.Value = null;
		tbMembersByAgeFrom.Validated += tbMembersByAgeFrom_Validated;
		// 
		// label8
		// 
		label8.AutoEllipsis = true;
		label8.AutoSize = true;
		label8.Location = new Point(3, 6);
		label8.Name = "label8";
		label8.Size = new Size(43, 20);
		label8.TabIndex = 3;
		label8.Text = "From";
		// 
		// btnMembersByAgeGenerate
		// 
		btnMembersByAgeGenerate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnMembersByAgeGenerate.Location = new Point(195, 136);
		btnMembersByAgeGenerate.Name = "btnMembersByAgeGenerate";
		btnMembersByAgeGenerate.Size = new Size(180, 30);
		btnMembersByAgeGenerate.TabIndex = 2;
		btnMembersByAgeGenerate.Text = "Generate report";
		btnMembersByAgeGenerate.UseVisualStyleBackColor = true;
		btnMembersByAgeGenerate.Click += btnMembersByAgeGenerate_Click;
		// 
		// tbMembersByAgeTo
		// 
		tbMembersByAgeTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		tbMembersByAgeTo.Location = new Point(3, 83);
		tbMembersByAgeTo.Mask = "90/90/9900";
		tbMembersByAgeTo.Name = "tbMembersByAgeTo";
		tbMembersByAgeTo.Size = new Size(372, 27);
		tbMembersByAgeTo.TabIndex = 1;
		tbMembersByAgeTo.ValidatingType = typeof(DateTime);
		tbMembersByAgeTo.Value = null;
		tbMembersByAgeTo.Validated += tbMembersByAgeTo_Validated;
		// 
		// label9
		// 
		label9.AutoEllipsis = true;
		label9.AutoSize = true;
		label9.Location = new Point(3, 60);
		label9.Name = "label9";
		label9.Size = new Size(25, 20);
		label9.TabIndex = 4;
		label9.Text = "To";
		// 
		// tabPage5
		// 
		tabPage5.Controls.Add(tableLayoutPanel3);
		tabPage5.Location = new Point(4, 24);
		tabPage5.Name = "tabPage5";
		tabPage5.Padding = new Padding(3);
		tabPage5.Size = new Size(630, 256);
		tabPage5.TabIndex = 2;
		tabPage5.Text = "Church Directory";
		tabPage5.UseVisualStyleBackColor = true;
		// 
		// tableLayoutPanel3
		// 
		tableLayoutPanel3.ColumnCount = 3;
		tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
		tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		tableLayoutPanel3.Controls.Add(btnChurchDirectoryGenerate, 1, 1);
		tableLayoutPanel3.Dock = DockStyle.Fill;
		tableLayoutPanel3.Location = new Point(3, 3);
		tableLayoutPanel3.Name = "tableLayoutPanel3";
		tableLayoutPanel3.RowCount = 3;
		tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
		tableLayoutPanel3.RowStyles.Add(new RowStyle());
		tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
		tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
		tableLayoutPanel3.Size = new Size(624, 250);
		tableLayoutPanel3.TabIndex = 6;
		// 
		// btnChurchDirectoryGenerate
		// 
		btnChurchDirectoryGenerate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnChurchDirectoryGenerate.Location = new Point(222, 110);
		btnChurchDirectoryGenerate.Name = "btnChurchDirectoryGenerate";
		btnChurchDirectoryGenerate.Size = new Size(180, 30);
		btnChurchDirectoryGenerate.TabIndex = 2;
		btnChurchDirectoryGenerate.Text = "Generate report";
		btnChurchDirectoryGenerate.UseVisualStyleBackColor = true;
		btnChurchDirectoryGenerate.Click += btnChurchDirectoryGenerate_Click;
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
		tabPage3.ResumeLayout(false);
		tableLayoutPanel4.ResumeLayout(false);
		tableLayoutPanel4.PerformLayout();
		tabPage4.ResumeLayout(false);
		tableLayoutPanel5.ResumeLayout(false);
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		tabPage5.ResumeLayout(false);
		tableLayoutPanel3.ResumeLayout(false);
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
	private TabPage tabPage5;
	private TableLayoutPanel tableLayoutPanel3;
	private Button btnChurchDirectoryGenerate;
	private TabPage tabPage3;
	private TableLayoutPanel tableLayoutPanel4;
	private Button btnMemberGenerate;
	private TabPage tabPage4;
	private TableLayoutPanel tableLayoutPanel5;
	private Panel panel3;
	private Label label7;
	private ComboBox cmbMembersByAgeOrderBy;
	private MOM.Controls.DateTimeTextBox tbMembersByAgeFrom;
	private Label label8;
	private Button btnMembersByAgeGenerate;
	private MOM.Controls.DateTimeTextBox tbMembersByAgeTo;
	private Label label9;
	private LinkLabel llK12;
	private LinkLabel llMemberExport;
}