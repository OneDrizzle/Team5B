using Abstrakte;
using System;
using System.Collections.Generic;
using System.Text;

namespace UCL
{
    public class Student : Observer
    {
        private Academy subject;
        private string message;
        private string name;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string Name
        { 
            get { return name; } 
        }

        public Academy Academy
        {
            get { return subject; }
        }

        public Student(Academy subject, string name)
        {
            this.subject = subject;
            this.name = name;
        }

        public override void Update()
        {
            message = subject.Message;
        }
    }
}
