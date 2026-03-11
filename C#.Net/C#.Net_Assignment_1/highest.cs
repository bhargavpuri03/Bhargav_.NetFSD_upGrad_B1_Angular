using System;
using System.Collections.Generic;
using System.Text;

namespace C_.Net_Assignment_1
{
    internal class highest
    {
        static void Main(String[] args)
        {
            Console.Write("Enter first number: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = Convert.ToInt32(Console.ReadLine());

            if (a > b)
                Console.WriteLine("Highest = " + a);
            else
                Console.WriteLine("Highest = " + b);
        }
    }
}