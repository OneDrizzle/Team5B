using System;
using System.Collections.Generic;
using System.Text;
//using UtilityLib;

namespace Morgengry
{
    public class AmuletRepository
    {
        private List<Amulet> amulets;

        public AmuletRepository()
        {           
            amulets = new List<Amulet>();         
        }

        public void AddAmulet(Amulet amulet)
        {
            amulets.Add(amulet);
            //Controller.Amulets = new List<Amulet> (amulets);
        }

        public Amulet GetAmulet(string itemId)
        {
            foreach (var item in amulets)
            {
                if(item.ItemId == itemId)
                {
                    return item;
                }
            }

            return null;
        }

        public double GetTotalValue()
        {
            double value = 0;
            foreach (var item in amulets)
            {
                value += Utility.GetValueOfMerchandise(item);
            }
            return value;
        }
    }
}
