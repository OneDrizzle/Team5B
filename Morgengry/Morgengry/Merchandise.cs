using System;
using System.Collections.Generic;
using System.Text;

namespace Morgengry
{
    public abstract class Merchandise : IValuable
    {
        public string ItemId
            {get;set;}

        //public Merchandise(string itemId)
        //{
        //    ItemId = itemId;
        //}

        public override string ToString()
        {
            return $"ItemId: {ItemId}";
        }

        public abstract double GetValue();

        public abstract string CreateLineToSave();
       
    }
}
