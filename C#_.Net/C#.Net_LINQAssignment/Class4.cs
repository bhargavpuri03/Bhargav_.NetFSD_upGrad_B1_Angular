using System;
using System.Collections.Generic;
using System.Linq;

namespace C_.Net_LINQAssignment
{
    class Customer { 
        public int Id; 
        public string Name;
    }
    class Order { public int Id; public int CustomerId; public double Amount; }

    internal class class4
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer{Id=1, Name="Ravi"},
                new Customer{Id=2, Name="Kiran"}
            };

            var orders = new List<Order>
            {
                new Order{Id=1, CustomerId=1, Amount=3000},
                new Order{Id=2, CustomerId=1, Amount=4000}
            };

            var join = customers.Join(orders, c => c.Id, o => o.CustomerId,
                (c, o) => new { c.Name, o.Amount });

            var total = orders.GroupBy(o => o.CustomerId)
                .Select(g => new { CustomerId = g.Key, Total = g.Sum(x => x.Amount) });

            var rich = total.Where(x => x.Total > 5000);
            var noOrders = customers.Where(c => !orders.Any(o => o.CustomerId == c.Id));

            Console.WriteLine("Join:");
            foreach (var j in join) Console.WriteLine(j.Name + " " + j.Amount);

            Console.WriteLine("\nTotal per Customer:");
            foreach (var t in total) Console.WriteLine(t.CustomerId + " " + t.Total);

            Console.WriteLine("\nTotal > 5000:");
            foreach (var r in rich) Console.WriteLine(r.CustomerId);

            Console.WriteLine("\nCustomers with no orders:");
            foreach (var c in noOrders) Console.WriteLine(c.Name);
        }
    }
}