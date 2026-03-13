using System;

namespace C_.Net_Assignment_2
{
    class MedicalTest
    {
        public int TestId;
        public string TestName;
        public int TestCost;

        public MedicalTest(int id, string name, int cost)
        {
            TestId = id;
            TestName = name;
            TestCost = cost;
        }
    }

    internal class MedicalTest1
    {
        static void Main(string[] args)
        {
            MedicalTest t1 = new MedicalTest(1, "Blood Test", 300);
            MedicalTest t2 = new MedicalTest(2, "X-Ray", 800);

            Console.WriteLine(t1.TestName + " Cost: " + t1.TestCost);
            Console.WriteLine(t2.TestName + " Cost: " + t2.TestCost);
        }
    }
}