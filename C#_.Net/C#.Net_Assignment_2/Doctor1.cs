using System;

namespace C_.Net_Assignment_2
{
    class Doctor
    {
        public int DoctorId;
        public string DoctorName;
        public string Specialization;
        public int ConsultationFee;
    }

    internal class Doctor1
    {
        static void Main(string[] args)
        {
            Doctor d1 = new Doctor();
            Doctor d2 = new Doctor();

            d1.DoctorId = 1;
            d1.DoctorName = "Dr. Rao";
            d1.Specialization = "Cardiology";
            d1.ConsultationFee = 500;

            d2.DoctorId = 2;
            d2.DoctorName = "Dr. Sharma";
            d2.Specialization = "Dermatology";
            d2.ConsultationFee = 400;

            Console.WriteLine(d1.DoctorName + " - " + d1.Specialization);
            Console.WriteLine(d2.DoctorName + " - " + d2.Specialization);
        }
    }
}