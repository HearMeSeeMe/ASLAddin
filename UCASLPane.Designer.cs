
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
			this.btnProcessAll = new System.Windows.Forms.Button();
			this.lvSlide = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnProcessCurrent = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkAudio = new System.Windows.Forms.CheckBox();
			this.chkVideo = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
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
			// lvSlide
			// 
			this.lvSlide.BackColor = System.Drawing.SystemColors.Control;
			this.lvSlide.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvSlide.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.lvSlide.FullRowSelect = true;
			this.lvSlide.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvSlide.HideSelection = false;
			this.lvSlide.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
			this.lvSlide.Location = new System.Drawing.Point(4, 72);
			this.lvSlide.MultiSelect = false;
			this.lvSlide.Name = "lvSlide";
			this.lvSlide.Size = new System.Drawing.Size(189, 183);
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
			// btnProcessCurrent
			// 
			this.btnProcessCurrent.Location = new System.Drawing.Point(7, 10);
			this.btnProcessCurrent.Name = "btnProcessCurrent";
			this.btnProcessCurrent.Size = new System.Drawing.Size(134, 25);
			this.btnProcessCurrent.TabIndex = 13;
			this.btnProcessCurrent.Text = "Process Current Slide";
			this.btnProcessCurrent.UseVisualStyleBackColor = true;
			this.btnProcessCurrent.Click += new System.EventHandler(this.btnProcessCurrent_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkAudio);
			this.groupBox1.Controls.Add(this.chkVideo);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(0, 579);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(211, 96);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Automatic Play";
			// 
			// chkAudio
			// 
			this.chkAudio.AutoSize = true;
			this.chkAudio.Checked = true;
			this.chkAudio.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAudio.Location = new System.Drawing.Point(7, 58);
			this.chkAudio.Name = "chkAudio";
			this.chkAudio.Size = new System.Drawing.Size(53, 17);
			this.chkAudio.TabIndex = 1;
			this.chkAudio.Text = "Audio";
			this.chkAudio.UseVisualStyleBackColor = true;
			// 
			// chkVideo
			// 
			this.chkVideo.AutoSize = true;
			this.chkVideo.Checked = true;
			this.chkVideo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkVideo.Location = new System.Drawing.Point(7, 31);
			this.chkVideo.Name = "chkVideo";
			this.chkVideo.Size = new System.Drawing.Size(53, 17);
			this.chkVideo.TabIndex = 0;
			this.chkVideo.Text = "Video";
			this.chkVideo.UseVisualStyleBackColor = true;
			// 
			// UCASLPane
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnProcessCurrent);
			this.Controls.Add(this.lvSlide);
			this.Controls.Add(this.btnProcessAll);
			this.Name = "UCASLPane";
			this.Size = new System.Drawing.Size(211, 675);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnProcessAll;
		private System.Windows.Forms.ListView lvSlide;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button btnProcessCurrent;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkAudio;
		private System.Windows.Forms.CheckBox chkVideo;
	}
}
