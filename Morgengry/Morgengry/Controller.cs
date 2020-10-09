using System.Collections.Generic;

namespace Morgengry
{
    public class Controller
    {
        public List<Book> Books;
        public List<Amulet> Amulets;

        public Controller()
        {
            Books = new List<Book>();
            Amulets = new List<Amulet>();
        }

        public void AddToList(Book book)
        {
            Books.Add(book);
        }

        public void AddToList(Amulet amulet)
        {
            Amulets.Add(amulet);
        }
    }
}
