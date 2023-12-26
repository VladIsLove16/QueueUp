using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QueueUp.Struct
{
    internal class Server_Main_
    {
        public TeacherCollection teacherCollection = new TeacherCollection();
        public StudentDictCollection studentCollection = new StudentDictCollection();
        public AppointmentCollection appointmentCollection = new AppointmentCollection();
        public void OnAppointmentCreated(object sender, ApointmentCreatedEventArgs e)
        {
            appointmentCollection.Add(new Apointment()
            {
                DateTime = e.DateTime,
                Subject = e.Subject,
                Teachers = e.Teachers,
                Group = e.Group
            });
            AppointmentCollectionChanged?.Invoke();

        }
        public delegate void Notify();
        public event Notify? AppointmentCollectionChanged;

        public AppointmentCollection LoadAppointmentCollection()
        {
            return appointmentCollection;
        }
    }
}
