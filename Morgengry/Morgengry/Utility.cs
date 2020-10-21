using Morgengry;
using System;


namespace Morgengry
{
    public static class Utility
    {
        public static double LowQualityValue
        { get; set; }
        public static double MediumQualityValue
        { get; set; }
        public static double HighQualityValue
        { get; set; }
        public static double CourseHourValue
        { get; set; }

        static Utility()
        {
            LowQualityValue = 12.5;
            MediumQualityValue = 20;
            HighQualityValue = 27.5;
            CourseHourValue = 875;
        }

        public static double GetValueOfMerchandise(Merchandise merch)
        {
            if (merch is Book book)
            {
                return GetValueOfBook(book);
            }
            else if (merch is Amulet amulet)
            {
                return GetValueOfAmulet(amulet);
            }

            return 0;
        }
        public static double GetValueOfBook(Book book)
        {
            return book.Price;
        }
        public static double GetValueOfAmulet(Amulet amulet)
        {
            switch (amulet.Quality)
            {
                case Level.low:
                    return LowQualityValue;
                case Level.medium:
                    return MediumQualityValue;
                case Level.high:
                    return HighQualityValue;
                default:
                    return 0;
            }
        }
        public static double GetValueOfCourse(Course course)
        {
            return Math.Ceiling(((double)course.DurationInMinutes / 60)) * CourseHourValue;
        }
    }
}
