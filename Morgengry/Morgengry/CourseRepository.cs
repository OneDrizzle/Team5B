using System;
using System.Collections.Generic;
using System.Text;
//using UtilityLib;

namespace Morgengry
{
    public class CourseRepository
    {
        private List<Course> courses;

        public CourseRepository()
        {
            courses = new List<Course>();
        }

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public Course GetCourse(string itemId)
        {
            foreach (var item in courses)
            {
                if (item.Name == itemId)
                {
                    return item;
                }
            }

            return null;
        }

        public double GetTotalValue()
        {
            double value = 0;
            foreach (var item in courses)
            {
                value += Utility.GetValueOfCourse(item);
            }
            return value;
        }
    }
}
