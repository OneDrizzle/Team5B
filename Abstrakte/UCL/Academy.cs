using Abstrakte;
using System;
using System.Collections.Generic;
using System.Text;

namespace UCL
{
    public class Academy : Subject
    {
        private string message;
        private string name;


        public string Message
        {
            get { return message;}
            set { message = value; Notify(); }
        }
        public string Name
        {
            get { return name; }
        }

        public Academy(string name)
        {
            this.name = name;
        }
        public override void Notify()
        {
            foreach (Observer o in Observers)
            {
                o.Update();
                Student student = o as Student;
                Console.WriteLine("Studerende {0} modtog nyheden {1} fra akademiet {2}", 
                                        student.Name, student.Message, student.Academy);
            }
        }

    }
}
