﻿using Abstrakte;
using System;
using System.Collections.Generic;
using System.Text;

namespace UCL
{
    public class Student : Person , IObserver
    {
        private string message;
        private string name;
        private Academy academy;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public Student(Academy academy, string name) : base(name)
        {
            this.name = name;
            this.academy = academy;
        }

        public void Update()
        {
            message = academy.Message;
            Console.WriteLine("Studerende {0} modtog nyheden {1} fra akademiet {2}",
                                          Name,             Message,        academy.Name);
        }
    }
}
