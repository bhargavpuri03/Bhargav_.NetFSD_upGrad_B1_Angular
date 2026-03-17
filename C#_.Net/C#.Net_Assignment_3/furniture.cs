using System;
using System.Collections.Generic;
using System.Text;

namespace C_.Net_Assignment_3
{
    using System;

    class Furniture
    {
        public int OrderId;
        public string OrderDate;
        public string FurnitureType;
        public int Qty;
        public double TotalAmt;
        public string PaymentMode;

        public virtual void GetData()
        {
            Console.Write("OrderId: ");
            OrderId = int.Parse(Console.ReadLine());

            Console.Write("OrderDate: ");
            OrderDate = Console.ReadLine();

            Console.Write("Qty: ");
            Qty = int.Parse(Console.ReadLine());

            Console.Write("Payment Mode: ");
            PaymentMode = Console.ReadLine();
        }

        public virtual void ShowData()
        {
            Console.WriteLine(OrderId + " " + OrderDate + " " + Qty + " " + PaymentMode);
        }
    }

    class Chair : Furniture
    {
        public string ChairType;
        public string Purpose;
        public string MaterialType;
        public double Rate;

        public override void GetData()
        {
            base.GetData();
            Console.Write("Chair Type: ");
            ChairType = Console.ReadLine();

            Console.Write("Purpose: ");
            Purpose = Console.ReadLine();

            Console.Write("Material Type: ");
            MaterialType = Console.ReadLine();

            Console.Write("Rate: ");
            Rate = double.Parse(Console.ReadLine());
        }

        public override void ShowData()
        {
            base.ShowData();
            Console.WriteLine(ChairType + " " + Purpose + " " + MaterialType + " " + Rate);
        }
    }

    class Cot : Furniture
    {
        public string CotType;
        public string Capacity;
        public double Rate;

        public override void GetData()
        {
            base.GetData();
            Console.Write("Cot Type: ");
            CotType = Console.ReadLine();

            Console.Write("Capacity: ");
            Capacity = Console.ReadLine();

            Console.Write("Rate: ");
            Rate = double.Parse(Console.ReadLine());
        }

        public override void ShowData()
        {
            base.ShowData();
            Console.WriteLine(CotType + " " + Capacity + " " + Rate);
        }
    }

    class furniture
    {
        static void Main()
        {
            Chair c = new Chair();
            c.GetData();
            c.ShowData();

            Cot cot = new Cot();
            cot.GetData();
            cot.ShowData();
        }
    }
}
