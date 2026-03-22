using System;
using System.Collections.Generic;

namespace C_.Net_Assignment_4
{
    internal class email
    {
        static void Main(string[] args)
        {
            var set = new HashSet<string>()
            {
                "a@gmail.com","b@gmail.com","c@gmail.com","a@gmail.com"
            };

            foreach (var x in set)
                Console.WriteLine(x);

            Console.WriteLine(set.Contains("a@gmail.com"));

            set.Remove("b@gmail.com");

            var set2 = new HashSet<string>() { "a@gmail.com", "x@gmail.com" };

            set2.IntersectWith(set);

            foreach (var x in set2)
                Console.WriteLine(x);
        }
    }
}