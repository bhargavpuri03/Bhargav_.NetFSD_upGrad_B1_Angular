using System;
using System.Collections.Generic;

namespace C_.Net_Assignment_4
{
    class Patient
    {
        public int Id;
        public string Name;
        public string Disease;
    }

    internal class patient1
    {
        static void Main(string[] args)
        {
            var q = new Queue<Patient>();

            q.Enqueue(new Patient { Id = 1, Name = "A", Disease = "Fever" });
            q.Enqueue(new Patient { Id = 2, Name = "B", Disease = "Cold" });
            q.Enqueue(new Patient { Id = 3, Name = "C", Disease = "Cough" });

            q.Dequeue();
            q.Dequeue();

            Console.WriteLine(q.Peek().Name);

            foreach (var p in q)
                Console.WriteLine(p.Name);
        }
    }
}