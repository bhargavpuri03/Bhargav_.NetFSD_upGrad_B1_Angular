using System;
using System.IO;
using System.Collections.Generic;

namespace C_.Net_Assignment_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "employee_log.txt";

            try
            {
                if (!File.Exists(path))
                    File.Create(path).Close();

                Console.WriteLine("1.Add Login  2.Update Logout");
                int ch = int.Parse(Console.ReadLine());

                if (ch == 1)
                {
                    Console.Write("Id: ");
                    string id = Console.ReadLine();
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    string line = id + "|" + name + "|" + DateTime.Now + "|";

                    using (StreamWriter sw = new StreamWriter(path, true))
                        sw.WriteLine(line);
                }
                else if (ch == 2)
                {
                    Console.Write("Enter Id: ");
                    string id = Console.ReadLine();

                    var lines = new List<string>(File.ReadAllLines(path));

                    for (int i = 0; i < lines.Count; i++)
                    {
                        var parts = lines[i].Split('|');
                        if (parts[0] == id && parts[3] == "")
                        {
                            lines[i] = parts[0] + "|" + parts[1] + "|" + parts[2] + "|" + DateTime.Now;
                        }
                    }

                    File.WriteAllLines(path, lines);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Done");
            }
        }
    }
}