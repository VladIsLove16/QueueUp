using QueueUp.Struct;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QueueUp
{
    public partial class ApointmentPage : Page, INotifyPropertyChanged
    {
        private Apointment apointment;
        public Apointment Apointment
        {
            get
            {
                return apointment;
            }
            set
            {
                apointment = value;
                OnApointmentChanged();
            }
        }
        public ApointmentPage()
        {
            InitializeComponent();
            apointment=new Apointment();
            DataContext= apointment;
            apointment.TeacherChanged += Apointment_TeacherChanged;
            apointment.PropertyChanged += Apointment_PropertyChanged;
            StudentList.ItemsSource = apointment.GetStudentCollection();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        
        private void Apointment_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine("e.PropertyName:" + e.PropertyName);
            UpdateInfo();
            // if (e.PropertyName == "Subject")
            //{
            //    UpdateInfo();
            //}
            //OnPropertyChanged(nameof(Apointment));
            //apointment.Teacher.
            //UpdateTeacherName();
        }
        private void UpdateInfo()
        {
            UpdateTeacherName();
            UpdateSubjectText();
        }
        private void Apointment_TeacherChanged(object? sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine("e.PropertyName:" + e.PropertyName);
            if (e.PropertyName == "Name")
            {
                UpdateTeacherName();
            }
        }
        private void OnApointmentChanged()
        {
            UpdateInfo();
            StudentList.ItemsSource = apointment.GetStudentCollection();
        }
        private void UpdateSubjectText()
        {
             Subject.Text = apointment.Subject?.ToString??"Предмет не определён";
        }

        private void UpdateTeacherName()
        {
            TeacherName.Text = apointment.Teacher?.ToString?? "Учитель не выбран";
        }
        public delegate void BtnClickNotify();
        public event BtnClickNotify? Skip_Clicked,End_Click;
        int num = 1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //apointment.Subject = "aaa";
            apointment.AddStudent(new Student() { Name = num++.ToString() });
        }

        private void SkipBtn_Click(object sender, RoutedEventArgs e)
        {
            Skip_Clicked?.Invoke();
        }
        private void EndpBtn_Click(object sender, RoutedEventArgs e)
        {
            End_Click?.Invoke();
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Регулярное выражение, которое разрешает только цифры
            Regex regex = new Regex("[^0-9]+");

            // Если вводимый текст не является цифрой, отменяем ввод
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

