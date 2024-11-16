using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;
using WMPLib;
using ZovMusic.Properties;


namespace ZovMusic
{
    public partial class Form1 : Form
    {
        private WindowsMediaPlayer player = new WindowsMediaPlayer();
        private Timer timer;
        private string defaultMusicFilePath;


        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private Timer reverseTimer;
        private bool isReversing = false;

        private Button muteButton;
        private int previousVolume;
        private bool isMuted = false;

        private WindowsMediaPlayer player2 = new WindowsMediaPlayer();
        private List<Form> popups = new List<Form>();
        public Form1()
        {
            InitializeComponent();
            InitializePlayer();
            SetCustomCursor();

            player.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);

            //defaultMusicFilePath = @"C:\Users\redmi\OneDrive\Desktop\ZovMusic\ZovMusic\ZovMusic\Resources\default.mp3";

            if (File.Exists(defaultMusicFilePath))
            {
                player.URL = defaultMusicFilePath;
                player.controls.pause();
                pauseButton.Text = "Play";

                var file = TagLib.File.Create(defaultMusicFilePath);

                // Проверка на наличие изображений в метаданных
                if (file.Tag.Pictures != null && file.Tag.Pictures.Length > 0)
                {
                    // Извлекаем изображение обложки из mp3
                    var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                    using (var ms = new MemoryStream(bin))
                    {
                        albumCoverBox.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // заглушка
                    albumCoverBox.Image = Properties.Resources.placeholder;
                    MessageBox.Show("Обложка отсутствует в этом файле.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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


            }
            else
            {
                MessageBox.Show($"Файл по умолчанию не найден: {defaultMusicFilePath}", "Ошибка");
            }

            reverseTimer = new Timer();
            reverseTimer.Interval = 100;
            reverseTimer.Tick += ReverseTimer_Tick;

           
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
            {
                pauseButton.Text = "Play";
                player.controls.pause();
            }
            else if (player.playState == WMPPlayState.wmppsPaused)
            {
                player.controls.play();
                pauseButton.Text = "Pause";
            }
            else if (player.playState == WMPPlayState.wmppsStopped) // когда закончился трек чтобы можно было воспроизвести снова 
            {
                player.controls.currentPosition = 0;
                player.controls.play();
                pauseButton.Text = "Pause";
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "MP3 Files|*.mp3";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    player.URL = ofd.FileName;
                    LoadTrackInfo(ofd.FileName);
                }
            }
        }


        private void VolumeSlider_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = ((TrackBar)sender).Value;
            player2.settings.volume = ((TrackBar)sender).Value;
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
                    // Извлекаем изображение обложки из mp3
                    var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                    using (var ms = new MemoryStream(bin))
                    {
                        albumCoverBox.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // заглушка
                    albumCoverBox.Image = Properties.Resources.placeholder;
                    MessageBox.Show("Обложка отсутствует в этом файле.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

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

                // Загрузка обложки (если она есть))))
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

        private void RepeatButton_Click(object sender, EventArgs e)
        {
            player.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            isRepeatEnabled = !isRepeatEnabled;

            if (isRepeatEnabled)
            {
                repeatButton.Text = "Repeat On";
                repeatButton.BackColor = Color.LightGreen;
            }
            else
            {
                repeatButton.Text = "Repeat Off";
                repeatButton.BackColor = Color.LightGray;
            }
        }

        // повтор трека
        private void Player_PlayStateChange(int NewState)
        {
            if (NewState == (int)WMPPlayState.wmppsStopped && isRepeatEnabled)
            {

                player.controls.play();
            }
        }

        private void Rewind15Button_Click(object sender, EventArgs e) => Rewind(15);
        private void Rewind30Button_Click(object sender, EventArgs e) => Rewind(30);
        private void Rewind45Button_Click(object sender, EventArgs e) => Rewind(45);
        private void Rewind60Button_Click(object sender, EventArgs e) => Rewind(60);

        private void Forward15Button_Click(object sender, EventArgs e) => Forward(15);
        private void Forward30Button_Click(object sender, EventArgs e) => Forward(30);
        private void Forward45Button_Click(object sender, EventArgs e) => Forward(45);
        private void Forward60Button_Click(object sender, EventArgs e) => Forward(60);

        private void Rewind(int seconds)
        {
            double newTime = player.controls.currentPosition - seconds;
            player.controls.currentPosition = newTime < 0 ? 0 : newTime;
        }

        private void Forward(int seconds)
        {
            double newTime = player.controls.currentPosition + seconds;
            player.controls.currentPosition = newTime > player.currentMedia.duration ? player.currentMedia.duration : newTime;
        }

        // Обработчик для кнопки обратного воспроизведения
        // Обработчик для кнопки обратного воспроизведения
        private void PlayReverseButton_Click(object sender, EventArgs e)
        {
            if (isReversing)
            {
                // Останавливаем обратное воспроизведение
                reverseTimer.Stop();
                isReversing = false;
                player.controls.play();  // Возобновляем обычное воспроизведение
                playReverseButton.Text = "Reverse";
            }
            else
            {
                // Запускаем обратное воспроизведение
                reverseTimer.Start();
                isReversing = true;
                player.controls.pause();  // Приостанавливаем обычное воспроизведение
                playReverseButton.Text = "Stop Reverse";
            }
        }

        // Обратное воспроизведение через уменьшение позиции
        private void ReverseTimer_Tick(object sender, EventArgs e)
        {
            if (player.controls.currentPosition > 0.1) // Проверяем, что не достигли начала трека
            {
                player.controls.currentPosition -= 0.1;  // Уменьшаем текущую позицию на 0.1 сек
            }
            else
            {
                // Если достигли начала трека, останавливаем таймер и воспроизведение
                reverseTimer.Stop();
                isReversing = false;
                playReverseButton.Text = "Reverse";
            }
        }

        private void MuteButton_Click(object sender, EventArgs e)
        {
            if (isMuted)
            {
                // Восстанавливаем предыдущую громкость
                player.settings.volume = previousVolume;
                muteButton.Text = "Mute";
                isMuted = false;
            }
            else
            {
                // Запоминаем текущий уровень громкости и устанавливаем громкость на 0
                previousVolume = player.settings.volume;
                player.settings.volume = 0;
                muteButton.Text = "Unmute";
                isMuted = true;
            }
        }

        private void SetCustomCursor()
        {
            string cursorPath = @"C:\Users\redmi\OneDrive\Desktop\ZovMusic\ZovMusic\ZovMusic\Resources\NormalCursor.cur";
            if (System.IO.File.Exists(cursorPath))
            {
                // Устанавливаем курсор для формы
                this.Cursor = new Cursor(cursorPath);
            }
            else
            {
                MessageBox.Show("Файл курсора не найден. Проверьте путь к файлу.");
            }
        }
        private void GoydaButton_Click(object sender, EventArgs e)
        {
            ShowPopups();
            PlayAudio();
        }

        private void ShowPopups()
        {
            Random rand = new Random(); // Для генерации случайных позиций

            // Получаем размеры экрана для размещения окон
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            for (int i = 0; i < 25; i++) // Создаем 5 всплывающих окон
            {
                Form popup = new Form
                {
                    Size = new Size(300, 200),
                    FormBorderStyle = FormBorderStyle.None,
                    BackColor = Color.White, // Устанавливаем белый фон
                    StartPosition = FormStartPosition.Manual
                };

                // Устанавливаем случайное расположение на экране
                int posX = rand.Next(0, screenWidth - popup.Width);
                int posY = rand.Next(0, screenHeight - popup.Height);
                popup.Location = new Point(posX, posY);

                // Создаем метку с текстом "ГОЙДА!!!!!" и настраиваем ее
                Label label = new Label
                {
                    Text = "ГОЙДА!!!!!",
                    ForeColor = Color.Black, // Устанавливаем черный цвет текста
                    Font = new Font("Arial", 24, FontStyle.Bold),
                    AutoSize = false, // Отключаем авторазмер, чтобы можно было выровнять текст
                    TextAlign = ContentAlignment.MiddleCenter, // Выравнивание текста по центру
                    Dock = DockStyle.Fill // Занимаем всю область окна
                };

                popup.Controls.Add(label); // Добавляем метку на всплывающее окно
                popups.Add(popup); // Добавляем окно в список
                popup.Show(); // Отображаем всплывающее окно
            }
        }




        private void PlayAudio()
        {
            player2 = new WindowsMediaPlayer();
            player2.URL = @"C:\Users\redmi\Downloads\9297.mp3"; // Указываем путь к файлу
            player2.controls.play();
            player2.settings.volume = player.settings.volume+100;
            player2.PlayStateChange += Player_PlayStateChange2;
        }

        private void Player_PlayStateChange2(int newState)
        {
            // Проверяем, закончился ли аудиофайл
            if ((WMPPlayState)newState == WMPPlayState.wmppsStopped)
            {
                ClosePopups(); // Закрываем все окна
            }
        }

        private void ClosePopups()
        {
            foreach (Form popup in popups)
            {
                popup.Close(); // Закрываем каждое всплывающее окно
            }
            popups.Clear();
        }
    }



}


