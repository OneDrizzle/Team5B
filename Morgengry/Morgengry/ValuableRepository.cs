using System;
using System.Collections.Generic;
using System.IO;

namespace Morgengry
{
    public class ValuableRepository : IPersistable
    {      
        private List<IValuable> valuables = new List<IValuable>();
        private List<string> fileLines = new List<string>();

        public void AddValuable(IValuable valuable)
        {
            valuables.Add(valuable);
        }
        public IValuable GetValuable(string id)
        {
            foreach (IValuable item in valuables)
            {
                if (item is Course course)
                {
                    if (course.Name == id)
                    {
                        return item;
                    }
                }
                else if (item is Merchandise merchandise)
                {
                    if (merchandise.ItemId == id)
                    {
                        return item;
                    }
                }


            }
            return null;
        }

        //public double GetValue(object item)
        //{
        //    if (item is Merchandise merch)
        //    {
        //        if (merch is Book book)
        //        {
        //            return book.GetValue();
        //        }
        //        else if (merch is Amulet amulet)
        //        {
        //            return amulet.GetValue();
        //        }
        //    }
        //    else if (item is Course course)
        //    {
        //        return course.GetValue();
        //    }
        //    return 0;
        //}

        public double GetTotalValue()
        {
            double value = 0;
            foreach (IValuable item in valuables)
            {
                value += item.GetValue();
            }
            return value;
        }
        public int Count()
        {
            return valuables.Count;
        }

        public void Save()
        {
            StreamWriter writer = new StreamWriter("ValueableRepository.txt", false);
            foreach (var item in valuables)
            {
                writer.WriteLine(item.CreateLineToSave());
            }
            writer.Close();
        }

        public void Save(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName, false);
            foreach (var item in valuables)
            {
                writer.WriteLine(item.CreateLineToSave());
            }
            writer.Close();
        }

        public void Load()
        {
            string objectType;
            fileLines.Clear();
            StreamReader reader = new StreamReader("ValueableRepository.txt");

            while (reader.EndOfStream == false)
            {
                fileLines.Add(reader.ReadLine());
            }
            reader.Close();

            foreach (var line in fileLines)
            {
                objectType = line.Remove(line.IndexOf(";"));

                if (objectType == "BOOK")
                {
                    string id = objectType.Remove(objectType.IndexOf(";"));
                    string title = id.Remove(id.IndexOf(";"));
                    string price = title.Remove(title.IndexOf(";"));

                    valuables.Add(new Book(id, title, Convert.ToDouble(price)));

                    //Book book = new Book(id, title, Convert.ToDouble(price));
                    //valuables.Add(book);

                }

                else if (objectType == "AMULET")
                {
                    string id = objectType.Remove(objectType.IndexOf(";"));
                    string design = id.Remove(id.IndexOf(";"));
                    Level quality = Level.medium;

                    switch (design.Remove(design.IndexOf(";")))
                    {
                        case "low": quality = Level.low; break;
                        case "medium": quality = Level.medium; break;
                        case "high": quality = Level.high; break;
                    }

                    valuables.Add(new Amulet(id, quality, design));

                    //Amulet amulet = new Amulet(id, quality, design);
                    //valuables.Add(amulet);
                }

                else if (objectType == "COURSE")
                {
                    string name = objectType.Remove(objectType.IndexOf(";"));
                    string duration = name.Remove(name.IndexOf(";"));
                    string value = duration.Remove(duration.IndexOf(";"));

                    valuables.Add(new Course(name, Convert.ToInt32(duration)));

                    //Course course = new Course(name, Convert.ToInt32(duration));

                    //course.DurationInMinutes = Convert.ToInt32(value);
                    //valuables.Add(course);
                }


            }

        }


        public void Load(string fileName)
        {

            string objectType;
            fileLines.Clear();
            StreamReader reader = new StreamReader(fileName);

            while (reader.EndOfStream == false)
            {
                fileLines.Add(reader.ReadLine());
            }
            reader.Close();

            foreach (var line in fileLines)
            {
                objectType = line.Remove(line.IndexOf(";"));

                if (objectType == "BOOK")
                {
                    string id = objectType.Remove(objectType.IndexOf(";"));
                    string title = id.Remove(id.IndexOf(";"));
                    string price = title.Remove(title.IndexOf(";"));

                    valuables.Add(new Book(id, title, Convert.ToDouble(price)));
                }

                else if (objectType == "AMULET")
                {
                    string id = objectType.Remove(objectType.IndexOf(";"));
                    string design = id.Remove(id.IndexOf(";"));
                    Level quality = Level.medium;

                    switch (design.Remove(design.IndexOf(";")))
                    {
                        case "low": quality = Level.low; break;
                        case "medium": quality = Level.medium; break;
                        case "high": quality = Level.high; break;
                    }

                    valuables.Add(new Amulet(id, quality, design));
                }

                else if (objectType == "COURSE")
                {
                    string name = objectType.Remove(objectType.IndexOf(";"));
                    string duration = name.Remove(name.IndexOf(";"));
                    string value = duration.Remove(duration.IndexOf(";"));

                    valuables.Add(new Course(name, Convert.ToInt32(duration)));                  
                }


            }

        }

    }
}


