using System;
using System.Collections.Generic;
using System.Text;

namespace C_.Net_Assignment_3
{
    using System;

    class Student
    {
        public int StudentId;
        public string Name;
        public int Marks;

        public virtual string CalculateGrade()
        {
            return Marks > 50 ? "Pass" : "Fail";
        }
    }

    class SchoolStudent : Student
    {
        public override string CalculateGrade()
        {
            return Marks > 40 ? "Pass" : "Fail";
        }
    }

    class CollegeStudent : Student
    {
        public override string CalculateGrade()
        {
            return Marks > 50 ? "Pass" : "Fail";
        }
    }

    class OnlineStudent : Student
    {
        public override string CalculateGrade()
        {
            return Marks > 60 ? "Pass" : "Fail";
        }
    }

    class education
    {
        static void Main()
        {
            Student[] students =
            {
            new SchoolStudent(){Marks=45},
            new CollegeStudent(){Marks=55},
            new OnlineStudent(){Marks=58}
        };

            foreach (var s in students)
            {
                Console.WriteLine(s.CalculateGrade());
            }
        }
    }
}
