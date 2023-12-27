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
        public Apointment Apointment;
    }public class StudentSignUpEventArgs : EventArgs
    {
        public Student student;
        public Apointment Apointment;
    }
}
