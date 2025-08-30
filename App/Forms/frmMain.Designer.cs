namespace MOM
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			splitContainer1 = new SplitContainer();
			tableLayoutPanel1 = new TableLayoutPanel();
			tbSearch = new TextBox();
			label1 = new Label();
			dgHouseholds = new DataGridView();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			bsHouseholds = new BindingSource(components);
			tableLayoutPanel3 = new TableLayoutPanel();
			groupBox1 = new GroupBox();
			flowLayoutPanel2 = new FlowLayoutPanel();
			btnNew = new Button();
			btnSave = new Button();
			btnRevert = new Button();
			tableLayoutPanel2 = new TableLayoutPanel();
			tbCountry = new TextBox();
			label7 = new Label();
			tbStreet = new TextBox();
			label3 = new Label();
			label2 = new Label();
			tbName = new TextBox();
			label4 = new Label();
			tbCity = new TextBox();
			label6 = new Label();
			label5 = new Label();
			tbZIP = new TextBox();
			tbState = new TextBox();
			tbPhone = new MaskedTextBox();
			label9 = new Label();
			label8 = new Label();
			tbEmail = new TextBox();
			groupBox2 = new GroupBox();
			flpMembers = new FlowLayoutPanel();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgHouseholds).BeginInit();
			((System.ComponentModel.ISupportInitialize)bsHouseholds).BeginInit();
			tableLayoutPanel3.SuspendLayout();
			groupBox1.SuspendLayout();
			flowLayoutPanel2.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Font = new Font("Segoe UI", 11F);
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
			splitContainer1.Panel1.Padding = new Padding(3, 3, 0, 3);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(tableLayoutPanel3);
			splitContainer1.Panel2.Padding = new Padding(0, 3, 3, 3);
			splitContainer1.Size = new Size(832, 515);
			splitContainer1.SplitterDistance = 336;
			splitContainer1.SplitterWidth = 6;
			splitContainer1.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Controls.Add(tbSearch, 1, 0);
			tableLayoutPanel1.Controls.Add(label1, 0, 0);
			tableLayoutPanel1.Controls.Add(dgHouseholds, 0, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Font = new Font("Segoe UI", 11F);
			tableLayoutPanel1.Location = new Point(3, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new Size(333, 509);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// tbSearch
			// 
			tbSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbSearch.Font = new Font("Segoe UI", 11F);
			tbSearch.Location = new Point(62, 3);
			tbSearch.Margin = new Padding(3, 3, 0, 3);
			tbSearch.Name = "tbSearch";
			tbSearch.Size = new Size(271, 27);
			tbSearch.TabIndex = 10;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 11F);
			label1.Location = new Point(3, 6);
			label1.Name = "label1";
			label1.Size = new Size(53, 20);
			label1.TabIndex = 2;
			label1.Text = "Search";
			// 
			// dgHouseholds
			// 
			dgHouseholds.AutoGenerateColumns = false;
			dgHouseholds.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgHouseholds.ColumnHeadersVisible = false;
			dgHouseholds.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn });
			tableLayoutPanel1.SetColumnSpan(dgHouseholds, 2);
			dgHouseholds.DataSource = bsHouseholds;
			dgHouseholds.Dock = DockStyle.Fill;
			dgHouseholds.Location = new Point(3, 36);
			dgHouseholds.MultiSelect = false;
			dgHouseholds.Name = "dgHouseholds";
			dgHouseholds.ReadOnly = true;
			dgHouseholds.RowHeadersVisible = false;
			dgHouseholds.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgHouseholds.Size = new Size(327, 470);
			dgHouseholds.TabIndex = 11;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn.HeaderText = "Name";
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			nameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// bsHouseholds
			// 
			bsHouseholds.DataSource = typeof(Models.Household);
			bsHouseholds.CurrentChanged += bsHouseholds_CurrentChanged;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 1;
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel3.Controls.Add(groupBox1, 0, 0);
			tableLayoutPanel3.Controls.Add(groupBox2, 0, 1);
			tableLayoutPanel3.Dock = DockStyle.Fill;
			tableLayoutPanel3.Location = new Point(0, 3);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 2;
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel3.Size = new Size(487, 509);
			tableLayoutPanel3.TabIndex = 1;
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox1.Controls.Add(flowLayoutPanel2);
			groupBox1.Controls.Add(tableLayoutPanel2);
			groupBox1.Font = new Font("Segoe UI", 11F);
			groupBox1.Location = new Point(0, 3);
			groupBox1.Margin = new Padding(0, 3, 3, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(484, 239);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Household";
			// 
			// flowLayoutPanel2
			// 
			flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			flowLayoutPanel2.AutoSize = true;
			flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			flowLayoutPanel2.Controls.Add(btnNew);
			flowLayoutPanel2.Controls.Add(btnSave);
			flowLayoutPanel2.Controls.Add(btnRevert);
			flowLayoutPanel2.Location = new Point(172, 0);
			flowLayoutPanel2.Margin = new Padding(3, 3, 0, 3);
			flowLayoutPanel2.Name = "flowLayoutPanel2";
			flowLayoutPanel2.Size = new Size(309, 30);
			flowLayoutPanel2.TabIndex = 0;
			// 
			// btnNew
			// 
			btnNew.Location = new Point(0, 0);
			btnNew.Margin = new Padding(0, 0, 3, 0);
			btnNew.Name = "btnNew";
			btnNew.Size = new Size(100, 30);
			btnNew.TabIndex = 10;
			btnNew.Text = "New";
			btnNew.UseVisualStyleBackColor = true;
			btnNew.Click += btnNew_Click;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(103, 0);
			btnSave.Margin = new Padding(0, 0, 3, 0);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(100, 30);
			btnSave.TabIndex = 20;
			btnSave.Text = "Save";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// btnRevert
			// 
			btnRevert.Location = new Point(206, 0);
			btnRevert.Margin = new Padding(0, 0, 3, 0);
			btnRevert.Name = "btnRevert";
			btnRevert.Size = new Size(100, 30);
			btnRevert.TabIndex = 30;
			btnRevert.Text = "Revert";
			btnRevert.UseVisualStyleBackColor = true;
			btnRevert.Click += btnRevert_Click;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 6;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666718F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
			tableLayoutPanel2.Controls.Add(tbCountry, 4, 5);
			tableLayoutPanel2.Controls.Add(label7, 4, 4);
			tableLayoutPanel2.Controls.Add(tbStreet, 0, 3);
			tableLayoutPanel2.Controls.Add(label3, 0, 2);
			tableLayoutPanel2.Controls.Add(label2, 0, 0);
			tableLayoutPanel2.Controls.Add(tbName, 0, 1);
			tableLayoutPanel2.Controls.Add(label4, 3, 2);
			tableLayoutPanel2.Controls.Add(tbCity, 3, 3);
			tableLayoutPanel2.Controls.Add(label6, 0, 4);
			tableLayoutPanel2.Controls.Add(label5, 2, 4);
			tableLayoutPanel2.Controls.Add(tbZIP, 0, 5);
			tableLayoutPanel2.Controls.Add(tbState, 2, 5);
			tableLayoutPanel2.Controls.Add(tbPhone, 0, 7);
			tableLayoutPanel2.Controls.Add(label9, 0, 6);
			tableLayoutPanel2.Controls.Add(label8, 2, 6);
			tableLayoutPanel2.Controls.Add(tbEmail, 2, 7);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(3, 23);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 9;
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel2.Size = new Size(478, 213);
			tableLayoutPanel2.TabIndex = 4;
			// 
			// tbCountry
			// 
			tbCountry.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel2.SetColumnSpan(tbCountry, 2);
			tbCountry.Font = new Font("Segoe UI", 11F);
			tbCountry.Location = new Point(319, 129);
			tbCountry.Name = "tbCountry";
			tbCountry.PlaceholderText = "USA";
			tbCountry.Size = new Size(156, 27);
			tbCountry.TabIndex = 60;
			tbCountry.Text = "USA";
			// 
			// label7
			// 
			label7.AutoSize = true;
			tableLayoutPanel2.SetColumnSpan(label7, 2);
			label7.Font = new Font("Segoe UI", 11F);
			label7.Location = new Point(319, 106);
			label7.Name = "label7";
			label7.Size = new Size(60, 20);
			label7.TabIndex = 10;
			label7.Text = "Country";
			// 
			// tbStreet
			// 
			tbStreet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel2.SetColumnSpan(tbStreet, 3);
			tbStreet.Font = new Font("Segoe UI", 11F);
			tbStreet.Location = new Point(3, 76);
			tbStreet.Name = "tbStreet";
			tbStreet.PlaceholderText = "129 Pleasant Valley Rd.";
			tbStreet.Size = new Size(231, 27);
			tbStreet.TabIndex = 20;
			// 
			// label3
			// 
			label3.AutoSize = true;
			tableLayoutPanel2.SetColumnSpan(label3, 3);
			label3.Font = new Font("Segoe UI", 11F);
			label3.Location = new Point(3, 53);
			label3.Name = "label3";
			label3.Size = new Size(48, 20);
			label3.TabIndex = 3;
			label3.Text = "Street";
			// 
			// label2
			// 
			label2.AutoSize = true;
			tableLayoutPanel2.SetColumnSpan(label2, 6);
			label2.Font = new Font("Segoe UI", 11F);
			label2.Location = new Point(3, 0);
			label2.Name = "label2";
			label2.Size = new Size(49, 20);
			label2.TabIndex = 1;
			label2.Text = "Name";
			// 
			// tbName
			// 
			tbName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel2.SetColumnSpan(tbName, 6);
			tbName.Font = new Font("Segoe UI", 11F);
			tbName.Location = new Point(3, 23);
			tbName.Name = "tbName";
			tbName.Size = new Size(472, 27);
			tbName.TabIndex = 10;
			// 
			// label4
			// 
			label4.AutoSize = true;
			tableLayoutPanel2.SetColumnSpan(label4, 3);
			label4.Font = new Font("Segoe UI", 11F);
			label4.Location = new Point(240, 53);
			label4.Name = "label4";
			label4.Size = new Size(34, 20);
			label4.TabIndex = 4;
			label4.Text = "City";
			// 
			// tbCity
			// 
			tbCity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel2.SetColumnSpan(tbCity, 3);
			tbCity.Font = new Font("Segoe UI", 11F);
			tbCity.Location = new Point(240, 76);
			tbCity.Name = "tbCity";
			tbCity.PlaceholderText = "East Earl";
			tbCity.Size = new Size(235, 27);
			tbCity.TabIndex = 30;
			// 
			// label6
			// 
			label6.AutoSize = true;
			tableLayoutPanel2.SetColumnSpan(label6, 2);
			label6.Font = new Font("Segoe UI", 11F);
			label6.Location = new Point(3, 106);
			label6.Name = "label6";
			label6.Size = new Size(69, 20);
			label6.TabIndex = 8;
			label6.Text = "ZIP Code";
			// 
			// label5
			// 
			label5.AutoSize = true;
			tableLayoutPanel2.SetColumnSpan(label5, 2);
			label5.Font = new Font("Segoe UI", 11F);
			label5.Location = new Point(161, 106);
			label5.Name = "label5";
			label5.Size = new Size(43, 20);
			label5.TabIndex = 6;
			label5.Text = "State";
			// 
			// tbZIP
			// 
			tbZIP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel2.SetColumnSpan(tbZIP, 2);
			tbZIP.Font = new Font("Segoe UI", 11F);
			tbZIP.Location = new Point(3, 129);
			tbZIP.Name = "tbZIP";
			tbZIP.PlaceholderText = "17519";
			tbZIP.Size = new Size(152, 27);
			tbZIP.TabIndex = 40;
			// 
			// tbState
			// 
			tbState.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel2.SetColumnSpan(tbState, 2);
			tbState.Font = new Font("Segoe UI", 11F);
			tbState.Location = new Point(161, 129);
			tbState.Name = "tbState";
			tbState.PlaceholderText = "PA";
			tbState.Size = new Size(152, 27);
			tbState.TabIndex = 50;
			tbState.Text = "PA";
			// 
			// tbPhone
			// 
			tbPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel2.SetColumnSpan(tbPhone, 2);
			tbPhone.Location = new Point(3, 182);
			tbPhone.Mask = "(999) 000-0000";
			tbPhone.Name = "tbPhone";
			tbPhone.Size = new Size(152, 27);
			tbPhone.TabIndex = 70;
			// 
			// label9
			// 
			label9.AutoSize = true;
			tableLayoutPanel2.SetColumnSpan(label9, 2);
			label9.Font = new Font("Segoe UI", 11F);
			label9.Location = new Point(3, 159);
			label9.Name = "label9";
			label9.Size = new Size(50, 20);
			label9.TabIndex = 14;
			label9.Text = "Phone";
			// 
			// label8
			// 
			label8.AutoSize = true;
			tableLayoutPanel2.SetColumnSpan(label8, 4);
			label8.Font = new Font("Segoe UI", 11F);
			label8.Location = new Point(161, 159);
			label8.Name = "label8";
			label8.Size = new Size(46, 20);
			label8.TabIndex = 12;
			label8.Text = "Email";
			// 
			// tbEmail
			// 
			tbEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel2.SetColumnSpan(tbEmail, 4);
			tbEmail.Font = new Font("Segoe UI", 11F);
			tbEmail.Location = new Point(161, 182);
			tbEmail.Name = "tbEmail";
			tbEmail.Size = new Size(314, 27);
			tbEmail.TabIndex = 80;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(flpMembers);
			groupBox2.Dock = DockStyle.Fill;
			groupBox2.Location = new Point(0, 248);
			groupBox2.Margin = new Padding(0, 3, 3, 3);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(484, 258);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Members";
			// 
			// flpMembers
			// 
			flpMembers.Dock = DockStyle.Fill;
			flpMembers.Location = new Point(3, 23);
			flpMembers.Name = "flpMembers";
			flpMembers.Size = new Size(478, 232);
			flpMembers.TabIndex = 0;
			// 
			// frmMain
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(243, 243, 243);
			ClientSize = new Size(832, 515);
			Controls.Add(splitContainer1);
			Font = new Font("Segoe UI", 11F);
			Margin = new Padding(4);
			Name = "frmMain";
			Text = "Membership Office Manager";
			Shown += frmMain_Shown;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgHouseholds).EndInit();
			((System.ComponentModel.ISupportInitialize)bsHouseholds).EndInit();
			tableLayoutPanel3.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			flowLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			groupBox2.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private TableLayoutPanel tableLayoutPanel1;
		private TextBox tbSearch;
		private Label label1;
		private GroupBox groupBox1;
		private Label label2;
		private TextBox tbName;
		private Label label3;
		private TextBox tbStreet;
		private TableLayoutPanel tableLayoutPanel2;
		private TextBox tbCity;
		private Label label4;
		private Label label5;
		private TextBox tbCountry;
		private Label label7;
		private TextBox tbState;
		private Label label6;
		private TextBox tbZIP;
		private MaskedTextBox tbPhone;
		private Label label8;
		private Label label9;
		private TextBox tbEmail;
		private TableLayoutPanel tableLayoutPanel3;
		private GroupBox groupBox2;
		private FlowLayoutPanel flpMembers;
		private FlowLayoutPanel flowLayoutPanel2;
		private Button btnSave;
		private Button btnRevert;
		private Button btnNew;
		private DataGridView dgHouseholds;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private BindingSource bsHouseholds;
	}
}
