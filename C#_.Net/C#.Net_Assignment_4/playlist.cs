using System;
using System.Collections.Generic;
using System.Linq;

namespace C_.Net_Assignment_4
{
    class Song
    {
        public int Id;
        public string Title;
        public string Artist;
    }

    internal class playlist
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<Song>();

            var a = new Song { Id = 1, Title = "Song1", Artist = "A" };
            var b = new Song { Id = 2, Title = "Song2", Artist = "B" };
            var c = new Song { Id = 3, Title = "Song3", Artist = "C" };

            list.AddFirst(a);
            list.AddLast(b);
            list.AddAfter(list.First, c);

            list.Remove(b);

            foreach (var s in list)
                Console.WriteLine(s.Title);

            var node = list.Last;
            while (node != null)
            {
                Console.WriteLine(node.Value.Title);
                node = node.Previous;
            }

            var f = list.FirstOrDefault(x => x.Title == "Song1");
            if (f != null)
                Console.WriteLine(f.Title);
        }
    }
}