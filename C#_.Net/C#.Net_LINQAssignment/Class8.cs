using System;
using System.Collections.Generic;
using System.Linq;

namespace C_.Net_LINQAssignment
{
    class Orders
    {
        public int Id;
        public string CustomerName;
        public DateTime OrderDate;
        public double TotalAmount;
    }

    internal class class8
    {
        static void Main(string[] args)
        {
            var orders = new List<Orders>
            {
                new Orders{Id=1, CustomerName="Ravi", TotalAmount=3000, OrderDate=DateTime.Now.AddDays(-10)},
                new Orders{Id=2, CustomerName="Kiran", TotalAmount=5000, OrderDate=DateTime.Now.AddDays(-40)},
                new Orders{Id=3, CustomerName="Ravi", TotalAmount=2000, OrderDate=DateTime.Now.AddDays(-5)}
            };

            var recent = orders.Where(o => o.OrderDate >= DateTime.Now.AddDays(-30));

            var monthly = orders.GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new { g.Key.Year, g.Key.Month, Total = g.Sum(x => x.TotalAmount) });

            var topCustomers = orders.GroupBy(o => o.CustomerName)
                .Select(g => new { Name = g.Key, Total = g.Sum(x => x.TotalAmount) })
                .OrderByDescending(x => x.Total)
                .Take(5);

            var highest = orders.GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => g.OrderByDescending(x => x.TotalAmount).First());

            Console.WriteLine("Recent Orders:");
            foreach (var o in recent) Console.WriteLine(o.CustomerName);

            Console.WriteLine("\nMonthly:");
            foreach (var m in monthly) Console.WriteLine(m.Month + " " + m.Total);

            Console.WriteLine("\nTop Customers:");
            foreach (var t in topCustomers) Console.WriteLine(t.Name + " " + t.Total);

            Console.WriteLine("\nHighest Order per Month:");
            foreach (var h in highest) Console.WriteLine(h.CustomerName + " " + h.TotalAmount);
        }
    }
}