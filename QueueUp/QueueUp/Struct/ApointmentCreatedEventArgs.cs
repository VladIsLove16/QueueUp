using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QueueUp.Struct
{
    public class ApointmentCreatedEventArgs : EventArgs
    {
        public string Subject { get; set; }
        public Date DateTime;
        public string DateTimeStr;
        public string Group { get; set; }
        public List<Teacher> Teachers = new List<Teacher>();
        public List<Student> Students = new List<Student>();
        public ApointmentCreatedEventArgs()
        {
        }
    }
}
