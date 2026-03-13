using System;

namespace C_.Net_Assignment_2
{
    class Billing
    {
        public string PatientName;
        public int ConsultationFee;
        public int TestCharges;

        public void CalculateTotalBill()
        {
            int total = ConsultationFee + TestCharges;
            Console.WriteLine("Patient Name: " + PatientName);
            Console.WriteLine("Total Bill: " + total);
        }
    }

    internal class Billing1
    {
        static void Main(string[] args)
        {
            Billing b = new Billing();

            b.PatientName = "Ramesh";
            b.ConsultationFee = 500;
            b.TestCharges = 1000;

            b.CalculateTotalBill();
        }
    }
}