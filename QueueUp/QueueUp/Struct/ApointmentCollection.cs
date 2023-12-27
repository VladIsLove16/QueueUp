using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;

namespace QueueUp.Struct
{
    internal class AppointmentCollection
    {
        private List<Apointment> appointments = new List<Apointment>();
        public Apointment this[Apointment apointment]
        {
            get
            {
                Apointment foundElement = appointments.Find(element => element == apointment);
                if (foundElement != null)
                {
                   return foundElement;
                }
                else
                {
                    MessageBox.Show("Встреча не найдена");
                    return null;
                }
            }
        }
        public void Add(Apointment item)
        {
            appointments.Add(item);
        }
        public void EndSome()
        {
        }
        public ObservableCollection<Apointment> GetObservableCollection()
        {
            return new ObservableCollection<Apointment>(appointments);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        internal void RemoveAppointment(Apointment a)
        {
            this[a].End();
            appointments.Remove(a);
        }

        internal void SignUp(StudentSignUpEventArgs e)
        {
            if (this[e.Apointment] == null) return;
            this[e.Apointment].AddStudent(e.student);
        }
        //public void OnAppointmentCreated(object sender, ApointmentCreatedEventArgs e)
        //{
        //    Appointments.Add(new Apointment()
        //    {
        //        DateTime=e.DateTime,
        //        Subject=e.Subject,
        //        Teachers=e.Teachers,
        //        Group=e.Group
        //    });
        //}
    }
    
}