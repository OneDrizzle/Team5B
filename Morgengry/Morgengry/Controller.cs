using System.Collections.Generic;

namespace Morgengry
{
    public class Controller
    {
        AmuletRepository AmuletRep;
        BookRepository BookRep;
        CourseRepository CourseRep;
        MerchandiseRepository MerchRep;

        public List<Amulet> Amulets;
        public List<Book> Books;
        public List<Course> Courses;

        public Controller()
        {
            AmuletRep = new AmuletRepository();
            BookRep = new BookRepository();
            CourseRep = new CourseRepository();
            MerchRep = new MerchandiseRepository();
        }

        public void AddToList(object obj)
        {
            
            if(obj is Merchandise merch)
            {
                MerchRep.AddMerchandise(merch);
            }
            //if(obj is Amulet amulet)
            //{
            //    AmuletRep.AddAmulet(amulet);
            //}
            //else if (obj is Book book)
            //{
            //    BookRep.AddBook(book);
            //}
            else if (obj is Course course)
            {
                CourseRep.AddCourse(course);
            }

        }


    }
}
