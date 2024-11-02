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
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "MP3 Files|*.mp3";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    player.URL = ofd.FileName;
                    LoadTrackInfo(ofd.FileName); // Загрузка информации о треке
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

                // Текущее время трека
                currentTimeLabel.Text = FormatTime(player.controls.currentPosition);

                // Оставшееся время до конца трека
                double remainingTime = player.currentMedia.duration - player.controls.currentPosition;
                durationLabel.Text = FormatTime(remainingTime);
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
            int minutes = (int)seconds / 60;
            int secs = (int)seconds % 60;
            return $"{minutes:D2}:{secs:D2}";
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

        private void currentTimeLabel_Click(object sender, EventArgs e)
        {
            // я случайно это добавил
        }


        private void LoadTrackInfo(string filePath)
        {
            try
            {
                var file = TagLib.File.Create(filePath);

                // Название трека
                if (!string.IsNullOrEmpty(file.Tag.Title))
                {
                    trackTitleLabel.Text = $"Title: {file.Tag.Title}";
                }
                else
                {
                    trackTitleLabel.Text = "Title: Unknown";
                }

                // Имя исполнителя
                if (file.Tag.Performers.Length > 0 && !string.IsNullOrEmpty(file.Tag.Performers[0]))
                {
                    artistLabel.Text = $"Artist: {file.Tag.Performers[0]}";
                }
                else
                {
                    artistLabel.Text = "Artist: Unknown";
                }

                // Загрузка обложки (если она есть)
                if (file.Tag.Pictures != null && file.Tag.Pictures.Length > 0)
                {
                    var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                    using (var ms = new MemoryStream(bin))
                    {
                        albumCoverBox.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    albumCoverBox.Image = Properties.Resources.placeholder;
                }
            }
            catch (Exception ex)
            {
                albumCoverBox.Image = Properties.Resources.placeholder;
                trackTitleLabel.Text = "Title: Unknown";
                artistLabel.Text = "Artist: Unknown";
                MessageBox.Show($"Ошибка при загрузке информации о треке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
