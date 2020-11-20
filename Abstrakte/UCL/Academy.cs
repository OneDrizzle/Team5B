using System.Collections.Generic;

namespace UCL
{
    public class Academy : Organization, ISubject
    {
        private string name;
        private List<IObserver> students;

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; Notify(); }
        }


        public Academy(string name, string address) : base(name)
        {
            students = new List<IObserver>();
            this.name = name;
            Address = address;
        }

        public void Attach(IObserver o)
        { students.Add(o); }
        public void Detach(IObserver o)
        { students.Remove(o); }
        public void Notify()
        {
            foreach (var student in students)
            {
                student.Update();
            }
        }
    }
}
