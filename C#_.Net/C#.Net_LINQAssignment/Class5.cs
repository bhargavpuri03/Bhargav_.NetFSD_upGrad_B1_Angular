using System;
using System.Collections.Generic;
using System.Linq;

namespace C_.Net_LINQAssignment
{
    internal class class5
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 2, 4, 5, 3, 6 };

            var distinct = numbers.Distinct();
            var duplicates = numbers.GroupBy(n => n).Where(g => g.Count() > 1).Select(g => g.Key);
            var count = numbers.GroupBy(n => n).Select(g => new { Number = g.Key, Count = g.Count() });

            Console.WriteLine("Distinct:");
            foreach (var n in distinct) Console.WriteLine(n);

            Console.WriteLine("\nDuplicates:");
            foreach (var n in duplicates) Console.WriteLine(n);

            Console.WriteLine("\nCount:");
            foreach (var c in count) Console.WriteLine(c.Number + " " + c.Count);
        }
    }
}