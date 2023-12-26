using QueueUp.Struct;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
namespace QueueUp
{
    public partial class ApointmentPage : Page, INotifyPropertyChanged
    {
        public Apointment apointment;
        public void SetApointment(Apointment apointment)
        {
            apointment= apointment;
        }
        public ApointmentPage()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>
            {
                new Student("Иванов"),
            new Student("Ивов")
            };
            StudentList.ItemsSource = Students;
        }
        private ObservableCollection<Student> students = new ObservableCollection<Student>();
       public ObservableCollection<Student> Students
        {
            get {
                return students;
            }
            set
            {
                students = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public delegate void Notify();
        public event Notify? Skip_Clicked,End_Click;
        private void SkipBtn_Click(object sender, RoutedEventArgs e)
        {
            Skip_Clicked?.Invoke();
        }private void EndpBtn_Click(object sender, RoutedEventArgs e)
        {
            End_Click?.Invoke();
        }

        //private ObservableCollection<string> GetNames()
        //{
        //    ObservableCollection<string> names = new ObservableCollection<string>();
        //    foreach (Student student in students) names.Add(student.Name);
        //    return names;
        //}
    }

    //private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{

    //}
}

