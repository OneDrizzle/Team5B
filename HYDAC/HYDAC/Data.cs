using System;
using System.Collections.Generic;

using System.Text;
using System.IO;

namespace HYDAC
{
    public class Data
    {


        static public int NrOfEmployess() // Tæller antal medarbejdere i alt, lige meget om de er til stede eller ej
        {
            int lineCount = 0;
            StreamReader reader = new StreamReader("Data_Employees.txt");
            while (reader.EndOfStream == false) // Løber hele tekstfilen igennem
            {
                reader.ReadLine();
                lineCount++;
            }
            reader.Close();
            return lineCount;
        }

        static public string EmployeeNameList(int plads) // laver et array med medarbejder navne og giver navnet på en bestemt plads tilbage
        {
            int employeeCount = NrOfEmployess();
            string line = "";
            string[] arr = new string[employeeCount];
            StreamReader reader = new StreamReader("Data_Employees.txt");
            for (int i = 0; i < employeeCount; i++)
            {
                line = reader.ReadLine();
                line = line.Remove(line.LastIndexOf(",")); // Fjerner alt efter det sidste ',' i linjen fra tekstfilen
                arr[i] = line;
            }
            reader.Close();

            return arr[plads];
        }

        static public int EmployeeMoodList(int plads) // laver et array med medarbejderes humør og giver humøret på en bestemt plads i arrayet tilbage
        {
            int employeeCount = NrOfEmployess();
            string line = "";
            int[] arr = new int[employeeCount];
            StreamReader reader = new StreamReader("Data_Employees.txt");
            for (int i = 0; i < employeeCount; i++)
            {

                line = reader.ReadLine();
                line = line.Substring(line.Length - 1, 1); // Tager den sidste character fra linjen taget fra tekstfilen
                arr[i] = int.Parse(line); // Siden den sidste character er et tal, så ændres det lige til en int
            }
            reader.Close();

            return arr[plads];
        }


        static public int NrOfGuests() // Tæller antal gæster i alt, lige meget om de er til stede eller ej
        {
            int lineCount = 0;
            StreamReader reader = new StreamReader("Data_Guests.txt");
            while (reader.EndOfStream == false) // Løber hele tekstfilen igennem
            {
                reader.ReadLine();
                lineCount++;
            }
            reader.Close();
            return lineCount;
        }

        static public int GuestPerSpecificEmployee(string employeeName) // Tæller antal gæster tilhørende en bestemt medarbejder
        {
            int lineCount = 0;
            string line = "";
            StreamReader reader = new StreamReader("Data_Guests.txt");
            while (reader.EndOfStream == false) // Løber hele tekstfilen igennem
            {
                line = reader.ReadLine();
                if (employeeName == line.Remove(line.IndexOf(","))) // Tager første bid af teksfilen indtil første komma, og tæller kun hvis det passer til medarbejderes navn
                {
                    lineCount++;
                }
            }
            reader.Close();

            return lineCount;
        }

        static public string GuestNameList(string employeeName, int plads) // laver et array med gæsters humør og giver humøret på en bestemt plads i arrayet tilbage
        {
            int guestCount = GuestPerSpecificEmployee(employeeName);
            string line = "";
            string[] arr = new string[guestCount];
            int arrPlace = 0;
            StreamReader reader = new StreamReader("Data_Guests.txt");
            for (int i = 0; i < NrOfGuests(); i++)
            {

                line = reader.ReadLine();

                if (employeeName == line.Remove(line.IndexOf(",")))
                {
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Remove(line.IndexOf(",")); // Fjerner alt efter første komma
                    arr[arrPlace] = line;
                    arrPlace++;
                }
            }
            reader.Close();

            return arr[plads];
        }

        static public string GuestTLFList(string employeeName, int plads) // laver et array med gæsters TLF og giver TLF på en bestemt plads i arrayet tilbage
        {
            int guestCount = GuestPerSpecificEmployee(employeeName);
            string line = "";
            string[] arr = new string[guestCount];
            int arrPlace = 0;
            StreamReader reader = new StreamReader("Data_Guests.txt");
            for (int i = 0; i < NrOfGuests(); i++)
            {
                line = reader.ReadLine();

                if (employeeName == line.Remove(line.IndexOf(",")))
                {
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Remove(line.IndexOf(",")); // Fjerner alt efter første komma
                    arr[arrPlace] = line;
                    arrPlace++;
                }
            }
            reader.Close();

            return arr[plads];
        }

