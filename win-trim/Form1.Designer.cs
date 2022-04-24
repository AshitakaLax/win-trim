namespace win_trim
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DirectoryButton = new System.Windows.Forms.Button();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.StatsLabel = new System.Windows.Forms.Label();
            this.player2 = new AxWMPLib.AxWindowsMediaPlayer();
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.QueueButton = new System.Windows.Forms.Button();
            this.DirectoryLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DirectoryButton
            // 
            this.DirectoryButton.Location = new System.Drawing.Point(38, 37);
            this.DirectoryButton.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.DirectoryButton.Name = "DirectoryButton";
            this.DirectoryButton.Size = new System.Drawing.Size(367, 65);
            this.DirectoryButton.TabIndex = 2;
            this.DirectoryButton.Text = "Select Directory";
            this.DirectoryButton.UseVisualStyleBackColor = true;
            this.DirectoryButton.Click += new System.EventHandler(this.DirectoryButton_Click);
            // 
            // FileListBox
            // 
            this.FileListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.ItemHeight = 37;
            this.FileListBox.Location = new System.Drawing.Point(38, 218);
            this.FileListBox.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.Size = new System.Drawing.Size(536, 189);
            this.FileListBox.TabIndex = 3;
            this.FileListBox.SelectedIndexChanged += new System.EventHandler(this.FileListBox_SelectedIndexChanged);
            // 
            // StatsLabel
            // 
            this.StatsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatsLabel.AutoSize = true;
            this.StatsLabel.Location = new System.Drawing.Point(41, 451);
            this.StatsLabel.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.StatsLabel.Name = "StatsLabel";
            this.StatsLabel.Size = new System.Drawing.Size(90, 37);
            this.StatsLabel.TabIndex = 4;
            this.StatsLabel.Text = "Stats";
            // 
            // player2
            // 
            this.player2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player2.Enabled = true;
            this.player2.Location = new System.Drawing.Point(0, 0);
            this.player2.Name = "player2";
            this.player2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player2.OcxState")));
            this.player2.Size = new System.Drawing.Size(425, 416);
            this.player2.TabIndex = 1;
            // 
            // player
            // 
            this.player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(0, 0);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(413, 416);
            this.player.TabIndex = 0;
            this.player.KeyPressEvent += new AxWMPLib._WMPOCXEvents_KeyPressEventHandler(this.player_KeyPressEvent);
            // 
            // QueueButton
            // 
            this.QueueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.QueueButton.Location = new System.Drawing.Point(602, 455);
            this.QueueButton.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.QueueButton.Name = "QueueButton";
            this.QueueButton.Size = new System.Drawing.Size(367, 65);
            this.QueueButton.TabIndex = 5;
            this.QueueButton.Text = "Queue Job";
            this.QueueButton.UseVisualStyleBackColor = true;
            this.QueueButton.Click += new System.EventHandler(this.QueueButton_Click);
            // 
            // DirectoryLabel
            // 
            this.DirectoryLabel.AutoSize = true;
            this.DirectoryLabel.Location = new System.Drawing.Point(38, 115);
            this.DirectoryLabel.Name = "DirectoryLabel";
            this.DirectoryLabel.Size = new System.Drawing.Size(275, 37);
            this.DirectoryLabel.TabIndex = 6;
            this.DirectoryLabel.Text = "Selected Directory";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(602, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.player);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.player2);
            this.splitContainer1.Size = new System.Drawing.Size(842, 416);
            this.splitContainer1.SplitterDistance = 413;
            this.splitContainer1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 555);
            this.Controls.Add(this.DirectoryLabel);
            this.Controls.Add(this.QueueButton);
            this.Controls.Add(this.StatsLabel);
            this.Controls.Add(this.FileListBox);
            this.Controls.Add(this.DirectoryButton);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.player2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer player;
        private AxWMPLib.AxWindowsMediaPlayer player2;
        private System.Windows.Forms.Button DirectoryButton;
        private System.Windows.Forms.ListBox FileListBox;
        private System.Windows.Forms.Label StatsLabel;
        private System.Windows.Forms.Button QueueButton;
        private System.Windows.Forms.Label DirectoryLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

