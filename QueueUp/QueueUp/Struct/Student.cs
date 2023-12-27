using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUp.Struct
{
    [Serializable]
    public class Student : INotifyPropertyChanged
    {
        public static int StudentCount;
        public int ID;
        public string Name { get; set; }
        private StudentGroup group;
        public StudentGroup Group
        {
            get { return group; }
            set
            {
                group = value;
                OnPropertyChanged(nameof(Group));
            }
        }
        private Note note;
        public Note Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged(nameof(Note));
            }
        }
        public Student()
        {
            StudentCount++;//не уверен что это работает как я хочу(что будет при создании временных студентов?)
            ID = StudentCount;
        }
        public Student(string name):base()
        {
            Name= name;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
