using System.Drawing;
using System.Windows.Forms;
using System;

namespace ZovMusic
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TrackBar volumeSlider;
        private System.Windows.Forms.TrackBar seekBar;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.PictureBox albumCoverBox;
        private System.Windows.Forms.Label trackTitleLabel;
        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.Button repeatButton;
        private bool isRepeatEnabled = false; // Флаг для режима повтора
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
            this.pauseButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.volumeSlider = new System.Windows.Forms.TrackBar();
            this.seekBar = new System.Windows.Forms.TrackBar();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.albumCoverBox = new System.Windows.Forms.PictureBox();
            this.repeatButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seekBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumCoverBox)).BeginInit();
            this.SuspendLayout();
            // 
            // trackTitleLabel
            // 
            this.trackTitleLabel.AutoSize = true;
            this.trackTitleLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackTitleLabel.Location = new System.Drawing.Point(22, 214);
            this.trackTitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.trackTitleLabel.Name = "trackTitleLabel";
            this.trackTitleLabel.Size = new System.Drawing.Size(41, 19);
            this.trackTitleLabel.TabIndex = 0;
            this.trackTitleLabel.Text = "Title";
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistLabel.Location = new System.Drawing.Point(22, 233);
            this.artistLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(39, 16);
            this.artistLabel.TabIndex = 1;
            this.artistLabel.Text = "Artist";
            // 
            // pauseButton
            // 
            this.pauseButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.pauseButton.Location = new System.Drawing.Point(116, 296);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(2);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(87, 57);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Pause";
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(11, 331);
            this.loadButton.Margin = new System.Windows.Forms.Padding(2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(87, 22);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load MP3";
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // volumeSlider
            // 
            this.volumeSlider.Location = new System.Drawing.Point(231, 308);
            this.volumeSlider.Margin = new System.Windows.Forms.Padding(2);
            this.volumeSlider.Maximum = 100;
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(90, 45);
            this.volumeSlider.TabIndex = 3;
            this.volumeSlider.Value = 50;
            this.volumeSlider.Scroll += new System.EventHandler(this.VolumeSlider_Scroll);
            // 
            // seekBar
            // 
            this.seekBar.Location = new System.Drawing.Point(53, 259);
            this.seekBar.Margin = new System.Windows.Forms.Padding(2);
            this.seekBar.Maximum = 100;
            this.seekBar.Name = "seekBar";
            this.seekBar.Size = new System.Drawing.Size(244, 45);
            this.seekBar.TabIndex = 4;
            this.seekBar.Scroll += new System.EventHandler(this.SeekBar_Scroll);
            this.seekBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SeekBar_MouseDown);
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.Location = new System.Drawing.Point(12, 263);
            this.currentTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(37, 20);
            this.currentTimeLabel.TabIndex = 5;
            this.currentTimeLabel.Text = "00:00";
            this.currentTimeLabel.Click += new System.EventHandler(this.currentTimeLabel_Click);
            // 
            // durationLabel
            // 
            this.durationLabel.Location = new System.Drawing.Point(288, 263);
            this.durationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(34, 17);
            this.durationLabel.TabIndex = 6;
            this.durationLabel.Text = "00:00";
            // 
            // albumCoverBox
            // 
            this.albumCoverBox.Image = global::ZovMusic.Properties.Resources.placeholder;
            this.albumCoverBox.Location = new System.Drawing.Point(62, 11);
            this.albumCoverBox.Margin = new System.Windows.Forms.Padding(2);
            this.albumCoverBox.Name = "albumCoverBox";
            this.albumCoverBox.Size = new System.Drawing.Size(196, 184);
            this.albumCoverBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.albumCoverBox.TabIndex = 7;
            this.albumCoverBox.TabStop = false;
            // 
            // repeatButton
            // 
            this.repeatButton.BackColor = System.Drawing.Color.LightGray;
            this.repeatButton.FlatAppearance.BorderSize = 0;
            this.repeatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.repeatButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.repeatButton.Location = new System.Drawing.Point(11, 296);
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(87, 30);
            this.repeatButton.TabIndex = 0;
            this.repeatButton.Text = "Repeat Off";
            this.repeatButton.UseVisualStyleBackColor = false;
            this.repeatButton.Click += new System.EventHandler(this.RepeatButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 364);
            this.Controls.Add(this.repeatButton);
            this.Controls.Add(this.trackTitleLabel);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.volumeSlider);
            this.Controls.Add(this.seekBar);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.albumCoverBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
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
