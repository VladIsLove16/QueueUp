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
    //1. Navigation.extraData
    //2. NavigationClass
    
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        Server_Main_ server=new Server_Main_();
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Apointment> MainWindowAppointments { get; private set; }

        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        ApointmentPage apointmentmentPage=new ApointmentPage();
        ApointmentCreator apointmentCreator=new ApointmentCreator();
        StudentCreator studentCreator = new StudentCreator();
        AllAppointments allAppointments=new AllAppointments();
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            apointmentCreator.ApointmentCreate += apointmentCreator_AppointmentCreated;
            studentCreator.StudentSignUp += StudentCreator_SignUpForAppointment;
            allAppointments.Reload_Clicked += allAppointments_Reloadbtn_Clicked;
            server.AppointmentCollectionChanged += server_AppointmentCollectionChanged;
            apointmentmentPage.End_Click += apointmentmentPage_EndClick;
            apointmentmentPage.Skip_Clicked += apointmentmentPage_SkipClick;
            allAppointments.Apointment_Choosed += allAppointments_Apointment_Choosed;
            allAppointments.Apointment_SignUp += allAppointments_Apointment_SignUp;
            allAppointments.Apointment_Finish += allAppointments_Apointment_Finish;
            //вот здесь реально не понимаю как сделать нужно
            // allAppointments.Apointments = MainWindowAppointments;
        }

        private void allAppointments_Apointment_Finish(Apointment a)
        {
            server.OnFinish_Appointment(a);
        }

        private void allAppointments_Apointment_SignUp(Apointment a)
        {
            studentCreator.SelectedApointment = a;
            mainFrame.Navigate(studentCreator);
        }

        private void allAppointments_Apointment_Choosed(Apointment a)
        {
            apointmentmentPage.Apointment = a;
            mainFrame.Navigate(apointmentmentPage);
        }

        private void apointmentmentPage_EndClick()
        {
            apointmentmentPage.Apointment.EndStudent();
        }

        private void apointmentmentPage_SkipClick()
        {
            apointmentmentPage.Apointment.SkipStudent();
        }
      
        private void LoadServerAppointments()
        {
            Debug.WriteLine("Загрузка данных с сервера...");
           
            ObservableCollection<Apointment> apointments = server.GetAppointmentCollection().GetObservableCollection();
            if (apointments == null) { Debug.WriteLine("Попытка загрузки данных с сервера провалилась"); return; }
            allAppointments.Apointments = apointments;
            Debug.WriteLine("Данные загружены успешно");
        }
        #region Events
        public void apointmentCreator_AppointmentCreated(object sender, ApointmentCreatedEventArgs e)
        {
            server.OnAppointmentCreated(sender, e);
            mainFrame.Navigate(allAppointments);
        }
        public void StudentCreator_SignUpForAppointment(object sender, StudentSignUpEventArgs e)
        {
            if (allAppointments.SelectedApoinmtent == null) { MessageBox.Show("Сначала выберите встречу!"); return; }
            server.OnStudentSignUp(sender, e);
            mainFrame.Navigate(allAppointments);
        }
        private void server_AppointmentCollectionChanged()//server->MyAppointments
        {
            LoadServerAppointments();
        }
        private void allAppointments_Reloadbtn_Clicked() //MyAppointments->server>MyAppointments
        {
            LoadServerAppointments();
        }
        #endregion
        #region Navigation
        private void NavigateToMyAppointment(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(apointmentmentPage);
        }
        private void NavigateToAllAppointments(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(allAppointments);
        }
        private void CreateAppointment_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(apointmentCreator);
        }private void CreateStudent_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(studentCreator);
        }
        #endregion
    }
}
