using QueueUp.Struct;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для StudentCreator.xaml
    /// </summary>
    public partial class StudentCreator : Page
    {
        public delegate void StudentSignUpEventHandler(object sender, StudentSignUpEventArgs e);
        public event StudentSignUpEventHandler? StudentSignUp;
        private Apointment? selectedApointment;
        public Apointment SelectedApointment
        {
            get
            {
                if (selectedApointment!=null)return selectedApointment;
                if (selectedApointment == null) MessageBox.Show("apointment==null");
                return new Apointment();
                        
            }
            set
            {
                selectedApointment=value;
                OnAppointmentChanged();
            }
        }

        private void OnAppointmentChanged()
        {
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            ApointmentDate.Text = SelectedApointment.Date;
            ApointmentGroup.Text = SelectedApointment.Group.ToString;
            ApointmentCabinet.Text = SelectedApointment.Cabinet.ToString();
        }

        public StudentCreator()
        {
            InitializeComponent();
        }
        private void SignUpForAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (selectedApointment == null) { Debug.WriteLine("Данная встреча не существует"); return; }
            StudentSignUpEventArgs eventArgs = new StudentSignUpEventArgs();
            eventArgs.student = new Student()
            {
                Group = new StudentGroup() { Number = Group.Text.ToString() },
                Name = Name.Text.ToString(),
                Note = new Note()
                {
                    Comment = Comment.Text.ToString(),
                    Teacher = new Teacher(Teacher.Text.ToString()),
                    LabCount = Int32.Parse(LabCount.Text.ToString()),
                    bCourseProject = (bool)bCourseProject.IsChecked,
                    Subject = new Subject(Subject.Text.ToString())
                }
            };
            eventArgs.Apointment = selectedApointment;
            StudentSignUp?.Invoke(this, eventArgs);
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Регулярное выражение, которое разрешает только цифры
            Regex regex = new Regex("[^0-9-]+");

            // Если вводимый текст не является цифрой, отменяем ввод
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
