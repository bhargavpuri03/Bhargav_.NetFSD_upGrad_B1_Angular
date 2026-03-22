using System;
using System.Collections.Generic;
using System.Linq;

namespace C_.Net_Assignment_4
{
    class Student
    {
        public int Id;
        public string Name;
        public int Marks;
    }

    internal class Student1
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<int, Student>();

            dict[1] = new Student { Id = 1, Name = "A", Marks = 80 };
            dict[2] = new Student { Id = 2, Name = "B", Marks = 60 };
            dict[3] = new Student { Id = 3, Name = "C", Marks = 90 };

            Console.WriteLine(dict[1].Name);

            Console.WriteLine(dict.ContainsKey(2));

            dict[2].Marks = 75;

            dict.Remove(3);

            foreach (var s in dict.Values.Where(x => x.Marks > 75))
                Console.WriteLine(s.Name);
        }
    }
}