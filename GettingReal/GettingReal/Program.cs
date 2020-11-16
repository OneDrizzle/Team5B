using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GettingReal
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller ct = new Controller();
            string building = "Scandic";
            string customer = "Jens";
            string aggregate = "1234";
            ct.AddTest(customer, building, aggregate);
            ct.AddTest("per", "bygning2", "4567");
            ct.Show();

            string filePath = "testSerialize.save";
            DataSerializer dataSerializer = new DataSerializer();
            Controller testCT = null;

            dataSerializer.BinarySerialize(ct, filePath);
            testCT = dataSerializer.BinaryDeserialize(filePath) as Controller;

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
