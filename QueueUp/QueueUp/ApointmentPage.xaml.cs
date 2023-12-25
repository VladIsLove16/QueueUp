using QueueUp.Struct;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ApointmentList.xaml
    /// </summary>
    public partial class ApointmentList : Page
    {
        public ObservableCollection<Student> Students = new ObservableCollection<Student>();
        
        public ApointmentList()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>
            {
                new Student("Иванов")
            };
        }

        //private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
    }
}
