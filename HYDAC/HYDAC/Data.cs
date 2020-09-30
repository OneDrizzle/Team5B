using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HYDAC
{
    public class Data
    {


        static public int EmployeeCount() //Tæller antal emplyess til stede
        {
            StreamReader reader = new StreamReader("Data_Employee.txt");
            string line = "";
            string moodvalue;
            int count = 0;
            while (reader.EndOfStream == false)
            {

                line = reader.ReadLine();
                moodvalue = line.Substring(line.LastIndexOf(",") + 1);

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
            StreamReader reader = new StreamReader("Data_Guest.txt");
            string line = "";
            string present;
            int count = 0;
            while (reader.EndOfStream == false)
            {

                line = reader.ReadLine();
                present = line.Substring(line.LastIndexOf(",") + 1);

                if (present == "true")
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


        static public void RemoveGuestFromTXT(string name)
        {
            string line = "";
            string templine = "";
            int count = 0;
            StreamReader reader = new StreamReader("Data_Guests.txt");
            while (reader.EndOfStream == false)
            {
                line = reader.ReadLine();
                count++;
            }
            reader.Close();

            string[] arr = new string[count];
            reader = new StreamReader("Data_Guests.txt");
            for (int i = 0; i < count; i++)
            {
                line = reader.ReadLine();
                templine = line.Substring(line.IndexOf(",") + 1);
                templine = templine.Remove(templine.IndexOf(","));
                if (templine != name)
                {
                    arr[i] = line;
                }


            }
            reader.Close();
            StreamWriter writer = new StreamWriter("Data_Guests.txt");
            for (int i = 0; i < count; i++)
            {

                if (!String.IsNullOrEmpty(arr[i]))
                {
                    writer.WriteLine(arr[i]);
                }
            }
            writer.Close();
        }

        static public void AddGuestToTXT(Guest guest, Employee employee)
        {
            string GuestInfo = "";

            GuestInfo += employee.GetName();
            GuestInfo += "," + guest.Name;
            GuestInfo += "," + guest.Phone;
            GuestInfo += "," + guest.Mail;
            GuestInfo += "," + guest.Present;

            StreamWriter writer = new StreamWriter("Data_Guests.txt");
            writer.WriteLine();
            writer.Close();
        }

        static public void EmployeeSetMood(string name, int mood)
        {
            int lineCount = 0;
            string line = "";
            string newLine = "";
            StreamReader reader = new StreamReader("Data_Employees.txt", true);
            while (reader.EndOfStream == false)
            {
                lineCount++;
                

            }
            reader.Close();
            string[] linjer = new string[lineCount];
            reader = new StreamReader("Data_Employees.txt", true);
            for (int i = 0; i < lineCount; i++)
            {
                line = reader.ReadLine();
                newLine = line.Remove(line.IndexOf(","));
                if (newLine == name)
                {
                    newLine += "," + mood;
                    linjer[i] = newLine;
                }
                else
                {
                    linjer[i] = reader.ReadLine();
                }
            }
            reader.Close();

            StreamWriter writer = new StreamWriter("Data_Employees.txt");
            for (int i = 0; i < lineCount; i++)
            {
                writer.WriteLine(linjer[i]);
            }

            
        }

    }
}
