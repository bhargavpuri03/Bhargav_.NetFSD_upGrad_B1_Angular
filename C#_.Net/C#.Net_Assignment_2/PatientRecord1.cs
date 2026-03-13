using System;

namespace C_.Net_Assignment_2
{
    class PatientRecord
    {
        public static string HospitalName;

        public int PatientId;
        public string PatientName;
        public int Age;
        public string Disease;

        public PatientRecord(int id, string name, int age, string disease)
        {
            PatientId = id;
            PatientName = name;
            Age = age;
            Disease = disease;
        }

        public void DisplayPatientRecord()
        {
            Console.WriteLine("Hospital: " + HospitalName);
            Console.WriteLine("Patient Id: " + PatientId);
            Console.WriteLine("Name: " + PatientName);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Disease: " + Disease);
            Console.WriteLine();
        }
    }

    internal class PatientRecord1
    {
        static void Main(string[] args)
        {
            PatientRecord.HospitalName = "Apollo Hospital";

            PatientRecord p1 = new PatientRecord(101, "Ravi", 40, "Fever");
            PatientRecord p2 = new PatientRecord(102, "Sita", 35, "Cold");
            PatientRecord p3 = new PatientRecord(103, "Ramesh", 50, "Diabetes");

            p1.DisplayPatientRecord();
            p2.DisplayPatientRecord();
            p3.DisplayPatientRecord();
        }
    }
}