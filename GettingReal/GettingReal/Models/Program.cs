using System;
using System.Collections.Generic;
using System.Text;
using GettingReal.ViewModels;

namespace GettingReal.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            MainViewModel ct = new MainViewModel();
            string building = "Scandic";
            string customer = "Jens";
            string aggregate = "1234";
            ct.AddTest(customer, building, aggregate);
            ct.AddTest("per", "bygning2", "4567");
            ct.Show();

            string filePath = "testSerialize.save";
            MainViewModel testCT = null;

            Utility.BinarySerialize(ct, filePath);
            testCT = Utility.BinaryDeserialize(filePath) as MainViewModel;

            testCT.Show();
            Console.WriteLine();

            testCT.Show2();

            //// Serialize 
            //XmlSerializer serializer = new XmlSerializer(typeof(Controller));
            //FileStream fs = new FileStream("TestSerialize.xml", FileMode.Create);
            //serializer.Serialize(fs, ct);
            //fs.Close();
            //ct = null;

            // Deserialize 
            //serializer = new XmlSerializer(typeof(Customer));
            //fs = new FileStream("TestSerialize.xml", FileMode.Open);
            //ct = (Controller)serializer.Deserialize(fs);
            //serializer.Serialize(Console.Out, cust);


        }
    }
}
