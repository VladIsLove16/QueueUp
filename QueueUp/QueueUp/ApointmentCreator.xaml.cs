using QueueUp.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QueueUp
{
    /// <summary>
    /// Логика взаимодействия для ApoitmentCreator.xaml
    /// </summary>
    public partial class ApointmentCreator : Page
    {
        public delegate void ApointmentCreatedEventHandler(object sender, ApointmentCreatedEventArgs e);
        public event ApointmentCreatedEventHandler? ApointmentCreate;
        protected virtual void OnApointmentCreate(ApointmentCreatedEventArgs e)
        {
            ApointmentCreate?.Invoke(this, e);
        }
        public ApointmentCreator()
        {
            InitializeComponent();
        }
        private void CreateApointment_Click(object sender, RoutedEventArgs e)
        {
            ApointmentCreatedEventArgs eventArgs = new ApointmentCreatedEventArgs();
            eventArgs.DateTimeStr = Time.Text.ToString();
            eventArgs.Group = Group.Text.ToString();
            eventArgs.Subject = Subject.Text.ToString();
            eventArgs.Teachers = new List<Teacher>()
            {
                new Teacher(Teacher.Text.ToString())
            };
            OnApointmentCreate(eventArgs);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
