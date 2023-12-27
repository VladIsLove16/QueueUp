using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUp.Struct
{
    public class Note
    {

        public string Comment { get; set; }
        public int LabCount { get; set; }
        public bool bCourseProject;
        public string BCourseProject
        {
            get
            {
                return bCourseProject == true ? "Курсовой" : "Не курсач";
            }
        }

        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}
