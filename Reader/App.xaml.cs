using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows.Shell;
using System.ComponentModel;

namespace Reader
{

    public partial class App : Application
    {
        private SettingsData settings;
        private ClipboardReader reader;
        private Window CurrentWindow;
      
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            settings = new SettingsData();
            reader = new ClipboardReader(settings);
            if (settings.UseVisibleWindow)
            {
                CurrentWindow = new VisibleWindow(reader);
            }
            else {
                CurrentWindow = new InvisibleWindow(reader);
            }
            CurrentWindow.Show();
            settings.PropertyChanged += changeWindow;
        }

        private void changeWindow(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "UseVisibleWindow") {
                CurrentWindow.Close();
                if (settings.UseVisibleWindow)
                {
                    CurrentWindow = new VisibleWindow(reader);
                }
                else
                {
                    CurrentWindow = new InvisibleWindow(reader);
                }
                CurrentWindow.Show();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            reader.save();
            base.OnExit(e);
        }
    }
}
