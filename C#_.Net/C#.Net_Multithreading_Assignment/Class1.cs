using System;
using System.Threading;

namespace C_.Net_LINQAssignment
{
    class BankAccount
    {
        public int Balance = 1000;
        private object lockObj = new object();

        public void WithdrawWithoutLock(int amount)
        {
            if (Balance >= amount)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " withdrawing " + amount);
                Balance -= amount;
                Console.WriteLine("Remaining Balance: " + Balance);
            }
        }

        public void WithdrawWithLock(int amount)
        {
            lock (lockObj)
            {
                if (Balance >= amount)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " withdrawing " + amount);
                    Balance -= amount;
                    Console.WriteLine("Remaining Balance: " + Balance);
                }
                else
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " insufficient balance");
                }
            }
        }
    }

    internal class Class1
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            Thread t1 = new Thread(() => account.WithdrawWithoutLock(700));
            Thread t2 = new Thread(() => account.WithdrawWithoutLock(500));
            Thread t3 = new Thread(() => account.WithdrawWithoutLock(400));

            t1.Name = "User1";
            t2.Name = "User2";
            t3.Name = "User3";

            Console.WriteLine("Without Lock:");
            t1.Start(); t2.Start(); t3.Start();
            t1.Join(); t2.Join(); t3.Join();

            Console.WriteLine("\nWith Lock:");

            account.Balance = 1000;

            Thread t4 = new Thread(() => account.WithdrawWithLock(700));
            Thread t5 = new Thread(() => account.WithdrawWithLock(500));
            Thread t6 = new Thread(() => account.WithdrawWithLock(400));

            t4.Name = "User1";
            t5.Name = "User2";
            t6.Name = "User3";

            t4.Start(); t5.Start(); t6.Start();
            t4.Join(); t5.Join(); t6.Join();
        }
    }
}