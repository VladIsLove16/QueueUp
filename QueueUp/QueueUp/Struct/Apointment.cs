using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QueueUp.Struct
{
    public class Apointment
    {
        public string Subject { get; set; }
        public Date DateTime;
        public string DateTimeStr;
        public string Group { get; set; }
        private Teacher Teacher = new Teacher();
        private List<Student> Students = new List<Student>();
        public void Start()
        {

        }
       public Apointment()
        {

        }
        public Apointment(string subject)
        {
            Subject = subject;
        }
        public List<Student> GetStudents() { return  Students; }
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }
        public void SkipStudent()
        {
            Students.Add(Students[0]);
            Students.RemoveAt(0);
        }
    }
    
}