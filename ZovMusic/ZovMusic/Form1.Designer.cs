namespace ZovMusic
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TrackBar volumeSlider;
        private System.Windows.Forms.TrackBar seekBar;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.PictureBox albumCoverBox;
        private System.Windows.Forms.Label trackTitleLabel;
        private System.Windows.Forms.Label artistLabel;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.trackTitleLabel = new System.Windows.Forms.Label();
            this.artistLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.volumeSlider = new System.Windows.Forms.TrackBar();
            this.seekBar = new System.Windows.Forms.TrackBar();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.albumCoverBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seekBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumCoverBox)).BeginInit();
            this.SuspendLayout();
            // 
            // trackTitleLabel
            // 
            this.trackTitleLabel.AutoSize = true;
            this.trackTitleLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackTitleLabel.Location = new System.Drawing.Point(174, 398);
            this.trackTitleLabel.Name = "trackTitleLabel";
            this.trackTitleLabel.Size = new System.Drawing.Size(85, 37);
            this.trackTitleLabel.TabIndex = 0;
            this.trackTitleLabel.Text = "Title";
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistLabel.Location = new System.Drawing.Point(175, 435);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(77, 32);
            this.artistLabel.TabIndex = 1;
            this.artistLabel.Text = "Artist";
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(172, 584);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(87, 45);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play";
            this.playButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(284, 584);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(89, 45);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Pause";
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(44, 584);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(99, 45);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load MP3";
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // volumeSlider
            // 
            this.volumeSlider.Location = new System.Drawing.Point(587, 574);
            this.volumeSlider.Maximum = 100;
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(200, 90);
            this.volumeSlider.TabIndex = 3;
            this.volumeSlider.Value = 50;
            this.volumeSlider.Scroll += new System.EventHandler(this.VolumeSlider_Scroll);
            // 
            // seekBar
            // 
            this.seekBar.Location = new System.Drawing.Point(104, 478);
            this.seekBar.Maximum = 100;
            this.seekBar.Name = "seekBar";
            this.seekBar.Size = new System.Drawing.Size(546, 90);
            this.seekBar.TabIndex = 4;
            this.seekBar.Scroll += new System.EventHandler(this.SeekBar_Scroll);
            this.seekBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SeekBar_MouseDown);
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.Location = new System.Drawing.Point(39, 488);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(74, 39);
            this.currentTimeLabel.TabIndex = 5;
            this.currentTimeLabel.Text = "00:00";
            this.currentTimeLabel.Click += new System.EventHandler(this.currentTimeLabel_Click);
            // 
            // durationLabel
            // 
            this.durationLabel.Location = new System.Drawing.Point(668, 488);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(68, 33);
            this.durationLabel.TabIndex = 6;
            this.durationLabel.Text = "00:00";
            // 
            // albumCoverBox
            // 
            this.albumCoverBox.Image = global::ZovMusic.Properties.Resources.placeholder;
            this.albumCoverBox.Location = new System.Drawing.Point(181, 28);
            this.albumCoverBox.Name = "albumCoverBox";
            this.albumCoverBox.Size = new System.Drawing.Size(392, 354);
            this.albumCoverBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.albumCoverBox.TabIndex = 7;
            this.albumCoverBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 662);
            this.Controls.Add(this.trackTitleLabel);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.volumeSlider);
            this.Controls.Add(this.seekBar);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.albumCoverBox);
            this.Name = "Form1";
            this.Text = "Music Player";
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seekBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumCoverBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
