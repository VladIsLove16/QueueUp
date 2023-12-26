namespace QueueUp.Struct
{
    public class Teacher
    {
        public string Name { get; set; }
        public Teacher()
        {
            this.Name = "";
        }
        public Teacher(string Name) {
            this.Name = Name;
        }
    }
}