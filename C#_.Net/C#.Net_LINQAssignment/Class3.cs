using System;
using System.Collections.Generic;
using System.Linq;

namespace C_.Net_LINQAssignment
{
    class Employee1
    {
        public int Id;
        public string Name;
        public string Department;
        public double Salary;
    }

    internal class class3
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee1>
            {
                new Employee1{Id=1, Name="A", Department="IT", Salary=50000},
                new Employee1{Id=2, Name="B", Department="HR", Salary=40000},
                new Employee1{Id=3, Name="C", Department="IT", Salary=70000}
            };

            var itEmp = employees.Where(e => e.Department == "IT");
            var highest = employees.OrderByDescending(e => e.Salary).FirstOrDefault();
            var avg = employees.Average(e => e.Salary);
            var countDept = employees.GroupBy(e => e.Department)
                                     .Select(g => new { Dept = g.Key, Count = g.Count() });

            Console.WriteLine("IT Employees:");
            foreach (var e in itEmp) Console.WriteLine(e.Name);

            Console.WriteLine("\nHighest Salary:");
            Console.WriteLine(highest.Name + " " + highest.Salary);

            Console.WriteLine("\nAverage Salary:");
            Console.WriteLine(avg);

            Console.WriteLine("\nCount per Department:");
            foreach (var d in countDept)
                Console.WriteLine(d.Dept + " " + d.Count);
        }
    }
}