using System;
using System.Collections.Generic;
using System.Linq;

namespace C_.Net_LINQAssignment
{
    internal class class2
    {
        static void Main(string[] args)
        {
            var names = new List<string> { "Ravi", "Kiran", "Amit", "Raj", "Anil" };

            var startsA = names.Where(n => n.StartsWith("A"));
            var sorted = names.OrderBy(n => n);
            var upper = names.Select(n => n.ToUpper());
            var longNames = names.Where(n => n.Length > 4);

            Console.WriteLine("Starts with A:");
            foreach (var n in startsA) Console.WriteLine(n);

            Console.WriteLine("\nSorted:");
            foreach (var n in sorted) Console.WriteLine(n);

            Console.WriteLine("\nUppercase:");
            foreach (var n in upper) Console.WriteLine(n);

            Console.WriteLine("\nLength > 4:");
            foreach (var n in longNames) Console.WriteLine(n);
        }
    }
}