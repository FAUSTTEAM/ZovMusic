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

        private System.Windows.Forms.Button rewind15Button;
        private System.Windows.Forms.Button rewind30Button;
        private System.Windows.Forms.Button rewind45Button;
        private System.Windows.Forms.Button rewind60Button;
        private System.Windows.Forms.Button forward15Button;
        private System.Windows.Forms.Button forward30Button;
        private System.Windows.Forms.Button forward45Button;
        private System.Windows.Forms.Button forward60Button;

        private System.Windows.Forms.Button playReverseButton;

        private Button goydaButton;

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
            this.components = new System.ComponentModel.Container();
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
            this.rewind15Button = new System.Windows.Forms.Button();
            this.rewind30Button = new System.Windows.Forms.Button();
            this.rewind45Button = new System.Windows.Forms.Button();
            this.rewind60Button = new System.Windows.Forms.Button();
            this.forward15Button = new System.Windows.Forms.Button();
            this.forward30Button = new System.Windows.Forms.Button();
            this.forward45Button = new System.Windows.Forms.Button();
            this.forward60Button = new System.Windows.Forms.Button();
            this.playReverseButton = new System.Windows.Forms.Button();
            this.reverseTimer = new System.Windows.Forms.Timer(this.components);
            this.muteButton = new System.Windows.Forms.Button();
            this.goydaButton = new System.Windows.Forms.Button();
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
            this.pauseButton.Location = new System.Drawing.Point(274, 569);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(4);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(182, 121);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Pause";
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(13, 41);
            this.loadButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(118, 94);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load MP3";
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // volumeSlider
            // 
            this.volumeSlider.Location = new System.Drawing.Point(488, 608);
            this.volumeSlider.Margin = new System.Windows.Forms.Padding(4);
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
            this.seekBar.Margin = new System.Windows.Forms.Padding(4);
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
            this.albumCoverBox.Location = new System.Drawing.Point(182, 27);
            this.albumCoverBox.Margin = new System.Windows.Forms.Padding(4);
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
            this.repeatButton.Location = new System.Drawing.Point(22, 578);
            this.repeatButton.Margin = new System.Windows.Forms.Padding(6);
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(181, 110);
            this.repeatButton.TabIndex = 0;
            this.repeatButton.Text = "Repeat Off";
            this.repeatButton.UseVisualStyleBackColor = false;
            this.repeatButton.Click += new System.EventHandler(this.RepeatButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(534, 579);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Volume";
            // 
            // rewind15Button
            // 
            this.rewind15Button.Location = new System.Drawing.Point(706, 351);
            this.rewind15Button.Name = "rewind15Button";
            this.rewind15Button.Size = new System.Drawing.Size(100, 75);
            this.rewind15Button.TabIndex = 0;
            this.rewind15Button.Text = "-15s";
            this.rewind15Button.Click += new System.EventHandler(this.Rewind15Button_Click);
            // 
            // rewind30Button
            // 
            this.rewind30Button.Location = new System.Drawing.Point(706, 243);
            this.rewind30Button.Name = "rewind30Button";
            this.rewind30Button.Size = new System.Drawing.Size(100, 75);
            this.rewind30Button.TabIndex = 1;
            this.rewind30Button.Text = "-30s";
            this.rewind30Button.Click += new System.EventHandler(this.Rewind30Button_Click);
            // 
            // rewind45Button
            // 
            this.rewind45Button.Location = new System.Drawing.Point(706, 139);
            this.rewind45Button.Name = "rewind45Button";
            this.rewind45Button.Size = new System.Drawing.Size(100, 75);
            this.rewind45Button.TabIndex = 2;
            this.rewind45Button.Text = "-45s";
            this.rewind45Button.Click += new System.EventHandler(this.Rewind45Button_Click);
            // 
            // rewind60Button
            // 
            this.rewind60Button.Location = new System.Drawing.Point(706, 41);
            this.rewind60Button.Name = "rewind60Button";
            this.rewind60Button.Size = new System.Drawing.Size(100, 75);
            this.rewind60Button.TabIndex = 3;
            this.rewind60Button.Text = "-60s";
            this.rewind60Button.Click += new System.EventHandler(this.Rewind60Button_Click);
            // 
            // forward15Button
            // 
            this.forward15Button.Location = new System.Drawing.Point(848, 351);
            this.forward15Button.Name = "forward15Button";
            this.forward15Button.Size = new System.Drawing.Size(100, 75);
            this.forward15Button.TabIndex = 4;
            this.forward15Button.Text = "+15s";
            this.forward15Button.Click += new System.EventHandler(this.Forward15Button_Click);
            // 
            // forward30Button
            // 
            this.forward30Button.Location = new System.Drawing.Point(848, 243);
            this.forward30Button.Name = "forward30Button";
            this.forward30Button.Size = new System.Drawing.Size(100, 75);
            this.forward30Button.TabIndex = 5;
            this.forward30Button.Text = "+30s";
            this.forward30Button.Click += new System.EventHandler(this.Forward30Button_Click);
            // 
            // forward45Button
            // 
            this.forward45Button.Location = new System.Drawing.Point(848, 139);
            this.forward45Button.Name = "forward45Button";
            this.forward45Button.Size = new System.Drawing.Size(100, 75);
            this.forward45Button.TabIndex = 6;
            this.forward45Button.Text = "+45s";
            this.forward45Button.Click += new System.EventHandler(this.Forward45Button_Click);
            // 
            // forward60Button
            // 
            this.forward60Button.Location = new System.Drawing.Point(848, 41);
            this.forward60Button.Name = "forward60Button";
            this.forward60Button.Size = new System.Drawing.Size(100, 75);
            this.forward60Button.TabIndex = 7;
            this.forward60Button.Text = "+60s";
            this.forward60Button.Click += new System.EventHandler(this.Forward60Button_Click);
            // 
            // playReverseButton
            // 
            this.playReverseButton.Location = new System.Drawing.Point(706, 448);
            this.playReverseButton.Name = "playReverseButton";
            this.playReverseButton.Size = new System.Drawing.Size(242, 96);
            this.playReverseButton.TabIndex = 0;
            this.playReverseButton.Text = "Reverse";
            this.playReverseButton.Click += new System.EventHandler(this.PlayReverseButton_Click);
            // 
            // reverseTimer
            // 
            this.reverseTimer.Tick += new System.EventHandler(this.ReverseTimer_Tick);
            // 
            // muteButton
            // 
            this.muteButton.Location = new System.Drawing.Point(706, 579);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(242, 89);
            this.muteButton.TabIndex = 0;
            this.muteButton.Text = "Mute";
            this.muteButton.Click += new System.EventHandler(this.MuteButton_Click);
            // 
            // goydaButton
            // 
            this.goydaButton.Location = new System.Drawing.Point(22, 200);
            this.goydaButton.Name = "goydaButton";
            this.goydaButton.Size = new System.Drawing.Size(100, 50);
            this.goydaButton.TabIndex = 0;
            this.goydaButton.Text = "GOYDA!";
            this.goydaButton.Click += new System.EventHandler(this.GoydaButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 1002);
            this.Controls.Add(this.goydaButton);
            this.Controls.Add(this.muteButton);
            this.Controls.Add(this.playReverseButton);
            this.Controls.Add(this.rewind15Button);
            this.Controls.Add(this.rewind30Button);
            this.Controls.Add(this.rewind45Button);
            this.Controls.Add(this.rewind60Button);
            this.Controls.Add(this.forward15Button);
            this.Controls.Add(this.forward30Button);
            this.Controls.Add(this.forward45Button);
            this.Controls.Add(this.forward60Button);
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
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
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
