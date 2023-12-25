using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUp.Struct
{
    [Serializable]
    public class Student
    {
        public static int StudentCount;
        public int ID;
        public string Name;
        public string Group;
        public string LastComment;
        public Student()
        {
            StudentCount++;//не уверен что это работает как я хочу(что будет при создании временных студентов?)
            ID = StudentCount;
        }
        public Student(string name):base()
        {
            Name= name;
        }
    }
}
