using System;
using System.Collections.Generic;
using System.Linq;

namespace C_.Net_LINQAssignment
{
    class Product
    {
        public int Id;
        public string Name;
        public string Category;
        public double Price;
        public int Stock;
    }

    internal class class6
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product{Id=1, Name="P1", Category="Electronics", Price=10000, Stock=5},
                new Product{Id=2, Name="P2", Category="Electronics", Price=20000, Stock=0},
                new Product{Id=3, Name="P3", Category="Clothing", Price=1500, Stock=20}
            };

            var lowStock = products.Where(p => p.Stock < 10);
            var top3 = products.OrderByDescending(p => p.Price).Take(3);
            var totalStock = products.GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Stock = g.Sum(x => x.Stock) });
            var outOfStock = products.Any(p => p.Stock == 0);

            Console.WriteLine("Low Stock:");
            foreach (var p in lowStock) Console.WriteLine(p.Name);

            Console.WriteLine("\nTop 3 Expensive:");
            foreach (var p in top3) Console.WriteLine(p.Name + " " + p.Price);

            Console.WriteLine("\nStock per Category:");
            foreach (var t in totalStock) Console.WriteLine(t.Category + " " + t.Stock);

            Console.WriteLine("\nAny Out of Stock:");
            Console.WriteLine(outOfStock);
        }
    }
}