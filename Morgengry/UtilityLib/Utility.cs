using Morgengry;
using System;


namespace UtilityLib
{
    public static class Utility
    {
        public static double GetValueOfBook(Book book)
        {
            return book.Price;
        }
        public static double GetValueOfAmulet(Amulet amulet)
        {
            switch (amulet.Quality)
            {
                case Level.low:
                    return 12.5;
                case Level.medium:
                    return 20.0;
                case Level.high:
                    return 27.5;
            }
            return 0;
        }
        public static double GetValueOfCourse(Course course)
        {
            return Math.Ceiling(((double)course.DurationInMinutes / 60)) * 875;
        }
    }
}
