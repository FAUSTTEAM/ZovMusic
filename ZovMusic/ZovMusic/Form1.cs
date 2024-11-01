using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WMPLib;
using TagLib;

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
            timer = new Timer { Interval = 1000 };
            timer.Tick += Timer_Tick;
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
                    LoadAlbumCover(dialog.FileName);
                }
            }
        }

        private void VolumeSlider_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = ((TrackBar)sender).Value;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (player.currentMedia != null && player.controls.currentPosition >= 0 && player.currentMedia.duration > 0)
            {
                // Обновляем позицию ползунка на основе текущего положения трека
                seekBar.Value = (int)(player.controls.currentPosition / player.currentMedia.duration * 100);
                currentTimeLabel.Text = FormatTime(player.controls.currentPosition);
                durationLabel.Text = FormatTime(player.currentMedia.duration);
            }
        }

        private void SeekBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (player.currentMedia != null && player.currentMedia.duration > 0)
            {
                // Пересчитываем положение в диапазоне от 0 до 1 и устанавливаем позицию трека
                var seekBar = (TrackBar)sender;
                double newPosition = seekBar.Value / 100.0;
                player.controls.currentPosition = player.currentMedia.duration * newPosition;
            }
        }

        private void SeekBar_Scroll(object sender, EventArgs e)
        {
            if (player.currentMedia != null && player.currentMedia.duration > 0)
            {
                // Пересчитываем позицию ползунка и обновляем текущую позицию трека
                double newPosition = seekBar.Value / 100.0;
                player.controls.currentPosition = player.currentMedia.duration * newPosition;
            }
        }


        private string FormatTime(double seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return time.ToString(@"mm\:ss");
        }

        private void LoadAlbumCover(string filePath)
        {
            try
            {
                var file = TagLib.File.Create(filePath);

                // Проверка на наличие изображений в метаданных
                if (file.Tag.Pictures != null && file.Tag.Pictures.Length > 0)
                {
                    // Извлекаем изображение обложки из метаданных
                    var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                    using (var ms = new MemoryStream(bin))
                    {
                        albumCoverBox.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Если обложка отсутствует, устанавливаем заглушку
                    albumCoverBox.Image = Properties.Resources.placeholder;
                    MessageBox.Show("Обложка отсутствует в этом файле.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // В случае ошибки устанавливаем заглушку и выводим сообщение об ошибке
                albumCoverBox.Image = Properties.Resources.placeholder;
                MessageBox.Show($"Ошибка при загрузке обложки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
