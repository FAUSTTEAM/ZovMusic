using System;
using System.IO;
using System.Windows.Forms;
using WMPLib;

namespace ZovMusic
{
    public partial class Form1 : Form
    {
        private WindowsMediaPlayer player = new WindowsMediaPlayer();
        private Timer timer;

        public Form1()
        {
            InitializeComponent();
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            Button playButton = new Button { Text = "Play", Left = 10, Top = 10 };
            playButton.Click += PlayButton_Click;

            Button pauseButton = new Button { Text = "Pause", Left = 90, Top = 10 };
            pauseButton.Click += PauseButton_Click;

            Button loadButton = new Button { Text = "Load MP3", Left = 170, Top = 10 };
            loadButton.Click += LoadButton_Click;

            TrackBar volumeSlider = new TrackBar { Left = 10, Top = 50, Width = 200, Maximum = 100, Value = 50 };
            volumeSlider.Scroll += (sender, args) => player.settings.volume = volumeSlider.Value;

            TrackBar seekBar = new TrackBar { Left = 10, Top = 90, Width = 300, Maximum = 100 };
            seekBar.MouseDown += (sender, args) =>
            {
                if (player.currentMedia != null && player.currentMedia.duration > 0)
                    player.controls.currentPosition = player.currentMedia.duration * seekBar.Value / 100;
            };

            Label currentTimeLabel = new Label { Left = 320, Top = 90, Width = 100 };
            Label durationLabel = new Label { Left = 320, Top = 110, Width = 100 };

            Controls.Add(playButton);
            Controls.Add(pauseButton);
            Controls.Add(loadButton);
            Controls.Add(volumeSlider);
            Controls.Add(seekBar);
            Controls.Add(currentTimeLabel);
            Controls.Add(durationLabel);

            timer = new Timer { Interval = 1000 };
            timer.Tick += (sender, args) =>
            {
                if (player.currentMedia != null && player.controls.currentPosition >= 0 && player.currentMedia.duration > 0)
                {
                    seekBar.Value = (int)(player.controls.currentPosition / player.currentMedia.duration * 100);
                    currentTimeLabel.Text = FormatTime(player.controls.currentPosition);
                    durationLabel.Text = FormatTime(player.currentMedia.duration);
                }
            };
            timer.Start();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(player.URL))
            {
                player.controls.play();
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (player.playState == WMPPlayState.wmppsPlaying)
                player.controls.pause();
            else if (player.playState == WMPPlayState.wmppsPaused)
                player.controls.play();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "MP3 Files|*.mp3";
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    player.URL = dialog.FileName;
                    player.controls.stop();
                }
            }
        }

        private string FormatTime(double seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return time.ToString(@"mm\:ss");
        }
    }
}

