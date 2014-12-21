using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Reader
{
    /// <summary>
    /// Interaction logic for VisibleWindow.xaml
    /// </summary>
    public partial class VisibleWindow : Window
    {
        private ClipboardReader reader;

        public VisibleWindow(ClipboardReader reader)
        {
            this.reader = reader;
            this.DataContext = reader;
            reader.PropertyChanged += onStop;
            this.Topmost = true;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
            this.Left = System.Windows.SystemParameters.PrimaryScreenWidth / 2;
            this.Top = 0;
            InitializeComponent();
            PlayButton.Background = (Brush)this.Resources["PlayButton"];
            PauseButton.Background = (Brush)this.Resources["PauseButton"];
            StopButton.Background = (Brush)this.Resources["StopButton"];
        }

        private void onStop(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "State" && reader.State == readerState.stopped) {
                PlayButton.Content = "Play";
                PlayButton.Background = (Brush)this.Resources["PlayButton"];
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (reader.canPlay) { 
                reader.play();
                PlayButton.Content = "Restart";
                PlayButton.Background = (Brush)this.Resources["RestartButton"];
            }
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (reader.canPause)
            {
                reader.pause();
                if (reader.State == readerState.playing)
                {
                    PauseButton.Content = "Pause";
                    PauseButton.Background = (Brush)this.Resources["PauseButton"];

                }
                else
                {
                    PauseButton.Content = "Unpause";
                    PauseButton.Background = (Brush)this.Resources["PlayButton"];

                    PlayButton.Content = "Restart";
                    PlayButton.Background = (Brush)this.Resources["RestartButton"];

                }
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (reader.canStop)
            {
                reader.stop();
            }
        }

        private void SettingsButton_Click(object sender, Object e)
        {
            reader.openSettingsWindow();
        }

        private void VisibleWindow1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
