using Abstrakte;
using System;
using System.Collections.Generic;
using System.Text;

namespace UCL
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Academy("UCL");

            var s1 = new Student(p, "Jens");
            var s2 = new Student(p, "Niels");
            var s3 = new Student(p, "Susan");

            p.Attach(s1);
            p.Attach(s2);
            p.Attach(s3);

            p.Message = "Så er der julefrokost!";

            p.Detach(s2);

            p.Message = "Så er der fredagsbar!";
        }

    }
}
