using System;
using System.Collections.Generic;
using System.Text;

namespace Abstrakte
{
    public class ConcreteObserver : Observer
    {

        private ConcreteSubject subject { get; set; }

        public int State { get; set; } = 0;

        public ConcreteObserver(ConcreteSubject subject)
        { this.subject = subject; }

        public override void Update()
        { State = subject.State; }


    }
}
