using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace C_.Net_LINQAssignment
{
    internal class Program
    {
        static int[] partialSums = new int[5];

        static void Process(object obj)
        {
            var data = (Tuple<List<int>, int>)obj;
            var numbers = data.Item1;
            int index = data.Item2;

            int sum = 0;

            Console.WriteLine("Thread " + (index + 1) + " processing:");
            foreach (var n in numbers)
            {
                Console.Write(n + " ");
                sum += n;
            }

            Console.WriteLine("\nThread " + (index + 1) + " Sum: " + sum);
            partialSums[index] = sum;
        }

        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 50).ToList();

            int size = 10;
            Thread[] threads = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                var part = numbers.Skip(i * size).Take(size).ToList();
                threads[i] = new Thread(Process);
                threads[i].Start(Tuple.Create(part, i));
            }

            for (int i = 0; i < 5; i++)
                threads[i].Join();

            int finalSum = partialSums.Sum();
            Console.WriteLine("\nFinal Sum: " + finalSum);
        }
    }
}