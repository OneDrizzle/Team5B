using System;
using System.Collections.Generic;
using System.Text;

namespace Morgengry
{
    public class Book
    {
        public string ItemId
        { get; set; }

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
        public Book(string itemId, String Title)
        : this(itemId, Title, 0)
        { }
        public Book(string itemId)
        : this(itemId,"",0)
        { }

        public override string ToString()
        {
            return $"ItemId: {ItemId}, Title: {Title}, Price: {Price}";
        }
    }
}
