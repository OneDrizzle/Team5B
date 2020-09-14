using System;

namespace Lommeregn
{
    class Program
    {
        static void Main(string[] args)
        {
            //goddag
            Calculater Calc = new Calculater();
            Console.WriteLine(Calc.Add(1, 2));
            Console.WriteLine(Calc.Subtract(5, 7));
            Console.WriteLine(Calc.Devide(8, 2));
            Console.WriteLine(Calc.Multiply(10, 3));
            Console.ReadLine();
        }
        
    }
}
