using System;
using System.ComponentModel;
namespace Reader
{
    /// <summary>
    /// Holdes regular expression settings
    /// </summary>
    public class RegExpression : INotifyPropertyChanged
    {
        private string _pattern;
        private bool _isActive;
        private string _replacement;
        private string _name;
       
        
        public RegExpression(string pattern, string Replacement, bool isActive = true, string note = "")
        {
            this.Pattern = pattern;
            this.Replacement = Replacement;
            this.IsActive = isActive;
            this.Name = note;
        }

        public string Pattern
        {
            get { return _pattern; }
            set { _pattern = value;
            OnPropertyChanged("Pattern");
            }
        }
        public string Replacement
        {
            get { return _replacement; }
            set { _replacement = value;
            OnPropertyChanged("Replacement");
            }
        }
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value;
            OnPropertyChanged("IsActive");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        //INotifyPropertyChanged implementation
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
}