using System;
using System.Collections.Generic;
using System.Linq;

namespace C_.Net_LINQAssignment
{
    internal class class1
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 5, 10, 15, 20, 25, 30 };

            var even = numbers.Where(n => n % 2 == 0);
            var greater = numbers.Where(n => n > 15);
            var squares = numbers.Select(n => n * n);
            var count = numbers.Count(n => n % 5 == 0);

            Console.WriteLine("Even Numbers:");
            foreach (var n in even) Console.WriteLine(n);

            Console.WriteLine("\nGreater than 15:");
            foreach (var n in greater) Console.WriteLine(n);

            Console.WriteLine("\nSquares:");
            foreach (var n in squares) Console.WriteLine(n);

            Console.WriteLine("\nCount divisible by 5:");
            Console.WriteLine(count);
        }
    }
}