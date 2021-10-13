
namespace SignLanguageAssistant
{
	partial class UCASLPane
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Slide1",
            "completed",
            "aaa"}, 0);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Slide2",
            "need notepage"}, -1);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCASLPane));
			this.btnVoiceRec = new System.Windows.Forms.CheckBox();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.btnProcessAll = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.lvSlide = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.btnProcessCurrent = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnVoiceRec
			// 
			this.btnVoiceRec.Appearance = System.Windows.Forms.Appearance.Button;
			this.btnVoiceRec.AutoSize = true;
			this.btnVoiceRec.Location = new System.Drawing.Point(24, 292);
			this.btnVoiceRec.Name = "btnVoiceRec";
			this.btnVoiceRec.Size = new System.Drawing.Size(112, 23);
			this.btnVoiceRec.TabIndex = 2;
			this.btnVoiceRec.Text = "voice recognize test";
			this.btnVoiceRec.UseVisualStyleBackColor = true;
			this.btnVoiceRec.CheckedChanged += new System.EventHandler(this.btnVoiceRec_CheckedChanged);
			// 
			// txtResult
			// 
			this.txtResult.Location = new System.Drawing.Point(24, 322);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.txtResult.Size = new System.Drawing.Size(169, 176);
			this.txtResult.TabIndex = 3;
			// 
			// btnProcessAll
			// 
			this.btnProcessAll.AccessibleDescription = "";
			this.btnProcessAll.Location = new System.Drawing.Point(7, 41);
			this.btnProcessAll.Name = "btnProcessAll";
			this.btnProcessAll.Size = new System.Drawing.Size(110, 25);
			this.btnProcessAll.TabIndex = 6;
			this.btnProcessAll.Text = "Process All";
			this.btnProcessAll.UseVisualStyleBackColor = true;
			this.btnProcessAll.Click += new System.EventHandler(this.btnProcessAll_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(7, 72);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(162, 11);
			this.progressBar1.TabIndex = 7;
			this.progressBar1.Value = 30;
			// 
			// lvSlide
			// 
			this.lvSlide.BackColor = System.Drawing.SystemColors.Menu;
			this.lvSlide.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvSlide.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.lvSlide.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvSlide.HideSelection = false;
			this.lvSlide.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
			this.lvSlide.Location = new System.Drawing.Point(4, 89);
			this.lvSlide.Name = "lvSlide";
			this.lvSlide.Size = new System.Drawing.Size(189, 166);
			this.lvSlide.SmallImageList = this.imageList1;
			this.lvSlide.TabIndex = 9;
			this.lvSlide.UseCompatibleStateImageBehavior = false;
			this.lvSlide.View = System.Windows.Forms.View.Details;
			this.lvSlide.SelectedIndexChanged += new System.EventHandler(this.lvSlide_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Slide No.";
			this.columnHeader1.Width = 79;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Status";
			this.columnHeader2.Width = 100;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-check-64.png");
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(140, 292);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(64, 25);
			this.button2.TabIndex = 10;
			this.button2.Text = "video test";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(27, 261);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(64, 25);
			this.button3.TabIndex = 11;
			this.button3.Text = "speak";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(107, 261);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(64, 25);
			this.button4.TabIndex = 12;
			this.button4.Text = "text to sign";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// btnProcessCurrent
			// 
			this.btnProcessCurrent.Location = new System.Drawing.Point(7, 10);
			this.btnProcessCurrent.Name = "btnProcessCurrent";
			this.btnProcessCurrent.Size = new System.Drawing.Size(134, 25);
			this.btnProcessCurrent.TabIndex = 13;
			this.btnProcessCurrent.Text = "Process Current Slide";
			this.btnProcessCurrent.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(0, 579);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(211, 96);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Automatic Play";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(7, 58);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(53, 17);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Audio";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(7, 31);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(53, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Video";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// UCASLPane
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnProcessCurrent);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.lvSlide);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.btnProcessAll);
			this.Controls.Add(this.txtResult);
			this.Controls.Add(this.btnVoiceRec);
			this.Name = "UCASLPane";
			this.Size = new System.Drawing.Size(211, 675);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.CheckBox btnVoiceRec;
		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.Button btnProcessAll;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.ListView lvSlide;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button btnProcessCurrent;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}
