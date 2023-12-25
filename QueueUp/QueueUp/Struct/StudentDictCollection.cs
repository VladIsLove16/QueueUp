using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUp.Struct
{
    [Serializable]
    internal class StudentDictCollection //: //ICollection<Student> интересненько
    {
        private Dictionary<string, Student> StudentList = new Dictionary<string, Student>();

        public Student this[string Name]
        {
            get
            {
                return StudentList[Name];
            }
            set
            {
                StudentList[Name] = value;
            }
        }
        public List<Student> Get()
        {
            return StudentList.Values.ToList();
        }

        public void Set(Dictionary<string, Student> a)
        {
            StudentList = a;
        }
        public void Set(List<Student> list)
        {
            foreach (Student student in list) { StudentList[student.Name] = student; }
        }

        public int StudentCount
        {
            get { return StudentList.Count; }
        }
        public void Add(Student student)
        {
            StudentList[student.Name] = student;
        }
        public bool Contains(string Name)
        {
            return StudentList.ContainsKey(Name);
        }
        public bool Contains(Student student)
        {
            return StudentList.ContainsKey(student.Name);
        }
        public void Clear()
        {
            StudentList = new Dictionary<string, Student>();
        }
        public List<string> GetNames()
        {
            if (StudentList.Count == 0) return new List<string>();
            List<string> names = new List<string>();
            foreach (var student in StudentList)
            {
                names.Add(student.Value.Name);
            }
            return names;
        }
    }
}
