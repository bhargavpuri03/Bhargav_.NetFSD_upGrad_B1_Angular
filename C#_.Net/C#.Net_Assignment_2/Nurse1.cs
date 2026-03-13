using System;

namespace C_.Net_Assignment_2
{
    class Nurse
    {
        public int NurseId { get; set; }
        public string NurseName { get; set; }
        public string Department { get; set; }
    }

    internal class Nurse1
    {
        static void Main(string[] args)
        {
            Nurse n = new Nurse
            {
                NurseId = 1,
                NurseName = "Anita",
                Department = "Emergency"
            };

            Console.WriteLine("Nurse Id: " + n.NurseId);
            Console.WriteLine("Nurse Name: " + n.NurseName);
            Console.WriteLine("Department: " + n.Department);
        }
    }
}