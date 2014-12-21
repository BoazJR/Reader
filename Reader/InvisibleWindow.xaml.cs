using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Reader
{
    /// <summary>
    /// Interaction logic for InvisibleWindow.xaml
    /// </summary>
    public partial class InvisibleWindow : Window
    {
        private TextGetter textGetter;
        private ClipboardReader reader;
        private bool firstClick = false;
        private System.Timers.Timer timer;

        public InvisibleWindow(ClipboardReader reader)
        {
            this.reader = reader;
            textGetter = new TextGetter();
            InitializeComponent();
        }
        
        private void ThumbButtonInfo_Click(object sender, EventArgs e)
        {

            reader.openSettingsWindow();
        }


        private void resetClick(object sender, System.Timers.ElapsedEventArgs e)
        {
            firstClick = false;
        }

        void App_Activated(object sender, EventArgs e)
        {
            if (!firstClick) {
                timer = new System.Timers.Timer(1000); //one second for double click.
                timer.Elapsed += resetClick;
                timer.Start();
                firstClick = true;
            }
            else
            {
                if (reader.State == readerState.stopped)
                {
                    reader.play();
                }
                else if (reader.State == readerState.paused)
                {
                    if (reader.SameTextAsLastSpoken())
                    {
                        reader.pause();
                    }
                    else
                    {
                        reader.play();
                    }
                }
                else if (reader.State == readerState.playing)
                {
                    reader.pause();
                }
                firstClick = false;
                timer.Dispose();
            }
            // source: http://stackoverflow.com/questions/13384191/how-to-remove-focus-from-wpf-window-like-in-close-event
            // Get the WPF window handle
            IntPtr hWnd = new WindowInteropHelper(this).Handle;

            // Look for next visible window in Z order
            IntPtr hNext = hWnd;
            do
                hNext = GetWindow(hNext, GW_HWNDNEXT);
            while (!IsWindowVisible(hNext));

            // Bring the window to foreground
            SetForegroundWindow(hNext);   
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetWindow(IntPtr hWnd, uint wCmd);
        const uint GW_HWNDNEXT = 2;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);


    }

}
