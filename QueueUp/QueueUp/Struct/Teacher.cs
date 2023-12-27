using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QueueUp.Struct
{
    public class Teacher: INotifyPropertyChanged
    {
        private string _name;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string ToString
        {
            get
            {
                return _name;
            }
        }
        private void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Teacher()
        {
            this.Name = "Default";
        }
        public Teacher(string Name) {
            this.Name = Name;
        }
    }
}