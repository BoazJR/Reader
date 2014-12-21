
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Speech.Synthesis;
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
   
    public partial class SettingsWindow : Window
    {
        private SettingsData data;

        public SettingsWindow(SettingsData data, InstalledVoice[] voices)
        {
            this.data = data;
            this.DataContext = data;
            InitializeComponent();
            foreach (InstalledVoice voice in voices)
            {
                this.NameList.Items.Add(voice.VoiceInfo.Name);
            }
            
        }

        private void Settings_Deactivated(object sender, EventArgs e)
        {
            if (this.IsActive)
            {
                this.Close();
            }
        }

        private void DeleteRegEx(object sender, RoutedEventArgs e)
        {
            data.RegExs.Remove((sender as Button).CommandParameter as RegExpression);
            
        }

        private void AddRegExButton_Click(object sender, RoutedEventArgs e)
        {
            data.RegExs.Add(new RegExpression("","",true,""));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            data.ResetRegExList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Settings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            Reader.Properties.Settings.Default.UseVisibleWindow = ((CheckBox)sender).IsChecked.Value;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
