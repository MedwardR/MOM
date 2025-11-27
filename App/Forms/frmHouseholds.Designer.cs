namespace MOM
{
    partial class frmHouseholds
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
			dgvHouseholds = new DataGridView();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			bsHouseholds = new BindingSource(components);
			tableLayoutPanel3 = new TableLayoutPanel();
			gbHousehold = new GroupBox();
			flowLayoutPanel2 = new FlowLayoutPanel();
			btnNewHousehold = new Button();
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
			label5 = new Label();
			label6 = new Label();
			tbState = new TextBox();
			tbZIP = new TextBox();
			gbMembers = new GroupBox();
			flowLayoutPanel1 = new FlowLayoutPanel();
			btnAddMember = new Button();
			flpMembers = new FlowLayoutPanel();
			btnMemberTemplate = new Button();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvHouseholds).BeginInit();
			((System.ComponentModel.ISupportInitialize)bsHouseholds).BeginInit();
			tableLayoutPanel3.SuspendLayout();
			gbHousehold.SuspendLayout();
			flowLayoutPanel2.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			gbMembers.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			flpMembers.SuspendLayout();
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
			tableLayoutPanel1.Controls.Add(dgvHouseholds, 0, 1);
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
			// dgvHouseholds
			// 
			dgvHouseholds.AllowUserToResizeRows = false;
			dgvHouseholds.AutoGenerateColumns = false;
			dgvHouseholds.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvHouseholds.ColumnHeadersVisible = false;
			dgvHouseholds.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn });
			tableLayoutPanel1.SetColumnSpan(dgvHouseholds, 2);
			dgvHouseholds.DataSource = bsHouseholds;
			dgvHouseholds.Dock = DockStyle.Fill;
			dgvHouseholds.Location = new Point(3, 36);
			dgvHouseholds.MultiSelect = false;
			dgvHouseholds.Name = "dgvHouseholds";
			dgvHouseholds.ReadOnly = true;
			dgvHouseholds.RowHeadersVisible = false;
			dgvHouseholds.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvHouseholds.Size = new Size(327, 470);
			dgvHouseholds.TabIndex = 11;
			dgvHouseholds.SelectionChanged += dgvHouseholds_SelectionChanged;
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
			bsHouseholds.AllowNew = false;
			bsHouseholds.DataSource = typeof(Models.Household);
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 1;
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel3.Controls.Add(gbHousehold, 0, 0);
			tableLayoutPanel3.Controls.Add(gbMembers, 0, 1);
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
			// gbHousehold
			// 
			gbHousehold.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			gbHousehold.Controls.Add(flowLayoutPanel2);
			gbHousehold.Controls.Add(tableLayoutPanel2);
			gbHousehold.Font = new Font("Segoe UI", 11F);
			gbHousehold.Location = new Point(0, 3);
			gbHousehold.Margin = new Padding(0, 3, 3, 3);
			gbHousehold.Name = "gbHousehold";
			gbHousehold.Size = new Size(484, 186);
			gbHousehold.TabIndex = 0;
			gbHousehold.TabStop = false;
			gbHousehold.Text = "Household";
			// 
			// flowLayoutPanel2
			// 
			flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			flowLayoutPanel2.AutoSize = true;
			flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			flowLayoutPanel2.Controls.Add(btnNewHousehold);
			flowLayoutPanel2.Controls.Add(btnSave);
			flowLayoutPanel2.Controls.Add(btnRevert);
			flowLayoutPanel2.Location = new Point(172, 0);
			flowLayoutPanel2.Margin = new Padding(3, 3, 0, 3);
			flowLayoutPanel2.Name = "flowLayoutPanel2";
			flowLayoutPanel2.Size = new Size(309, 30);
			flowLayoutPanel2.TabIndex = 0;
			// 
			// btnNewHousehold
			// 
			btnNewHousehold.Location = new Point(0, 0);
			btnNewHousehold.Margin = new Padding(0, 0, 3, 0);
			btnNewHousehold.Name = "btnNewHousehold";
			btnNewHousehold.Size = new Size(100, 30);
			btnNewHousehold.TabIndex = 10;
			btnNewHousehold.Text = "New";
			btnNewHousehold.UseVisualStyleBackColor = true;
			btnNewHousehold.Click += btnNewHousehold_Click;
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
			tableLayoutPanel2.Controls.Add(label5, 0, 4);
			tableLayoutPanel2.Controls.Add(label6, 2, 4);
			tableLayoutPanel2.Controls.Add(tbState, 0, 5);
			tableLayoutPanel2.Controls.Add(tbZIP, 2, 5);
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
			tableLayoutPanel2.Size = new Size(478, 160);
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
			// label5
			// 
			label5.AutoSize = true;
			tableLayoutPanel2.SetColumnSpan(label5, 2);
			label5.Font = new Font("Segoe UI", 11F);
			label5.Location = new Point(3, 106);
			label5.Name = "label5";
			label5.Size = new Size(43, 20);
			label5.TabIndex = 6;
			label5.Text = "State";
			// 
			// label6
			// 
			label6.AutoSize = true;
			tableLayoutPanel2.SetColumnSpan(label6, 2);
			label6.Font = new Font("Segoe UI", 11F);
			label6.Location = new Point(161, 106);
			label6.Name = "label6";
			label6.Size = new Size(69, 20);
			label6.TabIndex = 8;
			label6.Text = "ZIP Code";
			// 
			// tbState
			// 
			tbState.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel2.SetColumnSpan(tbState, 2);
			tbState.Font = new Font("Segoe UI", 11F);
			tbState.Location = new Point(3, 129);
			tbState.Name = "tbState";
			tbState.PlaceholderText = "PA";
			tbState.Size = new Size(152, 27);
			tbState.TabIndex = 40;
			tbState.Text = "PA";
			// 
			// tbZIP
			// 
			tbZIP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel2.SetColumnSpan(tbZIP, 2);
			tbZIP.Font = new Font("Segoe UI", 11F);
			tbZIP.Location = new Point(161, 129);
			tbZIP.Name = "tbZIP";
			tbZIP.PlaceholderText = "17519";
			tbZIP.Size = new Size(152, 27);
			tbZIP.TabIndex = 50;
			// 
			// gbMembers
			// 
			gbMembers.Controls.Add(flowLayoutPanel1);
			gbMembers.Controls.Add(flpMembers);
			gbMembers.Dock = DockStyle.Fill;
			gbMembers.Location = new Point(0, 195);
			gbMembers.Margin = new Padding(0, 3, 3, 3);
			gbMembers.Name = "gbMembers";
			gbMembers.Size = new Size(484, 311);
			gbMembers.TabIndex = 1;
			gbMembers.TabStop = false;
			gbMembers.Text = "Members";
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			flowLayoutPanel1.AutoSize = true;
			flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			flowLayoutPanel1.Controls.Add(btnAddMember);
			flowLayoutPanel1.Location = new Point(378, 0);
			flowLayoutPanel1.Margin = new Padding(3, 3, 0, 3);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(103, 30);
			flowLayoutPanel1.TabIndex = 1;
			// 
			// btnAddMember
			// 
			btnAddMember.Location = new Point(0, 0);
			btnAddMember.Margin = new Padding(0, 0, 3, 0);
			btnAddMember.Name = "btnAddMember";
			btnAddMember.Size = new Size(100, 30);
			btnAddMember.TabIndex = 10;
			btnAddMember.Text = "Add";
			btnAddMember.UseVisualStyleBackColor = true;
			btnAddMember.Click += btnAddMember_Click;
			// 
			// flpMembers
			// 
			flpMembers.Controls.Add(btnMemberTemplate);
			flpMembers.Dock = DockStyle.Fill;
			flpMembers.FlowDirection = FlowDirection.TopDown;
			flpMembers.Location = new Point(3, 23);
			flpMembers.Name = "flpMembers";
			flpMembers.Size = new Size(478, 285);
			flpMembers.TabIndex = 0;
			// 
			// btnMemberTemplate
			// 
			btnMemberTemplate.AutoSize = true;
			btnMemberTemplate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnMemberTemplate.Location = new Point(3, 3);
			btnMemberTemplate.Name = "btnMemberTemplate";
			btnMemberTemplate.Padding = new Padding(12, 0, 12, 0);
			btnMemberTemplate.Size = new Size(78, 30);
			btnMemberTemplate.TabIndex = 0;
			btnMemberTemplate.Text = "Miles";
			btnMemberTemplate.UseVisualStyleBackColor = true;
			btnMemberTemplate.Visible = false;
			// 
			// frmHouseholds
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(243, 243, 243);
			ClientSize = new Size(832, 515);
			Controls.Add(splitContainer1);
			Font = new Font("Segoe UI", 11F);
			Margin = new Padding(4);
			Name = "frmHouseholds";
			Text = "Membership Office Manager";
			Shown += frmHouseholds_Shown;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvHouseholds).EndInit();
			((System.ComponentModel.ISupportInitialize)bsHouseholds).EndInit();
			tableLayoutPanel3.ResumeLayout(false);
			gbHousehold.ResumeLayout(false);
			gbHousehold.PerformLayout();
			flowLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			gbMembers.ResumeLayout(false);
			gbMembers.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			flpMembers.ResumeLayout(false);
			flpMembers.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private TableLayoutPanel tableLayoutPanel1;
		private TextBox tbSearch;
		private Label label1;
		private GroupBox gbHousehold;
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
		private TableLayoutPanel tableLayoutPanel3;
		private GroupBox gbMembers;
		private FlowLayoutPanel flpMembers;
		private FlowLayoutPanel flowLayoutPanel2;
		private Button btnSave;
		private Button btnRevert;
		private Button btnNewHousehold;
		private DataGridView dgvHouseholds;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private BindingSource bsHouseholds;
		private Button btnMemberTemplate;
		private FlowLayoutPanel flowLayoutPanel1;
		private Button btnAddMember;
	}
}
