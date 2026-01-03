using MOM.Controls;

namespace MOM.Forms
{
	partial class frmIndividual
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndividual));
			gbName = new GroupBox();
			tableLayoutPanel1 = new TableLayoutPanel();
			llPreferFirstName = new LinkLabel();
			tbLastName = new AutoCompleteTextBox();
			tbMiddleName = new TextBox();
			label3 = new Label();
			tbFirstName = new TextBox();
			label1 = new Label();
			label2 = new Label();
			tbPreferredName = new TextBox();
			label18 = new Label();
			llPreferMiddleName = new LinkLabel();
			flowLayoutPanel2 = new FlowLayoutPanel();
			btnOK = new Button();
			btnCancel = new Button();
			gbContact = new GroupBox();
			tableLayoutPanel2 = new TableLayoutPanel();
			label17 = new Label();
			tbHomePhone = new MaskedTextBox();
			label6 = new Label();
			label5 = new Label();
			tbEmail = new TextBox();
			tbMobilePhone = new MaskedTextBox();
			label4 = new Label();
			tbCommunicationPreference = new AutoCompleteTextBox();
			tableLayoutPanel3 = new TableLayoutPanel();
			flowLayoutPanel1 = new FlowLayoutPanel();
			cbChild = new CheckBox();
			cbActive = new CheckBox();
			gbLife = new GroupBox();
			tableLayoutPanel5 = new TableLayoutPanel();
			tbMarriageDate = new DateTimeTextBox();
			tbMaritalStatus = new AutoCompleteTextBox();
			label16 = new Label();
			label15 = new Label();
			tbJoinedMethod = new AutoCompleteTextBox();
			label11 = new Label();
			label12 = new Label();
			tbJoinedDate = new DateTimeTextBox();
			label13 = new Label();
			label14 = new Label();
			tbBaptismLocation = new AutoCompleteTextBox();
			tbBaptismDate = new DateTimeTextBox();
			gbPersonal = new GroupBox();
			tableLayoutPanel4 = new TableLayoutPanel();
			tbOccupation = new AutoCompleteTextBox();
			label8 = new Label();
			label9 = new Label();
			tbEmployer = new AutoCompleteTextBox();
			label7 = new Label();
			label10 = new Label();
			tbBirthDate = new DateTimeTextBox();
			tbGender = new AutoCompleteTextBox();
			toolTip1 = new ToolTip(components);
			gbName.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			flowLayoutPanel2.SuspendLayout();
			gbContact.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			gbLife.SuspendLayout();
			tableLayoutPanel5.SuspendLayout();
			gbPersonal.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			SuspendLayout();
			// 
			// gbName
			// 
			gbName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel3.SetColumnSpan(gbName, 2);
			gbName.Controls.Add(tableLayoutPanel1);
			gbName.Location = new Point(3, 3);
			gbName.Name = "gbName";
			gbName.Size = new Size(908, 133);
			gbName.TabIndex = 10;
			gbName.TabStop = false;
			gbName.Text = "Name";
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 5;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
			tableLayoutPanel1.Controls.Add(llPreferFirstName, 1, 0);
			tableLayoutPanel1.Controls.Add(tbLastName, 4, 1);
			tableLayoutPanel1.Controls.Add(tbMiddleName, 2, 1);
			tableLayoutPanel1.Controls.Add(label3, 4, 0);
			tableLayoutPanel1.Controls.Add(tbFirstName, 0, 1);
			tableLayoutPanel1.Controls.Add(label1, 0, 0);
			tableLayoutPanel1.Controls.Add(label2, 2, 0);
			tableLayoutPanel1.Controls.Add(tbPreferredName, 0, 3);
			tableLayoutPanel1.Controls.Add(label18, 0, 2);
			tableLayoutPanel1.Controls.Add(llPreferMiddleName, 3, 0);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(3, 23);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 5;
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new Size(902, 107);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// llPreferFirstName
			// 
			llPreferFirstName.AutoSize = true;
			llPreferFirstName.Location = new Point(42, 0);
			llPreferFirstName.Margin = new Padding(0, 0, 3, 0);
			llPreferFirstName.Name = "llPreferFirstName";
			llPreferFirstName.Size = new Size(59, 20);
			llPreferFirstName.TabIndex = 15;
			llPreferFirstName.Text = "(prefer)";
			llPreferFirstName.LinkClicked += llPreferFirstName_LinkClicked;
			// 
			// tbLastName
			// 
			tbLastName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbLastName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			tbLastName.Location = new Point(617, 23);
			tbLastName.Name = "tbLastName";
			tbLastName.Size = new Size(282, 27);
			tbLastName.TabIndex = 30;
			// 
			// tbMiddleName
			// 
			tbMiddleName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.SetColumnSpan(tbMiddleName, 2);
			tbMiddleName.Location = new Point(300, 23);
			tbMiddleName.Name = "tbMiddleName";
			tbMiddleName.Size = new Size(311, 27);
			tbMiddleName.TabIndex = 20;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(617, 0);
			label3.Name = "label3";
			label3.Size = new Size(35, 20);
			label3.TabIndex = 4;
			label3.Text = "Last";
			// 
			// tbFirstName
			// 
			tbFirstName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.SetColumnSpan(tbFirstName, 2);
			tbFirstName.Location = new Point(3, 23);
			tbFirstName.Name = "tbFirstName";
			tbFirstName.Size = new Size(291, 27);
			tbFirstName.TabIndex = 10;
			tbFirstName.TextChanged += tbFirstName_TextChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(3, 0);
			label1.Name = "label1";
			label1.Size = new Size(36, 20);
			label1.TabIndex = 2;
			label1.Text = "First";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(300, 0);
			label2.Name = "label2";
			label2.Size = new Size(56, 20);
			label2.TabIndex = 3;
			label2.Text = "Middle";
			// 
			// tbPreferredName
			// 
			tbPreferredName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.SetColumnSpan(tbPreferredName, 2);
			tbPreferredName.Location = new Point(3, 76);
			tbPreferredName.Name = "tbPreferredName";
			tbPreferredName.Size = new Size(291, 27);
			tbPreferredName.TabIndex = 32;
			// 
			// label18
			// 
			label18.AutoSize = true;
			tableLayoutPanel1.SetColumnSpan(label18, 2);
			label18.Location = new Point(3, 53);
			label18.Name = "label18";
			label18.Size = new Size(70, 20);
			label18.TabIndex = 31;
			label18.Text = "Preferred";
			// 
			// llPreferMiddleName
			// 
			llPreferMiddleName.AutoSize = true;
			llPreferMiddleName.Location = new Point(359, 0);
			llPreferMiddleName.Margin = new Padding(0, 0, 3, 0);
			llPreferMiddleName.Name = "llPreferMiddleName";
			llPreferMiddleName.Size = new Size(59, 20);
			llPreferMiddleName.TabIndex = 25;
			llPreferMiddleName.Text = "(prefer)";
			llPreferMiddleName.LinkClicked += llPreferMiddleName_LinkClicked;
			// 
			// flowLayoutPanel2
			// 
			flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			flowLayoutPanel2.AutoSize = true;
			flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			flowLayoutPanel2.Controls.Add(btnOK);
			flowLayoutPanel2.Controls.Add(btnCancel);
			flowLayoutPanel2.Location = new Point(702, 0);
			flowLayoutPanel2.Margin = new Padding(3, 3, 0, 3);
			flowLayoutPanel2.Name = "flowLayoutPanel2";
			flowLayoutPanel2.Size = new Size(203, 30);
			flowLayoutPanel2.TabIndex = 100;
			// 
			// btnOK
			// 
			btnOK.Location = new Point(0, 0);
			btnOK.Margin = new Padding(0, 0, 3, 0);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(100, 30);
			btnOK.TabIndex = 20;
			btnOK.Text = "OK";
			toolTip1.SetToolTip(btnOK, "Ctrl+Enter\r\nCtrl+Space");
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += btnSave_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(103, 0);
			btnCancel.Margin = new Padding(0);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(100, 30);
			btnCancel.TabIndex = 30;
			btnCancel.Text = "Cancel";
			toolTip1.SetToolTip(btnCancel, "Ctrl+W");
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// gbContact
			// 
			gbContact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			gbContact.Controls.Add(tableLayoutPanel2);
			gbContact.Location = new Point(3, 142);
			gbContact.Name = "gbContact";
			gbContact.Size = new Size(451, 133);
			gbContact.TabIndex = 20;
			gbContact.TabStop = false;
			gbContact.Text = "Contact";
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 3;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
			tableLayoutPanel2.Controls.Add(label17, 0, 2);
			tableLayoutPanel2.Controls.Add(tbHomePhone, 0, 3);
			tableLayoutPanel2.Controls.Add(label6, 1, 0);
			tableLayoutPanel2.Controls.Add(label5, 0, 0);
			tableLayoutPanel2.Controls.Add(tbEmail, 1, 1);
			tableLayoutPanel2.Controls.Add(tbMobilePhone, 0, 1);
			tableLayoutPanel2.Controls.Add(label4, 1, 2);
			tableLayoutPanel2.Controls.Add(tbCommunicationPreference, 1, 3);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(3, 23);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 5;
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.Size = new Size(445, 107);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Location = new Point(3, 53);
			label17.Name = "label17";
			label17.Size = new Size(95, 20);
			label17.TabIndex = 73;
			label17.Text = "Home Phone";
			// 
			// tbHomePhone
			// 
			tbHomePhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbHomePhone.Location = new Point(3, 76);
			tbHomePhone.Mask = "(999) 000-0000";
			tbHomePhone.Name = "tbHomePhone";
			tbHomePhone.Size = new Size(142, 27);
			tbHomePhone.TabIndex = 30;
			tbHomePhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
			// 
			// label6
			// 
			label6.AutoSize = true;
			tableLayoutPanel2.SetColumnSpan(label6, 2);
			label6.Location = new Point(151, 0);
			label6.Name = "label6";
			label6.Size = new Size(46, 20);
			label6.TabIndex = 3;
			label6.Text = "Email";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(3, 0);
			label5.Name = "label5";
			label5.Size = new Size(101, 20);
			label5.TabIndex = 2;
			label5.Text = "Mobile Phone";
			// 
			// tbEmail
			// 
			tbEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel2.SetColumnSpan(tbEmail, 2);
			tbEmail.Location = new Point(151, 23);
			tbEmail.Name = "tbEmail";
			tbEmail.Size = new Size(291, 27);
			tbEmail.TabIndex = 20;
			// 
			// tbMobilePhone
			// 
			tbMobilePhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbMobilePhone.Location = new Point(3, 23);
			tbMobilePhone.Mask = "(999) 000-0000";
			tbMobilePhone.Name = "tbMobilePhone";
			tbMobilePhone.Size = new Size(142, 27);
			tbMobilePhone.TabIndex = 10;
			tbMobilePhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
			// 
			// label4
			// 
			label4.AutoSize = true;
			tableLayoutPanel2.SetColumnSpan(label4, 2);
			label4.Location = new Point(151, 53);
			label4.Name = "label4";
			label4.Size = new Size(189, 20);
			label4.TabIndex = 72;
			label4.Text = "Communication preference";
			// 
			// tbCommunicationPreference
			// 
			tbCommunicationPreference.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbCommunicationPreference.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			tableLayoutPanel2.SetColumnSpan(tbCommunicationPreference, 2);
			tbCommunicationPreference.Location = new Point(151, 76);
			tbCommunicationPreference.Name = "tbCommunicationPreference";
			tbCommunicationPreference.Size = new Size(291, 27);
			tbCommunicationPreference.TabIndex = 40;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 2;
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel3.Controls.Add(flowLayoutPanel1, 1, 2);
			tableLayoutPanel3.Controls.Add(gbName, 0, 0);
			tableLayoutPanel3.Controls.Add(gbLife, 0, 2);
			tableLayoutPanel3.Controls.Add(gbPersonal, 1, 1);
			tableLayoutPanel3.Controls.Add(gbContact, 0, 1);
			tableLayoutPanel3.Dock = DockStyle.Fill;
			tableLayoutPanel3.Location = new Point(0, 0);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 4;
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel3.Size = new Size(914, 471);
			tableLayoutPanel3.TabIndex = 2;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			flowLayoutPanel1.AutoSize = true;
			flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			flowLayoutPanel1.Controls.Add(cbChild);
			flowLayoutPanel1.Controls.Add(cbActive);
			flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
			flowLayoutPanel1.Location = new Point(836, 407);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(75, 60);
			flowLayoutPanel1.TabIndex = 50;
			// 
			// cbChild
			// 
			cbChild.AutoSize = true;
			cbChild.Location = new Point(3, 3);
			cbChild.Name = "cbChild";
			cbChild.Size = new Size(62, 24);
			cbChild.TabIndex = 10;
			cbChild.Text = "Child";
			cbChild.UseVisualStyleBackColor = true;
			// 
			// cbActive
			// 
			cbActive.AutoSize = true;
			cbActive.Location = new Point(3, 33);
			cbActive.Name = "cbActive";
			cbActive.Size = new Size(69, 24);
			cbActive.TabIndex = 20;
			cbActive.Text = "Active";
			cbActive.UseVisualStyleBackColor = true;
			// 
			// gbLife
			// 
			gbLife.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			gbLife.Controls.Add(tableLayoutPanel5);
			gbLife.Location = new Point(3, 281);
			gbLife.Name = "gbLife";
			gbLife.Size = new Size(451, 186);
			gbLife.TabIndex = 40;
			gbLife.TabStop = false;
			gbLife.Text = "Life";
			// 
			// tableLayoutPanel5
			// 
			tableLayoutPanel5.ColumnCount = 2;
			tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.99999F));
			tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000076F));
			tableLayoutPanel5.Controls.Add(tbMarriageDate, 1, 5);
			tableLayoutPanel5.Controls.Add(tbMaritalStatus, 0, 5);
			tableLayoutPanel5.Controls.Add(label16, 1, 4);
			tableLayoutPanel5.Controls.Add(label15, 0, 4);
			tableLayoutPanel5.Controls.Add(tbJoinedMethod, 0, 1);
			tableLayoutPanel5.Controls.Add(label11, 1, 0);
			tableLayoutPanel5.Controls.Add(label12, 0, 0);
			tableLayoutPanel5.Controls.Add(tbJoinedDate, 1, 1);
			tableLayoutPanel5.Controls.Add(label13, 1, 2);
			tableLayoutPanel5.Controls.Add(label14, 0, 2);
			tableLayoutPanel5.Controls.Add(tbBaptismLocation, 0, 3);
			tableLayoutPanel5.Controls.Add(tbBaptismDate, 1, 3);
			tableLayoutPanel5.Dock = DockStyle.Fill;
			tableLayoutPanel5.Location = new Point(3, 23);
			tableLayoutPanel5.Name = "tableLayoutPanel5";
			tableLayoutPanel5.RowCount = 7;
			tableLayoutPanel5.RowStyles.Add(new RowStyle());
			tableLayoutPanel5.RowStyles.Add(new RowStyle());
			tableLayoutPanel5.RowStyles.Add(new RowStyle());
			tableLayoutPanel5.RowStyles.Add(new RowStyle());
			tableLayoutPanel5.RowStyles.Add(new RowStyle());
			tableLayoutPanel5.RowStyles.Add(new RowStyle());
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel5.Size = new Size(445, 160);
			tableLayoutPanel5.TabIndex = 0;
			// 
			// tbMarriageDate
			// 
			tbMarriageDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbMarriageDate.Location = new Point(225, 129);
			tbMarriageDate.Mask = "90/90/9900";
			tbMarriageDate.Name = "tbMarriageDate";
			tbMarriageDate.Size = new Size(217, 27);
			tbMarriageDate.TabIndex = 60;
			tbMarriageDate.ValidatingType = typeof(DateTime);
			tbMarriageDate.Value = null;
			// 
			// tbMaritalStatus
			// 
			tbMaritalStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbMaritalStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			tbMaritalStatus.Location = new Point(3, 129);
			tbMaritalStatus.Name = "tbMaritalStatus";
			tbMaritalStatus.Size = new Size(216, 27);
			tbMaritalStatus.TabIndex = 50;
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Location = new Point(225, 106);
			label16.Name = "label16";
			label16.Size = new Size(103, 20);
			label16.TabIndex = 78;
			label16.Text = "Marriage date";
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Location = new Point(3, 106);
			label15.Name = "label15";
			label15.Size = new Size(98, 20);
			label15.TabIndex = 77;
			label15.Text = "Marital status";
			// 
			// tbJoinedMethod
			// 
			tbJoinedMethod.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbJoinedMethod.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			tbJoinedMethod.Location = new Point(3, 23);
			tbJoinedMethod.Name = "tbJoinedMethod";
			tbJoinedMethod.Size = new Size(216, 27);
			tbJoinedMethod.TabIndex = 10;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(225, 0);
			label11.Name = "label11";
			label11.Size = new Size(86, 20);
			label11.TabIndex = 3;
			label11.Text = "Joined date";
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(3, 0);
			label12.Name = "label12";
			label12.Size = new Size(108, 20);
			label12.TabIndex = 2;
			label12.Text = "Joined method";
			// 
			// tbJoinedDate
			// 
			tbJoinedDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbJoinedDate.Location = new Point(225, 23);
			tbJoinedDate.Mask = "90/90/9900";
			tbJoinedDate.Name = "tbJoinedDate";
			tbJoinedDate.Size = new Size(217, 27);
			tbJoinedDate.TabIndex = 20;
			tbJoinedDate.ValidatingType = typeof(DateTime);
			tbJoinedDate.Value = null;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new Point(225, 53);
			label13.Name = "label13";
			label13.Size = new Size(97, 20);
			label13.TabIndex = 72;
			label13.Text = "Baptism date";
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new Point(3, 53);
			label14.Name = "label14";
			label14.Size = new Size(121, 20);
			label14.TabIndex = 76;
			label14.Text = "Baptism location";
			// 
			// tbBaptismLocation
			// 
			tbBaptismLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbBaptismLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			tbBaptismLocation.Location = new Point(3, 76);
			tbBaptismLocation.Name = "tbBaptismLocation";
			tbBaptismLocation.Size = new Size(216, 27);
			tbBaptismLocation.TabIndex = 30;
			// 
			// tbBaptismDate
			// 
			tbBaptismDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbBaptismDate.Location = new Point(225, 76);
			tbBaptismDate.Mask = "90/90/9900";
			tbBaptismDate.Name = "tbBaptismDate";
			tbBaptismDate.Size = new Size(217, 27);
			tbBaptismDate.TabIndex = 40;
			tbBaptismDate.ValidatingType = typeof(DateTime);
			tbBaptismDate.Value = null;
			// 
			// gbPersonal
			// 
			gbPersonal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			gbPersonal.Controls.Add(tableLayoutPanel4);
			gbPersonal.Location = new Point(460, 142);
			gbPersonal.Name = "gbPersonal";
			gbPersonal.Size = new Size(451, 133);
			gbPersonal.TabIndex = 30;
			gbPersonal.TabStop = false;
			gbPersonal.Text = "Personal";
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.ColumnCount = 2;
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.9999924F));
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000038F));
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanel4.Controls.Add(tbOccupation, 0, 1);
			tableLayoutPanel4.Controls.Add(label8, 1, 0);
			tableLayoutPanel4.Controls.Add(label9, 0, 0);
			tableLayoutPanel4.Controls.Add(tbEmployer, 1, 1);
			tableLayoutPanel4.Controls.Add(label7, 1, 2);
			tableLayoutPanel4.Controls.Add(label10, 0, 2);
			tableLayoutPanel4.Controls.Add(tbBirthDate, 0, 3);
			tableLayoutPanel4.Controls.Add(tbGender, 1, 3);
			tableLayoutPanel4.Dock = DockStyle.Fill;
			tableLayoutPanel4.Location = new Point(3, 23);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 5;
			tableLayoutPanel4.RowStyles.Add(new RowStyle());
			tableLayoutPanel4.RowStyles.Add(new RowStyle());
			tableLayoutPanel4.RowStyles.Add(new RowStyle());
			tableLayoutPanel4.RowStyles.Add(new RowStyle());
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel4.Size = new Size(445, 107);
			tableLayoutPanel4.TabIndex = 0;
			// 
			// tbOccupation
			// 
			tbOccupation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbOccupation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			tbOccupation.Location = new Point(3, 23);
			tbOccupation.Name = "tbOccupation";
			tbOccupation.Size = new Size(216, 27);
			tbOccupation.TabIndex = 10;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(225, 0);
			label8.Name = "label8";
			label8.Size = new Size(72, 20);
			label8.TabIndex = 3;
			label8.Text = "Employer";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(3, 0);
			label9.Name = "label9";
			label9.Size = new Size(85, 20);
			label9.TabIndex = 2;
			label9.Text = "Occupation";
			// 
			// tbEmployer
			// 
			tbEmployer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbEmployer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			tbEmployer.Location = new Point(225, 23);
			tbEmployer.Name = "tbEmployer";
			tbEmployer.Size = new Size(217, 27);
			tbEmployer.TabIndex = 20;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(225, 53);
			label7.Name = "label7";
			label7.Size = new Size(57, 20);
			label7.TabIndex = 72;
			label7.Text = "Gender";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(3, 53);
			label10.Name = "label10";
			label10.Size = new Size(74, 20);
			label10.TabIndex = 76;
			label10.Text = "Birth date";
			// 
			// tbBirthDate
			// 
			tbBirthDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbBirthDate.Location = new Point(3, 76);
			tbBirthDate.Mask = "90/90/9900";
			tbBirthDate.Name = "tbBirthDate";
			tbBirthDate.Size = new Size(216, 27);
			tbBirthDate.TabIndex = 30;
			tbBirthDate.ValidatingType = typeof(DateTime);
			tbBirthDate.Value = null;
			// 
			// tbGender
			// 
			tbGender.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbGender.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			tbGender.Location = new Point(225, 76);
			tbGender.Name = "tbGender";
			tbGender.Size = new Size(217, 27);
			tbGender.TabIndex = 40;
			// 
			// frmIndividual
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(243, 243, 243);
			ClientSize = new Size(914, 471);
			Controls.Add(flowLayoutPanel2);
			Controls.Add(tableLayoutPanel3);
			Font = new Font("Segoe UI", 11F);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "frmIndividual";
			Text = "MOM - Individual";
			Shown += frmIndividual_Shown;
			gbName.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			flowLayoutPanel2.ResumeLayout(false);
			gbContact.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			gbLife.ResumeLayout(false);
			tableLayoutPanel5.ResumeLayout(false);
			tableLayoutPanel5.PerformLayout();
			gbPersonal.ResumeLayout(false);
			tableLayoutPanel4.ResumeLayout(false);
			tableLayoutPanel4.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox gbName;
		private TableLayoutPanel tableLayoutPanel1;
		private	TextBox tbFirstName;
		private Label label1;
		private Label label2;
		private Label label3;
		private AutoCompleteTextBox tbLastName;
		private TextBox tbMiddleName;
		private GroupBox gbContact;
		private TableLayoutPanel tableLayoutPanel2;
		private TextBox tbEmail;
		private Label label5;
		private Label label6;
		private TableLayoutPanel tableLayoutPanel3;
		private MaskedTextBox tbMobilePhone;
		private AutoCompleteTextBox tbCommunicationPreference;
		private Label label4;
		private GroupBox gbPersonal;
		private TableLayoutPanel tableLayoutPanel4;
		private Label label8;
		private Label label9;
		private AutoCompleteTextBox tbEmployer;
		private AutoCompleteTextBox tbGender;
		private Label label7;
		private Label label10;
		private AutoCompleteTextBox tbOccupation;
		private DateTimeTextBox tbBirthDate;
		private GroupBox gbLife;
		private TableLayoutPanel tableLayoutPanel5;
		private AutoCompleteTextBox tbJoinedMethod;
		private Label label11;
		private Label label12;
		private DateTimeTextBox tbJoinedDate;
		private Label label13;
		private Label label14;
		private AutoCompleteTextBox tbBaptismLocation;
		private DateTimeTextBox tbBaptismDate;
		private DateTimeTextBox tbMarriageDate;
		private AutoCompleteTextBox tbMaritalStatus;
		private Label label16;
		private Label label15;
		private FlowLayoutPanel flowLayoutPanel2;
		private Button btnOK;
		private Button btnCancel;
		private CheckBox cbActive;
		private Label label17;
		private MaskedTextBox tbHomePhone;
		private TextBox tbPreferredName;
		private Label label18;
		private LinkLabel llPreferMiddleName;
		private LinkLabel llPreferFirstName;
		private ToolTip toolTip1;
		private FlowLayoutPanel flowLayoutPanel1;
		private CheckBox cbChild;
	}
}