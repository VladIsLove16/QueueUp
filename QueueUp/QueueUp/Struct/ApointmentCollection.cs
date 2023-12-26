using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace QueueUp.Struct
{
    internal class AppointmentCollection
    {
        public List<Apointment> Appointments = new List<Apointment>();

        public void Add(Apointment item)
        {
            Appointments.Add(item);
        }
        public void EndSome()
        {
        }
        public ObservableCollection<Apointment> ToObservableCollection()
        {
            return new ObservableCollection<Apointment>(Appointments);
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