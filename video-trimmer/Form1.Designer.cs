namespace video_trimmer
{
    partial class VideoTrimmerForm
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
            this.videoView = new LibVLCSharp.WinForms.VideoView();
            this.videoView2 = new LibVLCSharp.WinForms.VideoView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.DirectoryLabel = new System.Windows.Forms.Label();
            this.StatsLabel = new System.Windows.Forms.Label();
            this.QueueButton = new System.Windows.Forms.Button();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.EndTrimLabel = new System.Windows.Forms.Label();
            this.StartTrimLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // videoView
            // 
            this.videoView.BackColor = System.Drawing.Color.Black;
            this.videoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoView.Location = new System.Drawing.Point(0, 0);
            this.videoView.Margin = new System.Windows.Forms.Padding(1);
            this.videoView.MediaPlayer = null;
            this.videoView.Name = "videoView";
            this.videoView.Size = new System.Drawing.Size(282, 214);
            this.videoView.TabIndex = 0;
            this.videoView.Text = "videoView2";
            // 
            // videoView2
            // 
            this.videoView2.BackColor = System.Drawing.Color.Black;
            this.videoView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoView2.Location = new System.Drawing.Point(0, 0);
            this.videoView2.Margin = new System.Windows.Forms.Padding(1);
            this.videoView2.MediaPlayer = null;
            this.videoView2.Name = "videoView2";
            this.videoView2.Size = new System.Drawing.Size(260, 214);
            this.videoView2.TabIndex = 1;
            this.videoView2.Text = "videoView3";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(236, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.videoView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.videoView2);
            this.splitContainer1.Size = new System.Drawing.Size(543, 214);
            this.splitContainer1.SplitterDistance = 282;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "Select Directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SelectDirectoryButton_Click);
            // 
            // DirectoryLabel
            // 
            this.DirectoryLabel.AutoSize = true;
            this.DirectoryLabel.Location = new System.Drawing.Point(8, 26);
            this.DirectoryLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.DirectoryLabel.Name = "DirectoryLabel";
            this.DirectoryLabel.Size = new System.Drawing.Size(102, 15);
            this.DirectoryLabel.TabIndex = 4;
            this.DirectoryLabel.Text = "Selected Directory";
            // 
            // StatsLabel
            // 
            this.StatsLabel.AutoSize = true;
            this.StatsLabel.Location = new System.Drawing.Point(8, 220);
            this.StatsLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.StatsLabel.Name = "StatsLabel";
            this.StatsLabel.Size = new System.Drawing.Size(32, 15);
            this.StatsLabel.TabIndex = 5;
            this.StatsLabel.Text = "Stats";
            // 
            // QueueButton
            // 
            this.QueueButton.Location = new System.Drawing.Point(236, 283);
            this.QueueButton.Margin = new System.Windows.Forms.Padding(1);
            this.QueueButton.Name = "QueueButton";
            this.QueueButton.Size = new System.Drawing.Size(79, 22);
            this.QueueButton.TabIndex = 6;
            this.QueueButton.Text = "Queue Job";
            this.QueueButton.UseVisualStyleBackColor = true;
            this.QueueButton.Click += new System.EventHandler(this.QueueJobButton_Click);
            // 
            // FileListBox
            // 
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.ItemHeight = 15;
            this.FileListBox.Location = new System.Drawing.Point(8, 66);
            this.FileListBox.Margin = new System.Windows.Forms.Padding(1);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.Size = new System.Drawing.Size(161, 154);
            this.FileListBox.TabIndex = 7;
            this.FileListBox.SelectedIndexChanged += new System.EventHandler(this.FileListBox_SelectedIndexChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(236, 220);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(1);
            this.trackBar1.Maximum = 600;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(282, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Value = 60;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(520, 220);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(1);
            this.trackBar2.Maximum = 0;
            this.trackBar2.Minimum = -600;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(259, 45);
            this.trackBar2.TabIndex = 9;
            this.trackBar2.Value = -200;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 287);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Jobs: 0";
            // 
            // EndTrimLabel
            // 
            this.EndTrimLabel.AutoSize = true;
            this.EndTrimLabel.Location = new System.Drawing.Point(705, 256);
            this.EndTrimLabel.Name = "EndTrimLabel";
            this.EndTrimLabel.Size = new System.Drawing.Size(101, 15);
            this.EndTrimLabel.TabIndex = 11;
            this.EndTrimLabel.Text = "End Trim: 00:00:00";
            // 
            // StartTrimLabel
            // 
            this.StartTrimLabel.AutoSize = true;
            this.StartTrimLabel.Location = new System.Drawing.Point(236, 256);
            this.StartTrimLabel.Name = "StartTrimLabel";
            this.StartTrimLabel.Size = new System.Drawing.Size(105, 15);
            this.StartTrimLabel.TabIndex = 12;
            this.StartTrimLabel.Text = "Start Trim: 00:01:00";
            // 
            // VideoTrimmerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 314);
            this.Controls.Add(this.StartTrimLabel);
            this.Controls.Add(this.EndTrimLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.FileListBox);
            this.Controls.Add(this.QueueButton);
            this.Controls.Add(this.StatsLabel);
            this.Controls.Add(this.DirectoryLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "VideoTrimmerForm";
            this.Text = "Video Trimmer";
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LibVLCSharp.WinForms.VideoView videoView1;
        private LibVLCSharp.WinForms.VideoView videoView;
        private LibVLCSharp.WinForms.VideoView videoView2;
        private SplitContainer splitContainer1;
        private Button button1;
        private Label DirectoryLabel;
        private Label StatsLabel;
        private Button QueueButton;
        private ListBox FileListBox;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private Label label1;
        private Label EndTrimLabel;
        private Label StartTrimLabel;
    }
}