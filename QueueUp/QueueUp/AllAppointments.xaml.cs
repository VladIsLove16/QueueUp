using QueueUp.Struct;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
namespace QueueUp
{
    public partial class AllAppointments : Page,INotifyPropertyChanged
    {
        private ObservableCollection<Apointment> apointments=new ObservableCollection<Apointment>();
        public ObservableCollection<Apointment>Apointments
        {
            get
            {
                    return  apointments;
            }
            set
            {
                apointments = value;
                OnAppointmentsChanged();
            }
        }

        private ObservableCollection<Apointment> allApointments = new ObservableCollection<Apointment>();
        public ObservableCollection<Apointment> AllApointments
        {
            get
            {
                return allApointments;
            }
            set
            {
                allApointments = value;
                OnPropertyChanged();
            }
        }
        private Apointment selectedApointment;
        public Apointment SelectedApoinmtent
        {
            get { return selectedApointment; }
            set {
                selectedApointment= value;
            }
        }
        public AllAppointments()
        {
            InitializeComponent();
            allApointments = new ObservableCollection<Apointment>
            {
                new Apointment(),
                new Apointment()
            };
            ApointmentsList.ItemsSource = AllApointments;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (SelectedApoinmtent == null)
            {
                Navigatebtn.IsEnabled = false;
                SignUpbtn.IsEnabled = false;
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AllApointments.Add(new Apointment());
        }
        public delegate void Notify();
        public event Notify? Reload_Clicked;
        public delegate void Selection(Apointment a);
        public event Selection? Apointment_Choosed,Apointment_SignUp, Apointment_Finish;
        private void ReloadInfo_Click(object sender, RoutedEventArgs e)
        {
            Reload_Clicked?.Invoke();
        }

        public void ApointmentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Select((Apointment)ApointmentsList.SelectedItem);
            if (SelectedApoinmtent == null)
            {
                SetButtonEnadled(false);
            }
            else
            {
                SetButtonEnadled(true);
            }
        }
       public void SetButtonEnadled(bool a)
        {
            Navigatebtn.IsEnabled = a;
            SignUpbtn.IsEnabled = a;
        }
        private void Select(Apointment selectedItem)
        {
            selectedApointment = selectedItem;
        }
        private void OnAppointmentsChanged()
        {
            ApointmentsList.ItemsSource = Apointments;
        }

        private void NavigateToApointment(object sender, RoutedEventArgs e)
        {
            Apointment_Choosed?.Invoke(selectedApointment);
        }

        private void Finish_Appoinment(object sender, RoutedEventArgs e)
        {
            Apointment_Finish?.Invoke(selectedApointment);
        }

        private void SignUpForApointment(object sender, RoutedEventArgs e)
        {
            Apointment_SignUp?.Invoke(selectedApointment);
        }
    }
}
