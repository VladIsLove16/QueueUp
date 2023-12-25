using Microsoft.VisualBasic;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QueueUp.Struct
{
    public class Apointment
    {
        public string Subject { get; set; }
        public Date DateTime;
        public List<Teacher> Teachers = new List<Teacher>();
        public List<Student> Students = new List<Student>();
        public void Start()
        {


        }
    }
    
}