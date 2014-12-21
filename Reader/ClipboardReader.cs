using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Reader
{
    public class ClipboardReader : INotifyPropertyChanged
    {
        private SettingsData settingsData;
        private SpeechSynthesizer reader;
        private Thread readingThread;
        private string lastSpoken = "";
        private TextGetter textGetter;
        private SettingsWindow settingsWindow;
        private bool _canStop;
        private MemoryStream waveStream;
        private WaveOut waveOut;
        private readerState _state;

        public ClipboardReader(SettingsData settings)
        {
            reader = new SpeechSynthesizer();
            textGetter = new TextGetter();
            settingsData = settings;
            settingsData.PropertyChanged += onSettingsChanged;
            canStop = canPause = false;
            canPlay = true;
            _state = readerState.stopped;
        }

        public bool canStop
        {
            get { return _canStop; }
            set { _canStop = value;
            OnPropertyChanged("canStop");
            }
        }
        bool _canPlay;

        public bool canPlay
        {
            get { return _canPlay; }
            set { _canPlay = value;
            OnPropertyChanged("canPlay");
            }
        }
        bool _canPause;

        public bool canPause
        {
            get { return _canPause; }
            set { _canPause = value;
            OnPropertyChanged("canPause");
            }
        }
        

        public readerState State
        {
            get { return _state; }
            private set { _state = value;
            OnPropertyChanged("State");
            }
        }

        
        /// <summary>
        /// Play starts to read everythin the text set in the textGetter (from clipboard)
        /// if it's paused it will cancel and restart.
        /// </summary>
        public void play() {
            if (canPlay) { 
                Thread t = new Thread(new ThreadStart(textGetter.getText));
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
                if (State == readerState.playing || State == readerState.paused) {
                    waveOut.Stop();
                    waveOut.Dispose();
                }
                State = readerState.playing;
                canStop = canPause = canPlay = true;
                lastSpoken = textGetter.text;
                string say = textGetter.text;
                foreach (RegExpression reg in settingsData.RegExs)
                {
                    say = Regex.Replace(say, reg.Pattern, reg.Replacement);
                }

                waveStream = new MemoryStream();
                reader.SetOutputToWaveStream(waveStream);
                reader.Rate = settingsData.speed;
                reader.Speak(say);
                //removing the initial click. 
                if (waveStream.Length > 64)
                {
                    waveStream.Position = 64;
                }
                else
                {
                    waveStream.Position = 0;
                }
                WaveFormat format = new WaveFormat(11025, 2);
                RawSourceWaveStream sourceStream = new RawSourceWaveStream(waveStream, format);
                waveOut = new WaveOut();
                waveOut.PlaybackStopped += autoEndPlay;
                waveOut.Init(sourceStream);
                readingThread = new Thread(waveOut.Play);
                readingThread.Start();
            }
        }

        public void stop() {
            if (canStop) {
                waveOut.Stop();
                waveOut.Dispose();
                State = readerState.stopped;
                canPause = canStop = false;
                canPlay = true;
            }
        }
        /// <summary>
        /// used to catch the event when the automatically audio ends.
        /// </summary>
        private void autoEndPlay(object sender, StoppedEventArgs e)
        {
            stop();
        }

        /// <summary>
        /// either pause the reader if playing or unpause if paused.
        /// </summary>
        public void pause() {
            if (canPause)
            {
                if (State == readerState.paused)
                {
                    waveOut.Play();
                    canPause = canStop = canPlay = true;
                    State = readerState.playing;
                }
                else
                {
                    waveOut.Pause();
                    State = readerState.paused;
                    canPause = canStop = canPlay = true;
                }
            }
        }
        public bool SameTextAsLastSpoken() { 
            Thread t = new Thread(new ThreadStart(textGetter.getText));
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
                return lastSpoken == textGetter.text;
        }


        public void save()
        {
            settingsData.Save();
        }


        public void openSettingsWindow()
        {
            if (settingsWindow == null||!settingsWindow.IsLoaded)
            {
                InstalledVoice[] voices = reader.GetInstalledVoices().ToArray<InstalledVoice>();
                settingsWindow = new SettingsWindow(settingsData,voices);
            } else {
                settingsWindow.Close();
            }
        }

        /// <summary>
        /// smooth changes when audio is speaking.
        /// </summary>
        private void onSettingsChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            bool resume = reader.State == SynthesizerState.Speaking;
            if (resume)
            {
                reader.Pause();
            }
            if (settingsData.speed >= -10 && settingsData.speed <= 10)
            {
                reader.Rate = settingsData.speed;
            }
            if (reader.GetInstalledVoices().ToList<InstalledVoice>().Exists(element => element.VoiceInfo.Name == settingsData.voiceName))
            {
                reader.SelectVoice(settingsData.voiceName);
            }
            if (resume)
            {
                reader.Resume();
            }
        }
        /// <summary>
        /// INotifyPropertyChanged implementation
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

    }


    public enum readerState { 
        stopped, 
        paused,
        playing
    }


    public class TextGetter
    {
        public string text;
        public void getText()
        {
            if (Clipboard.ContainsText())
            {
                text = Clipboard.GetText();
            }
            else
            {
                text = "";
            }
        }
    }
}
