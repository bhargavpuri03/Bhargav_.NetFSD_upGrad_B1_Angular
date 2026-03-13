using System;

namespace C_.Net_Assignment_2
{
    class Appointment
    {
        public int AppointmentId;
        public string PatientName;
        public string DoctorName;
        public DateTime AppointmentDate;

        public Appointment()
        {
            DoctorName = "General Physician";
            AppointmentDate = DateTime.Today;
        }
    }

    internal class Appointment1
    {
        static void Main(string[] args)
        {
            Appointment a = new Appointment();

            a.AppointmentId = 1;
            a.PatientName = "Rahul";

            Console.WriteLine("Appointment Id: " + a.AppointmentId);
            Console.WriteLine("Patient Name: " + a.PatientName);
            Console.WriteLine("Doctor Name: " + a.DoctorName);
            Console.WriteLine("Date: " + a.AppointmentDate);
        }
    }
}