        static public string GuestMailList(string employeeName, int plads) // laver et array med gæsters mail og giver mail på en bestemt plads i arrayet tilbage
        {
            int guestCount = GuestPerSpecificEmployee(employeeName);
            string line = "";
            string[] arr = new string[guestCount];
            int arrPlace = 0;
            StreamReader reader = new StreamReader("Data_Guests.txt");
            for (int i = 0; i < NrOfGuests(); i++)
            {
                line = reader.ReadLine();

                if (employeeName == line.Remove(line.IndexOf(",")))
                {
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Remove(line.IndexOf(",")); // Fjerner alt efter første komma
                    arr[arrPlace] = line;
                    arrPlace++;
                }
            }
            reader.Close();

            return arr[plads];
        }

        static public string GuestRoomList(string employeeName, int plads) // laver et array med gæsters lokale og giver lokalet på en bestemt plads i arrayet tilbage
        {
            int guestCount = GuestPerSpecificEmployee(employeeName);
            string line = "";
            string[] arr = new string[guestCount];
            int arrPlace = 0;
            StreamReader reader = new StreamReader("Data_Guests.txt");
            for (int i = 0; i < NrOfGuests(); i++)
            {
                line = reader.ReadLine();

                if (employeeName == line.Remove(line.IndexOf(",")))
                {
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Remove(line.IndexOf(",")); // Fjerner alt efter første komma
                    arr[arrPlace] = line;
                    arrPlace++;
                }
            }
            reader.Close();

            return arr[plads];
        }

        static public string GuestPresentList(string employeeName, int plads) // laver et array med gæsters tilstedeværelse og giver tilstædeværelsen på en bestemt plads i arrayet tilbage
        {
            int guestCount = GuestPerSpecificEmployee(employeeName);
            string line = "";
            string[] arr = new string[guestCount];
            int arrPlace = 0;
            StreamReader reader = new StreamReader("Data_Guests.txt");
            for (int i = 0; i < NrOfGuests(); i++)
            {
                line = reader.ReadLine();

                if (employeeName == line.Remove(line.IndexOf(",")))
                {
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    line = line.Substring(line.IndexOf(",") + 1); // Fjerner alt før første komma
                    arr[arrPlace] = line;
                    arrPlace++;
                }
            }
            reader.Close();

            return arr[plads];
        }



        static public int EmployeeCount() //Tæller antal medarbejdere til stede
        {
            StreamReader reader = new StreamReader("Data_Employees.txt");
            string line = "";
            string moodvalue;
            int count = 0;
            while (reader.EndOfStream == false)
            {

                line = reader.ReadLine();
                moodvalue = line.Substring(line.LastIndexOf(",") + 1); // Finder humøret fra tekstfilen

                if (moodvalue != "0")
                {
                    count++;
                }
            }
            reader.Close();

            return count;
        }

        static public int GuestCount() //Tæller antal gæster til stede
        {
            StreamReader reader = new StreamReader("Data_Guests.txt");
            string line = "";
            string present;
            int count = 0;
            while (reader.EndOfStream == false)
            {

                line = reader.ReadLine();
                present = line.Substring(line.LastIndexOf(",") + 1); // Finder humøret fra tekstfilen

                if (present.ToLower() == "true")
                {
                    count++;
                }
            }
            reader.Close();

            return count;
        }

        static public int TotalCount() //Antal personer i alt
        {
            return EmployeeCount() + GuestCount();
        }


