using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GettingReal;

namespace MenuWindow
{
    class Utility
    {
        Controller ctr = new Controller();

        public Utility()
        {

        }



        public string FindFile(string orderNumber)
        {
            string targetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = @"GettingReal\GettingReal\Aggregates\";

            int indexOfPath = targetPath.IndexOf("GettingReal");
            if (indexOfPath >= 0)
                targetPath = targetPath.Remove(indexOfPath);
            string destFile = System.IO.Path.Combine(targetPath, path);

            return destFile;
        }

        public (int count, string filetype) NumberOfFiles(string orderNumber)
        {
            int count = 0;
            string filename = "";
            string destFile = FindFile(orderNumber);

            DirectoryInfo dir = new DirectoryInfo(destFile);
            FileInfo[] files = dir.GetFiles(orderNumber + "*", SearchOption.TopDirectoryOnly);

            foreach (FileInfo fileFound in files)
            {
                filename = fileFound.Name;
                count++;
            }
            return (count, filename);
        }







    }
}
