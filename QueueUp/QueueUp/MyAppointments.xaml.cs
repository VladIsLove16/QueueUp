using QueueUp.Struct;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
namespace QueueUp
{
    public partial class MyAppointments : Page,INotifyPropertyChanged
    {
        public MyAppointments()
        {
            InitializeComponent();
            myApointments = new ObservableCollection<Apointment>
            {
                new Apointment("AA"),
                new Apointment("ООП")
            };
            ApointmentsList.ItemsSource = MyApointments;
        }
        private ObservableCollection<Apointment> myApointments = new ObservableCollection<Apointment>();
        public ObservableCollection<Apointment> MyApointments
        {
            get
            {
                return myApointments;
            }
            set
            {
                myApointments = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyApointments.Add(new Apointment("aa"));
        }
        public delegate void Notify();
        public event Notify? Reload_Clicked;
        private void ReloadInfo_Click(object sender, RoutedEventArgs e)
        {
            Reload_Clicked?.Invoke();
        }
        public void LoadAppointmentList(ObservableCollection<Apointment> apointments)
        {
            MyApointments.Clear();
            foreach (var item in apointments) { MyApointments.Add(item); }
        }

        
    }
}
