using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QueueUp.Struct
{
    public class Apointment :INotifyPropertyChanged
    {
        private string date;
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date=value;
                OnPropertyChanged(nameof(Subject));
            }
        }
        private int cabinet;
        public int Cabinet
        {
            get
            {
                return cabinet;
            }
            set
            {
                cabinet = value;
                OnPropertyChanged(nameof(Cabinet));
            }
        }
        private DateTime dateTime;
        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
            set
            {
                dateTime = value;
                OnPropertyChanged(nameof(Subject));
            }
        }
        public string FormattedDate
        {
            get {
                string formattedDateTime = DateTime.ToString("MM-dd HH:mm");
                return formattedDateTime; }
        }
        private Subject subject;
        public Subject Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
                OnPropertyChanged(nameof(Subject));
            }
        }
        private StudentGroup group =new StudentGroup();
        public StudentGroup Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
                OnPropertyChanged(nameof(Group));
            }
        }
        private Teacher teacher = new Teacher();
        public Teacher Teacher
        {
            get
            {
                return teacher;
            }
            set
            {
                teacher = value;
                OnPropertyChanged(nameof(Teacher));
            }
        }
        private ObservableCollection<Student> students = new ObservableCollection<Student>();
        private ObservableCollection<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
                //OnPropertyChanged(nameof(Students));
            }
        }
        public Apointment()
        {
            Teacher.PropertyChanged += Teacher_PropertyChanged;
            Date ="23:59";
            Teacher= new Teacher("Default Teacher");
            Subject = new Subject("Default Subject");
            group = new StudentGroup("Default Group");
        }
        public Apointment(Subject Subject):base()
        {
            this.Subject = Subject;
        }
        public Apointment( Subject Subject, string Date, Teacher Teacher, StudentGroup Group) : base()
        {
            this.Date = Date;
            this.Subject = Subject;
            this.Teacher =Teacher;
            this.Group = Group;
        }
        public event PropertyChangedEventHandler? PropertyChanged,TeacherChanged;
        public void Teacher_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            TeacherChanged?.Invoke(this, e);
        }
        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public void Start()
        {

        }
        public void End()
        {

        }
        public ObservableCollection<Student> GetStudentCollection() { return  Students; }
        public void AddStudent(Student student)
        {
            Students.Add(student);
            //OnPropertyChanged(nameof(Students));
        }
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
            //OnPropertyChanged(nameof(Students));
        }
        public void SkipStudent()
        {
            Students.Add(Students[0]);
            Students.RemoveAt(0);
        }
        public void EndStudent()
        {
            RemoveStudent(Students[0]);
            //или например вылазит окошко с выставлением результата( на случай записи истории);
        }
    }
    
}