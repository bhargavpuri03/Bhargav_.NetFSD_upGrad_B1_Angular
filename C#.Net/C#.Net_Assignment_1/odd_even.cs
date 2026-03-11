using System;
using System.Collections.Generic;
using System.Text;

namespace C_.Net_Assignment_1
{
    internal class odd_even
    {
        static void Main(String[] args)
        {
            Console.Write("Enter number: ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n % 2 == 0)
                Console.WriteLine("Even");
            else
                Console.WriteLine("Odd");
        }
    }
}
