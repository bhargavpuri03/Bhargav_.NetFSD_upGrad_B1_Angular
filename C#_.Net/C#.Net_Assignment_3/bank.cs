using System;
using System.Collections.Generic;
using System.Text;

namespace C_.Net_Assignment_3
{
    using System;

    class Account
    {
        public int AccountNumber;
        public double Balance;

        public void CalculateInterest()
        {
            Console.WriteLine("Base account interest calculation");
        }
    }

    class SavingsAccount : Account
    {
        public new void CalculateInterest()
        {
            Console.WriteLine("Savings account interest");
        }
    }

    class CurrentAccount : Account
    {
        public new void CalculateInterest()
        {
            Console.WriteLine("Current account interest");
        }
    }

    class bank
    {
        static void Main()
        {
            Account acc = new SavingsAccount();
            acc.CalculateInterest(); // Base method runs
        }
    }
}
