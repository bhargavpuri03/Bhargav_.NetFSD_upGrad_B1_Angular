using System;
using System.Collections.Generic;
using System.Linq;

namespace C_.Net_LINQAssignment
{
    class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public string Subject;
        public int Marks;
    }

    internal class class7
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student{Id=1, Name="A", Class="10", Subject="Math", Marks=80},
                new Student{Id=2, Name="B", Class="10", Subject="Math", Marks=70},
                new Student{Id=3, Name="C", Class="10", Subject="Science", Marks=90}
            };

            var result = students.GroupBy(s => s.Class)
                .Select(c => new
                {
                    Class = c.Key,
                    Subjects = c.GroupBy(s => s.Subject)
                        .Select(sub => new
                        {
                            Subject = sub.Key,
                            AvgMarks = sub.Average(x => x.Marks)
                        })
                });

            foreach (var r in result)
            {
                Console.WriteLine("Class: " + r.Class);
                foreach (var s in r.Subjects)
                    Console.WriteLine(s.Subject + " " + s.AvgMarks);
            }
        }
    }
}