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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seekBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumCoverBox)).BeginInit();
            this.SuspendLayout();
            // 
            // trackTitleLabel
            // 
            this.trackTitleLabel.AutoSize = true;
            this.trackTitleLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackTitleLabel.Location = new System.Drawing.Point(44, 412);
            this.trackTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.trackTitleLabel.Name = "trackTitleLabel";
            this.trackTitleLabel.Size = new System.Drawing.Size(85, 37);
            this.trackTitleLabel.TabIndex = 0;
            this.trackTitleLabel.Text = "Title";
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistLabel.Location = new System.Drawing.Point(44, 448);
            this.artistLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(77, 32);
            this.artistLabel.TabIndex = 1;
            this.artistLabel.Text = "Artist";
            // 
            // pauseButton
            // 
            this.pauseButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.pauseButton.Location = new System.Drawing.Point(232, 569);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(174, 110);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Pause";
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(22, 637);
            this.loadButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(174, 42);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load MP3";
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // volumeSlider
            // 
            this.volumeSlider.Location = new System.Drawing.Point(464, 608);
            this.volumeSlider.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.volumeSlider.Maximum = 100;
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(180, 90);
            this.volumeSlider.TabIndex = 3;
            this.volumeSlider.Value = 50;
            this.volumeSlider.Scroll += new System.EventHandler(this.VolumeSlider_Scroll);
            // 
            // seekBar
            // 
            this.seekBar.Location = new System.Drawing.Point(106, 498);
            this.seekBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.seekBar.Maximum = 100;
            this.seekBar.Name = "seekBar";
            this.seekBar.Size = new System.Drawing.Size(488, 90);
            this.seekBar.TabIndex = 4;
            this.seekBar.Scroll += new System.EventHandler(this.SeekBar_Scroll);
            this.seekBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SeekBar_MouseDown);
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.Location = new System.Drawing.Point(24, 506);
            this.currentTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(74, 38);
            this.currentTimeLabel.TabIndex = 5;
            this.currentTimeLabel.Text = "00:00";
            this.currentTimeLabel.Click += new System.EventHandler(this.currentTimeLabel_Click);
            // 
            // durationLabel
            // 
            this.durationLabel.Location = new System.Drawing.Point(576, 506);
            this.durationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(68, 33);
            this.durationLabel.TabIndex = 6;
            this.durationLabel.Text = "00:00";
            // 
            // albumCoverBox
            // 
            this.albumCoverBox.Image = global::ZovMusic.Properties.Resources.placeholder;
            this.albumCoverBox.Location = new System.Drawing.Point(124, 21);
            this.albumCoverBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.albumCoverBox.Name = "albumCoverBox";
            this.albumCoverBox.Size = new System.Drawing.Size(392, 354);
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
            this.repeatButton.Location = new System.Drawing.Point(22, 569);
            this.repeatButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(174, 58);
            this.repeatButton.TabIndex = 0;
            this.repeatButton.Text = "Repeat Off";
            this.repeatButton.UseVisualStyleBackColor = false;
            this.repeatButton.Click += new System.EventHandler(this.RepeatButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 579);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Volume";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 700);
            this.Controls.Add(this.label1);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Music Player";
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seekBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumCoverBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
    }
}
