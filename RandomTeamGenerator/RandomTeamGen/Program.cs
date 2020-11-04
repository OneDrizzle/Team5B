using System;
using System.Collections.Generic;
using System.Globalization;

namespace RandomTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rng = new Random();
            List<string> team5b = new List<string> { "Andreas", "Brian", "Daniel", "Lasse", "Maiken", "Mikkel", "Nick", "Thomas" };
            team5b.Remove("Thomas");
            //team5b.Remove("Andreas"); //muahahha

            Console.WriteLine("Indtast 1-8 antal grupper: ");
            bool groupCheck = int.TryParse(Console.ReadLine(), out int teams);
           
            while (teams < 1 || teams > 8 || !groupCheck)
            {
                Console.WriteLine("forkert indtastning, prøv igen");
                groupCheck = int.TryParse(Console.ReadLine(), out teams);
            }

            int members = team5b.Count;

            while (members > 0)
            {
                members--;
                int k = rng.Next(members + 1);
                string temp = team5b[k];
                team5b[k] = team5b[members];
                team5b[members] = temp;
            }    

            List<Team> listOfTeams = new List<Team>();
            for (int i = 0; i < teams; i++)
            {
                listOfTeams.Add(new Team($"Team {i+1}"));
            }
                        
            int tempCount = team5b.Count;
            int j = 0;
            for (int i = 0; i < tempCount; i++)
            {
                listOfTeams[j].Member.Add(team5b[i]);

                if (j == listOfTeams.Count - 1)
                    j = 0;
                else
                    j++;
            }

            Console.Clear();
            foreach (Team team in listOfTeams)
            {
                Console.WriteLine(team);
                for (int i = 0; i < team.Member.Count; i++)
                {
                    Console.Write("  " + team.Member[i]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        } 
    }
}
