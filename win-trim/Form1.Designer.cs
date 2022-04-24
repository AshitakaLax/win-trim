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
            ((System.ComponentModel.ISupportInitialize)(this.player2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // DirectoryButton
            // 
            this.DirectoryButton.Location = new System.Drawing.Point(12, 13);
            this.DirectoryButton.Name = "DirectoryButton";
            this.DirectoryButton.Size = new System.Drawing.Size(116, 23);
            this.DirectoryButton.TabIndex = 2;
            this.DirectoryButton.Text = "Select Directory";
            this.DirectoryButton.UseVisualStyleBackColor = true;
            this.DirectoryButton.Click += new System.EventHandler(this.DirectoryButton_Click);
            // 
            // FileListBox
            // 
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.Location = new System.Drawing.Point(12, 54);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.Size = new System.Drawing.Size(120, 264);
            this.FileListBox.TabIndex = 3;
            this.FileListBox.SelectedIndexChanged += new System.EventHandler(this.FileListBox_SelectedIndexChanged);
            // 
            // StatsLabel
            // 
            this.StatsLabel.AutoSize = true;
            this.StatsLabel.Location = new System.Drawing.Point(13, 325);
            this.StatsLabel.Name = "StatsLabel";
            this.StatsLabel.Size = new System.Drawing.Size(31, 13);
            this.StatsLabel.TabIndex = 4;
            this.StatsLabel.Text = "Stats";
            // 
            // player2
            // 
            this.player2.Enabled = true;
            this.player2.Location = new System.Drawing.Point(537, -1);
            this.player2.Margin = new System.Windows.Forms.Padding(1);
            this.player2.Name = "player2";
            this.player2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player2.OcxState")));
            this.player2.Size = new System.Drawing.Size(375, 326);
            this.player2.TabIndex = 1;
            // 
            // player
            // 
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(160, -1);
            this.player.Margin = new System.Windows.Forms.Padding(1);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(375, 326);
            this.player.TabIndex = 0;
            this.player.KeyPressEvent += new AxWMPLib._WMPOCXEvents_KeyPressEventHandler(this.player_KeyPressEvent);
            // 
            // QueueButton
            // 
            this.QueueButton.Location = new System.Drawing.Point(160, 329);
            this.QueueButton.Name = "QueueButton";
            this.QueueButton.Size = new System.Drawing.Size(116, 23);
            this.QueueButton.TabIndex = 5;
            this.QueueButton.Text = "Queue Job";
            this.QueueButton.UseVisualStyleBackColor = true;
            this.QueueButton.Click += new System.EventHandler(this.QueueButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 392);
            this.Controls.Add(this.QueueButton);
            this.Controls.Add(this.StatsLabel);
            this.Controls.Add(this.FileListBox);
            this.Controls.Add(this.DirectoryButton);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.player2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
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
    }
}

