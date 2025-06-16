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
			textBox1 = new TextBox();
			label2 = new Label();
			label3 = new Label();
			textBox2 = new TextBox();
			label1 = new Label();
			label4 = new Label();
			button1 = new Button();
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
			tableLayoutPanel1.Controls.Add(textBox1, 1, 1);
			tableLayoutPanel1.Controls.Add(label2, 1, 0);
			tableLayoutPanel1.Controls.Add(label3, 3, 0);
			tableLayoutPanel1.Controls.Add(textBox2, 3, 1);
			tableLayoutPanel1.Controls.Add(label1, 2, 0);
			tableLayoutPanel1.Controls.Add(label4, 4, 0);
			tableLayoutPanel1.Controls.Add(button1, 1, 2);
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
			// textBox1
			// 
			textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.SetColumnSpan(textBox1, 2);
			textBox1.Location = new Point(13, 29);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(221, 27);
			textBox1.TabIndex = 0;
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
			// textBox2
			// 
			textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.SetColumnSpan(textBox2, 2);
			textBox2.Location = new Point(240, 29);
			textBox2.Name = "textBox2";
			textBox2.PasswordChar = '*';
			textBox2.Size = new Size(216, 27);
			textBox2.TabIndex = 1;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label1.AutoSize = true;
			label1.ForeColor = Color.Red;
			label1.Location = new Point(94, 3);
			label1.Margin = new Padding(3);
			label1.Name = "label1";
			label1.Size = new Size(94, 20);
			label1.TabIndex = 4;
			label1.Text = "<not found>";
			label1.Visible = false;
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label4.AutoSize = true;
			label4.ForeColor = Color.Red;
			label4.Location = new Point(316, 3);
			label4.Margin = new Padding(3);
			label4.Name = "label4";
			label4.Size = new Size(73, 20);
			label4.TabIndex = 5;
			label4.Text = "<invalid>";
			label4.Visible = false;
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.SetColumnSpan(button1, 4);
			button1.Location = new Point(13, 62);
			button1.Name = "button1";
			button1.Size = new Size(443, 30);
			button1.TabIndex = 6;
			button1.Text = "Login";
			button1.UseVisualStyleBackColor = true;
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
			Name = "frmLogin";
			Text = "Membership Office Manager";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private TableLayoutPanel tableLayoutPanel1;
		private TextBox textBox2;
		private TextBox textBox1;
		private Label label2;
		private Label label3;
		private Label label1;
		private Label label4;
		private Button button1;
	}
}