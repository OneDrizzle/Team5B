using System;
using System.Collections.Generic;
using System.Text;
//using UtilityLib;

namespace Morgengry
{
    public class BookRepository
    {
        private List<Book> book;

        public BookRepository()
        {
            book = new List<Book>();          
        }

        public void AddBook(Book book)
        {
            this.book.Add(book);
        }

        public Book GetBook(string itemId)
        {
            foreach (Book item in book)
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
            foreach (var item in book)
            {
                value += Utility.GetValueOfBook(item);
            }
            return value;
        }

    }
}
