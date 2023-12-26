using QueueUp.Struct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QueueUp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ApointmentCreator : Window
    {
        public delegate void ApointmentCreatedEventHandler(object sender, ApointmentCreatedEventArgs e);
        public event ApointmentCreatedEventHandler? ApointmentCreated;
        protected virtual void OnApointmentCreated(ApointmentCreatedEventArgs e)
        {
            ApointmentCreated?.Invoke(this, e);
        }
        public ApointmentCreator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CreateApointment_Click(object sender, RoutedEventArgs e)
        {
            ApointmentCreatedEventArgs eventArgs = new ApointmentCreatedEventArgs();
            eventArgs.DateTimeStr = Time.ToString();
            eventArgs.Group = Group.ToString();
            eventArgs.Subject = Subject.ToString();
            eventArgs.Teachers = new List<Teacher>()
            {
                new Teacher(Teacher.Text)
            };
            OnApointmentCreated(eventArgs);
        }
    }
}
