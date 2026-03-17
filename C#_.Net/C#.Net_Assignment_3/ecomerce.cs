using System;
using System.Collections.Generic;
using System.Text;

namespace C_.Net_Assignment_3
{
    using System;
    using System.Collections.Generic;

    class Order
    {
        public int OrderId;
        public double OrderAmount;

        public virtual double CalculateShippingCost()
        {
            return 50;
        }
    }

    class StandardOrder : Order
    {
        public override double CalculateShippingCost()
        {
            return 50;
        }
    }

    class ExpressOrder : Order
    {
        public override double CalculateShippingCost()
        {
            return 100;
        }
    }

    class InternationalOrder : Order
    {
        public override double CalculateShippingCost()
        {
            return 500;
        }
    }

    class ecomerce
    {
        static void Main()
        {
            List<Order> orders = new List<Order>()
        {
            new StandardOrder(),
            new ExpressOrder(),
            new InternationalOrder()
        };

            foreach (var order in orders)
            {
                Console.WriteLine(order.CalculateShippingCost());
            }
        }
    }
}
