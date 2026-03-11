using System;
using System.Collections.Generic;
using System.Text;

namespace C_.Net_Assignment_1
{
    internal class vowel_check
    {
        static void Main(String[] args)
        {
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();

            char ch = str[2];

            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u' ||
                ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U')
                Console.WriteLine("Vowel");
            else
                Console.WriteLine("Consonant");
        }
    }
}