using System;
using System.Collections.Generic;
using System.Text;

namespace Morgengry
{
    public class ValuableRepository
    {
        private List<IValuable> valuables = new List<IValuable>();

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
        

    }
}

