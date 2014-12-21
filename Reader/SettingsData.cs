using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader 
{
    public class SettingsData : INotifyPropertyChanged
    {
        private int _speed;
        private string _voiceName;
        private bool _useVisibleWindow;
        private ObservableCollection<RegExpression> regExs;

        public ObservableCollection<RegExpression> RegExs
        {
            get { return regExs; }
            set { regExs = value;
            OnPropertyChanged("RegExs");
            }
        }

        public bool UseVisibleWindow
        {
            get { return _useVisibleWindow; }
            set { _useVisibleWindow = value;
            OnPropertyChanged("UseVisibleWindow");
            }
        }

        public SettingsData()
        {
            regExs = new ObservableCollection<RegExpression>();            
            Load();
            
        }
        public int speed {
            get { return _speed; }
            set
            {
                _speed = value;
                OnPropertyChanged("speed");
            }
        }

        public string voiceName
        {
            get { return _voiceName; }
            set
            {
                _voiceName = value;
                OnPropertyChanged("voiceName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        internal void Save()
        {
            var sd = Properties.Settings.Default;
            sd.VoiceName = _voiceName;
            sd.Rate = _speed;
            sd.UseVisibleWindow = _useVisibleWindow;
            int numberOfItems = regExs.Count();
            StringCollection patterns = new StringCollection();
            StringCollection replacements = new StringCollection();
            StringCollection names = new StringCollection();
            StringCollection isActives= new StringCollection();
            for (int i = 0; i < regExs.Count(); i++)
            {
                patterns.Add(regExs[i].Pattern);
                replacements.Add(regExs[i].Replacement);
                names.Add(regExs[i].Name);
                isActives.Add(regExs[i].IsActive.ToString()); 
            }

            sd.Patterns = patterns;
            sd.Replacments = replacements;
            sd.Names = names;
            sd.IsActives = isActives;
            sd.Save();


        }
        public void Load() {
            var sd = Properties.Settings.Default;
            if (sd.FirstTimeStarting) {
                ResetRegExList();
                sd.FirstTimeStarting = false;
            }
            else { 
                _voiceName = sd.VoiceName;
                _speed = sd.Rate;
                _useVisibleWindow = sd.UseVisibleWindow;
                List<RegExpression> regexList = new List<RegExpression>();
                for (int i = 0; i < sd.Patterns.Count; i++) {
                    regExs.Add(new RegExpression(sd.Patterns[i], sd.Replacments[i],
                        sd.IsActives[i]=="True", sd.Names[i]));
                }
            } 
        }
        public void ResetRegExList() {
            for (int i = regExs.Count-1; i >=0; i--)
            {
                regExs.RemoveAt(i);
            }
            regExs.Add(new RegExpression(@"\t|\n|\r", "", true, "remove end lines in pdfs"));
            regExs.Add(new RegExpression(@"((https?:\/\/)|(www\.))[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)",
                "site", true, "URLs"));
        }
    }

}
