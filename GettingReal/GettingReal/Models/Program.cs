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
            //Controller ct = new Controller();


            //ct.AddCustomer("Per", "Scandic Hotel");
            //Utility.BinarySerialize(ct, "Data.txt");


            //Controller testCT = null;
            //testCT = Utility.BinaryDeserialize("Data.txt") as Controller;

            //testCT.Show();
            //Console.WriteLine();

            //testCT.Show2();

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
