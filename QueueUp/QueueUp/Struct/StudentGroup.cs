using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUp.Struct
{
    public class StudentGroup : INotifyPropertyChanged
    {
        private string number;

        public string Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    OnPropertyChanged(nameof(Number));
                }
            }
        }
        public StudentGroup() { Number = "221-3710"; }
        public StudentGroup(string a) { Number = a; }
        public string ToString
        {
            get
            {
                return number;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
