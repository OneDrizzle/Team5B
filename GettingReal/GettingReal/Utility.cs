using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace GettingReal
{
    public static class Utility
    {
        // Finds file destination and path
        public static (string destFile, string targetPath) FindFile()
        {
            //Copy file to userdefined folder
            string targetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            string path = @"GettingReal\GettingReal\Aggregates\";
            //looks for the first instance of "GettingReal" in the path.
            //Removes "GettingReal" and inputs the path so the path is the same as "TargetPath + path"
            int indexOfPath = targetPath.IndexOf("GettingReal");
            if (indexOfPath >= 0)
                targetPath = targetPath.Remove(indexOfPath);
            //Combines the two paths togehter and sets \\ in Automaticly so it's a full and useable path
            string destFile = System.IO.Path.Combine(targetPath, path);

            return (destFile, targetPath);
        }

        // Counts the number of files in folder based on a path found by FindFile()
        public static (int count, string filetype) NumberOfFiles(string orderNumber)
        {
            int count = 0;
            string filename = "";
            (string destFile, string targetPath) = FindFile();

            DirectoryInfo dir = new DirectoryInfo(destFile);
            FileInfo[] files = dir.GetFiles(orderNumber + "*", SearchOption.TopDirectoryOnly);

            foreach (FileInfo fileFound in files)
            {
                filename = fileFound.Name;
                count++;
            }
            return (count, filename);
        }

        // Saves file in specific folder, with file being renamed by ordernumber and filename (orderNumber_justFileName)
        public static void SaveFile(string sourcePath, string orderNumber, string justFileName)
        {
            (string destFile, string targetPath) = FindFile();

            // if there is no Directory named Aggregates it creates one
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            //the next code takes the file that need's to be copied and copies it into the "DestinationDirectory" folder
            //and adds the OrderNumber at the end so we can search for it later
            File.Copy(sourcePath, destFile + Path.GetFileName(sourcePath));
            string Rename = orderNumber + justFileName;

            string ScourceFile = Path.Combine(sourcePath, destFile + Path.GetFileName(sourcePath));
            FileInfo fi = new FileInfo(ScourceFile);
            if (fi.Exists)
            {
                string NewPath = Path.Combine(Rename, destFile + Path.GetFileName(Rename));
                fi.MoveTo(NewPath);
            }
        }

        // Serializer to save data
        public static void BinarySerialize(object data, string filePath)
        {
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath)) File.Delete(filePath);
            fileStream = File.Create(filePath);
            bf.Serialize(fileStream, data);
            fileStream.Close();
        }

        // method to load serialized data
        public static object BinaryDeserialize(string filePath)
        {
            object obj = null;
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                fileStream = File.OpenRead(filePath);
                if (fileStream.Length != 0) obj = bf.Deserialize(fileStream);               
                fileStream.Close();
            }
            return obj;
        }
    }
}
