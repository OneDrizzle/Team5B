using System;
using System.Collections.Generic;
using System.Text;

namespace Morgengry
{
    public class Book : Merchandise
    {
        public string Title
        { get; set; }


        public double Price
        { get; set; }

        public Book(string itemId, string Title, double Price)
        {
            ItemId = itemId;
            this.Title = Title;
            this.Price = Price;
        }
        public Book(string itemId, string Title)
        : this(itemId, Title, 0)
        { }
        public Book(string itemId)
        : this(itemId,"",0)
        { }

        public override string ToString()
        {
            return $"ItemId: {ItemId}, Title: {Title}, Price: {Price}";
        }

        public override double GetValue()
        {
            return Price;
        }
    }
}
