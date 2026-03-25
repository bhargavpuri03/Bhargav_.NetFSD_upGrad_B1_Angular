using System;
using System.Collections.Generic;
using System.Linq;

namespace C_.Net_LINQAssignment
{
    class Employee
    {
        public int Id;
        public string Name;
        public string Department;
        public double Salary;
        public DateTime JoiningDate;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee{Id=1, Name="A", Department="IT", Salary=50000, JoiningDate=DateTime.Now.AddMonths(-2)},
                new Employee{Id=2, Name="B", Department="HR", Salary=40000, JoiningDate=DateTime.Now.AddMonths(-8)},
                new Employee{Id=3, Name="C", Department="IT", Salary=70000, JoiningDate=DateTime.Now.AddMonths(-1)}
            };

            var total = employees.Count();

            var avgDept = employees.GroupBy(e => e.Department)
                .Select(g => new { Dept = g.Key, AvgSalary = g.Average(x => x.Salary) });

            var recent = employees.Where(e => e.JoiningDate >= DateTime.Now.AddMonths(-6));

            var highestDept = employees.GroupBy(e => e.Department)
                .Select(g => g.OrderByDescending(x => x.Salary).First());

            var stats = new
            {
                Min = employees.Min(e => e.Salary),
                Max = employees.Max(e => e.Salary),
                Avg = employees.Average(e => e.Salary)
            };

            Console.WriteLine("Total Employees: " + total);

            Console.WriteLine("\nAvg Salary by Dept:");
            foreach (var a in avgDept) Console.WriteLine(a.Dept + " " + a.AvgSalary);

            Console.WriteLine("\nRecent Employees:");
            foreach (var r in recent) Console.WriteLine(r.Name);

            Console.WriteLine("\nHighest per Dept:");
            foreach (var h in highestDept) Console.WriteLine(h.Department + " " + h.Name);

            Console.WriteLine("\nSalary Stats:");
            Console.WriteLine(stats.Min + " " + stats.Max + " " + stats.Avg);
        }
    }
}