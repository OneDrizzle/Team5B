using System;
using System.Collections.Generic;
using System.Text;
using UtilityLib;

namespace Morgengry
{
    class MerchandiseRepository
    {
        private List<Merchandise> merchandises;

        public void AddMerchandise(Merchandise merch)
        {
            merchandises.Add(merch);
        }

        public Merchandise GetMerchandise(string itemId)
        {
            foreach (var item in merchandises)
            {
                if (item.ItemId == itemId)
                {
                    return item;
                }
            }

            return null;
        }

        public double GetTotalValue()
        {
            double value = 0;
            foreach (var item in merchandises)
            {
                value += Utility.GetValueOfMerchandise(item);
            }
            return value;
        }
    }
}
