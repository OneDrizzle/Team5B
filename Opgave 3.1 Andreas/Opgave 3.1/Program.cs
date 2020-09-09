using System;

namespace Opgave_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                /*
                Console.Write("Venligt indtast højde og brede på rektanglet: \n");
                Console.Write("Højde: ");
                string Højde = Console.ReadLine();
                Console.Write("\nBrede: ");
                string Brede = Console.ReadLine();
                int ParsedHøjde = int.Parse(Højde);
                int ParsedBrede = int.Parse(Brede);

                Console.Write("\nArealet af rektanglen er: " + ParsedHøjde * ParsedBrede);
                Console.Write("\nTryk på en tast for at fortsætte.");
                Console.Clear();
                Console.Write("Venligt indtast Veligst dine y værdier: \n");
                Console.Write("X1: ");
                string x1 = Console.ReadLine();
                Console.Write("\nY1: ");
                string y1 = Console.ReadLine();
                Console.Write("Venligt indtast Veligst dine x værdier: \n");
                Console.Write("\nX2: ");
                string x2 = Console.ReadLine();
                Console.Write("\nX2: ");
                string y2 = Console.ReadLine();



                double Parsedx1 = double.Parse(x1);
                double Parsedx2 = double.Parse(x2);
                double Parsedy1 = double.Parse(y1);
                double Parsedy2 = double.Parse(y2);
                double Yværdi = Parsedy2 - Parsedy1;
                double Xværdi = Parsedx2 - Parsedx1;


                double Hældning = (Yværdi / Xværdi);
                Console.Write("hældningen er {0}", Hældning);

                Console.ReadKey();*/

                
                Console.Write("Venligst indtast en sætning:");
                string sætning = Console.ReadLine();
                Console.Write("Sætningen er {0} Karaktere lang.", sætning.Length);
                int startIndex = 4;
                if (sætning.Length <= startIndex)
                {
                    Console.Write(" Fejl kan ikke finde Substring\nIndtast en sætning på mere end {0} tegn!", startIndex);
                }
                else
                {
                    string substring = sætning.Substring(startIndex);
                    Console.Write("\nSubstrengen er " + substring);
                }
                Console.ReadKey();
                Console.ReadKey();

                


            } while (true);
        }
    }
}
