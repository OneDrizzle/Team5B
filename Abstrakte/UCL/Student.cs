using Abstrakte;
using System;
using System.Collections.Generic;
using System.Text;

namespace UCL
{
    public class Student : Person , IObserver
    {
        private string message;
        private string name;
        

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public Student(string name) : base(name)
        {
            this.name = name;
        }

        public void Update(object sender , EventArgs e)
        {
            Academy ac = sender as Academy;
            message = ac.Message;
            Console.WriteLine("Studerende {0} modtog nyheden {1} fra akademiet {2}",
                                          Name,             Message,        ac.Name);
        }
    }
}
