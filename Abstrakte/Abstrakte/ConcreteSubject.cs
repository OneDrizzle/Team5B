using System;
using System.Collections.Generic;
using System.Text;

namespace Abstrakte
{
    public class ConcreteSubject : Subject
    {
        private int state = 0;
        public int State { get { return state; } set { state = value; Notify(); } } 

    //    public override void Notify()
    //    {
    //        foreach (Observer o in Observers)
    //        {
    //            o.Update();
    //            Console.WriteLine("Studerende {0} modtog nyheden {1} fra akademiet {2}",
    //                                Student.Name, student.Message, student.Academy);
    //        }
    //    }

    }
}
