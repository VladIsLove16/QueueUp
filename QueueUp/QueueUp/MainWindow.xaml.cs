using QueueUp.Struct;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        Server_Main_ server=new Server_Main_();
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        ApointmentPage apointmentmentPage=new ApointmentPage();
        ApointmentCreator apointmentCreator=new ApointmentCreator();
        MyAppointments myAppointments=new MyAppointments();
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            apointmentCreator.ApointmentCreate += OnAppointmentCreated;
            myAppointments.Reload_Clicked += OnReloadAppointmentClicked;
            server.AppointmentCollectionChanged += OnAppointmentCollectionChanged;
        }

        

        private void CreateAppointment_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(apointmentCreator);
        }

        private void NavigateToAppointment(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(apointmentmentPage);
        }
        private void OnAppointmentCollectionChanged()//server->MyAppointments
        {
            UpdateAppointments();
        }
        private void OnReloadAppointmentClicked() //MyAppointments->server>MyAppointments
        {
            UpdateAppointments();
        }
        private void UpdateAppointments()
        {
            ObservableCollection<Apointment> apointments = server.LoadAppointmentCollection().ToObservableCollection();
            if (apointments != null)
            { myAppointments.LoadAppointmentList(apointments); 
            foreach (Apointment item in apointments)
                {
                    Debug.WriteLine(item.Subject);
                }
            }

            else
            {
                Debug.WriteLine("Попытка загрузки данных с сервера провалилась");
            }
        }
        public void OnAppointmentCreated(object sender, ApointmentCreatedEventArgs e)
        {
            server.OnAppointmentCreated(sender, e);
            UpdateAppointments();
            mainFrame.Navigate(myAppointments);
        }
    }
}
