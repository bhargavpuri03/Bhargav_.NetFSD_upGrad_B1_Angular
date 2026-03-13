using System;

namespace C_.Net_Assignment_2
{
    class Hospital
    {
        public static string HospitalName;
        public static string HospitalAddress;
        public string PatientName;
    }

    internal class Hospital1
    {
        static void Main(string[] args)
        {
            Hospital.HospitalName = "City Hospital";
            Hospital.HospitalAddress = "Hyderabad";

            Hospital p1 = new Hospital();
            Hospital p2 = new Hospital();
            Hospital p3 = new Hospital();

            p1.PatientName = "Ravi";
            p2.PatientName = "Sita";
            p3.PatientName = "Ramesh";

            Console.WriteLine("Hospital: " + Hospital.HospitalName);
            Console.WriteLine("Address: " + Hospital.HospitalAddress);

            Console.WriteLine("Patient: " + p1.PatientName);
            Console.WriteLine("Patient: " + p2.PatientName);
            Console.WriteLine("Patient: " + p3.PatientName);
        }
    }
}