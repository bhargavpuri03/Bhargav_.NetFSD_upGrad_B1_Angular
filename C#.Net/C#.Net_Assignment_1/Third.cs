using System;
using System.Collections.Generic;
using System.Text;

namespace C_.Net_Assignment_1
{
    internal class Third
    {
        static void Main(String[] args)
        {
            int sum = 0;
            int avg = 0;
            for(int i=1;i<=5;i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }
            avg = sum / 5;
            Console.WriteLine("average " + avg);
            Console.WriteLine("sum " + sum);
        }

    }
}
