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
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.volumeSlider = new System.Windows.Forms.TrackBar();
            this.seekBar = new System.Windows.Forms.TrackBar();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.albumCoverBox = new System.Windows.Forms.PictureBox();

            // 
            // playButton
            // 
            this.playButton.Text = "Play";
            this.playButton.Location = new System.Drawing.Point(10, 10);
            this.playButton.Click += new System.EventHandler(this.PlayButton_Click);

            // 
            // pauseButton
            // 
            this.pauseButton.Text = "Pause";
            this.pauseButton.Location = new System.Drawing.Point(90, 10);
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);

            // 
            // loadButton
            // 
            this.loadButton.Text = "Load MP3";
            this.loadButton.Location = new System.Drawing.Point(170, 10);
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);

            // 
            // volumeSlider
            // 
            this.volumeSlider.Location = new System.Drawing.Point(10, 50);
            this.volumeSlider.Width = 200;
            this.volumeSlider.Maximum = 100;
            this.volumeSlider.Value = 50;
            this.volumeSlider.Scroll += new System.EventHandler(this.VolumeSlider_Scroll);

            // 
            // seekBar
            // 
            this.seekBar.Location = new System.Drawing.Point(10, 90);
            this.seekBar.Width = 300;
            this.seekBar.Minimum = 0;
            this.seekBar.Maximum = 100;
            this.seekBar.Value = 0;
            this.seekBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SeekBar_MouseDown);
            this.seekBar.Scroll += new System.EventHandler(this.SeekBar_Scroll);


            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.Location = new System.Drawing.Point(320, 90);
            this.currentTimeLabel.Width = 50;
            this.currentTimeLabel.Text = "00:00";

            // 
            // durationLabel
            // 
            this.durationLabel.Location = new System.Drawing.Point(380, 90);
            this.durationLabel.Width = 50;
            this.durationLabel.Text = "00:00";

            // 
            // albumCoverBox
            // 
            this.albumCoverBox.Location = new System.Drawing.Point(450, 10);
            this.albumCoverBox.Size = new System.Drawing.Size(100, 100);
            this.albumCoverBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.albumCoverBox.Image = Properties.Resources.placeholder; // Заглушка, если нет обложки

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 150);
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
        }
    }
}
