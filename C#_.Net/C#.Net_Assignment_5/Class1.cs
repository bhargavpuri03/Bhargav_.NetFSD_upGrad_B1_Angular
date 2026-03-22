using System;
using System.IO;

namespace C_.Net_Assignment_5
{
    internal class class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Create  2.Read");
            int ch = int.Parse(Console.ReadLine());

            if (ch == 1)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Roll: ");
                string roll = Console.ReadLine();

                int m1 = int.Parse(Console.ReadLine());
                int m2 = int.Parse(Console.ReadLine());
                int m3 = int.Parse(Console.ReadLine());

                int total = m1 + m2 + m3;
                double avg = total / 3.0;

                string grade = avg >= 75 ? "A" : avg >= 60 ? "B" : avg >= 40 ? "C" : "Fail";

                string content =
                    "Name:" + name + "\n" +
                    "Roll:" + roll + "\n" +
                    "Marks:" + m1 + "," + m2 + "," + m3 + "\n" +
                    "Total:" + total + "\n" +
                    "Average:" + avg + "\n" +
                    "Grade:" + grade;

                File.WriteAllText(roll + ".txt", content);
            }
            else
            {
                Console.Write("Enter Roll: ");
                string roll = Console.ReadLine();

                if (File.Exists(roll + ".txt"))
                    Console.WriteLine(File.ReadAllText(roll + ".txt"));
                else
                    Console.WriteLine("Not Found");
            }
        }
    }
}