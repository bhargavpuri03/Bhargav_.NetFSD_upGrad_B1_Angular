using System;
using System.Collections.Generic;
using System.Text;

namespace C_.Net_Assignment_1
{
    internal class journey_time
    {
        static void Main(String[] args)
        {
            Console.Write("Enter distance: ");
            double distance = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter speed: ");
            double speed = Convert.ToDouble(Console.ReadLine());

            double time = distance / speed;

            Console.WriteLine("Time = " + time);
        }
    }
}