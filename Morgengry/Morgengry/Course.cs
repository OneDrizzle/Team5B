﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Morgengry
{
    public class Course : IValuable
    {
        public static double CourseHourValue
        { get; set; }
        public string Name
        { get; set; }
        public int DurationInMinutes
        { get; set; }

        static Course()
            {
            }
        public Course(string name, int duration)
        {
            Name = name;
            DurationInMinutes = duration;

        }
        public Course(string name)
        : this(name, 0)
        {
            
        }

        
        public override string ToString()
        {
            return $"Name: {Name}, Duration in Minutes: {DurationInMinutes}, Pris pr påbegyndt time: {GetValue()}";
        }

        public double GetValue()
        {
            return Math.Ceiling(((double)DurationInMinutes / 60)) * CourseHourValue;
        }

        public string CreateLineToSave()
        {
            return $"COURSE;{Name};{DurationInMinutes};{CourseHourValue}";
        }
    }
}