        static public void RemoveGuestFromTXT(string name) // Fjerne en gæst fra tekstfilen
        {
            string line = "";
            string templine = "";
            int count = NrOfGuests();           
            string[] arr = new string[count];
            StreamReader reader = new StreamReader("Data_Guests.txt");
            for (int i = 0; i < count; i++)
            {
                line = reader.ReadLine();
                templine = line.Substring(line.IndexOf(",") + 1); // Laver en ny string med alt efter første komme i tekstfilen
                templine = templine.Remove(templine.IndexOf(",")); // Laver en ny string med alt før første komma
                if (templine != name)
                {
                    arr[i] = line;
                }


            }
            reader.Close();

            StreamWriter writer = new StreamWriter("Data_Guests.txt",false);
            for (int i = 0; i < count; i++)
            {

                if (!String.IsNullOrEmpty(arr[i])) // Tjekker om pladsen i arrayet er tom
                {
                    if (i != arr.Length-1) // Hvis ikke vi er ved sidste plads i arrayet skal vi skifte linje efter dte vi har skrevet
                    {
                        writer.WriteLine(arr[i]);
                    }
                    else 
                    {
                        writer.Write(arr[i]);
                    }
                }
            }
            writer.Close();
        }

        static public void AddGuestToTXT(Guest guest, Employee employee) // Tilføjer en gæst til tekstfilen
        {
            string GuestInfo = "";
            // Laver en string i den form vi vil have ind i tekstfilen
            GuestInfo += employee.Name;
            GuestInfo += "," + guest.Name;
            GuestInfo += "," + guest.Phone;
            GuestInfo += "," + guest.Mail;
            GuestInfo += "," + guest.GoToMeetingRoom;
            GuestInfo += "," + guest.Present;

            StreamWriter writer = new StreamWriter("Data_Guests.txt", true);
            if (new FileInfo("Data_Guests.txt").Length != 0) // Hvis filen er tom, altså der ikke er nogen gæster, så skal vi ikke skifte linje før vi tilføjer til tekstfilen
            {
                writer.WriteLine();
            }
            writer.Write(GuestInfo);
            writer.Close();
        }

        static public void EmployeeSetMood(string name, int mood) // Ændrer en medarbejders humør
        {
            int lineCount = NrOfEmployess();
            string line = "";
            string newLine = "";
            string[] linjer = new string[lineCount];
            bool check = false;
            StreamReader reader = new StreamReader("Data_Employees.txt", true);

            for (int i = 0; i < lineCount; i++)
            {
                line = reader.ReadLine();
                newLine = line.Remove(line.IndexOf(","));
                if (newLine == name && check == false) // Tjekker at navnet passer og at vi ikke allerede har ændret et humør
                {
                    newLine += "," + mood;
                    linjer[i] = newLine;
                    check = true;
                }
                else
                {
                    linjer[i] = line;
                }
            }
            reader.Close();

            StreamWriter writer = new StreamWriter("Data_Employees.txt");
            for (int i = 0; i < lineCount; i++)
            {
                if (i != lineCount - 1) // Hvis vi er nået til sidste linje skal vi ikke skifte linje bagefter når vi skriver ind
                {
                    writer.WriteLine(linjer[i]);
                }
                else
                {
                    writer.Write(linjer[i]);
                }
            }
            writer.Close();

        }

        static public void GuestSetPresence(string name) // Ændrer en Gæsts humør
        {
            int lineCount = NrOfGuests();
            string line = "";
            string newLine = "";
            string[] linjer = new string[lineCount];
            bool check = false;
            StreamReader reader = new StreamReader("Data_Guests.txt");

            for(int i = 0 ; i < lineCount ; i++ )
            {
                line = reader.ReadLine();
                newLine = line.Substring(line.IndexOf(",")+1);
                newLine = newLine.Remove(newLine.IndexOf(","));
                if (newLine == name && check == false)
                {
                    newLine = line.Remove(line.LastIndexOf(","));
                    newLine += "," + "true";
                    linjer[i] = newLine;
                    check = true;
                }
                else
                {
                    linjer[i] = line;
                }
            }
            reader.Close();

            StreamWriter writer = new StreamWriter("Data_Guests.txt");
            for (int i = 0; i < lineCount; i++)
            {
                if (i != lineCount - 1)
                {
                    writer.WriteLine(linjer[i]);
                }
                else 
                {
                    writer.Write(linjer[i]);
                }
            }
            writer.Close();


        }

    }
}
