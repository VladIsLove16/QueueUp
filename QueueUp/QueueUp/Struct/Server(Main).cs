using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
            appointmentCollection.Add(e.Apointment);
            AppointmentCollectionChanged?.Invoke();
            Debug.WriteLine(appointmentCollection.GetObservableCollection().Count);

        }
        public void OnStudentSignUp(object sender, StudentSignUpEventArgs e)
        {
            studentCollection.Add(e.student);
            appointmentCollection.SignUp(e);
            AppointmentCollectionChanged?.Invoke();
            Debug.WriteLine(appointmentCollection[e.Apointment]);
        }
        public delegate void Notify();
        public event Notify? AppointmentCollectionChanged;

        public AppointmentCollection GetAppointmentCollection()
        {
            return appointmentCollection;
        }

        internal void OnFinish_Appointment( Apointment a)
        {
            appointmentCollection.RemoveAppointment(a);
        }
    }
}
