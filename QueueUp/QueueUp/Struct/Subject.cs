using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUp.Struct
{
    public class Subject
    {
        private string Title;
        public new string ToString
            {
            get
            {
                return Title;
            }
        }

        public Subject() { Title = "OOP"; }
        public Subject(string a) { Title = a; }
    }
}
