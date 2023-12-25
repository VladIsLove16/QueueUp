using QueueUp.Struct;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QueueUp
{
    /// <summary>
    /// Логика взаимодействия для ApointmentList.xaml
    /// </summary>
    public partial class ApointmentPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Student> students = new ObservableCollection<Student>();
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                OnPropertyChanged();
            }
        }

        public ApointmentPage()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>
            {
                new Student("Иванов")
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
    }
}
