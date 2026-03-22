using System;
using System.IO;

namespace C_.Net_Assignment_5
{
    internal class class2
    {
        static void Main(string[] args)
        {
            Console.Write("File name: ");
            string path = Console.ReadLine() + ".txt";

            Console.WriteLine("1.Create 2.Write 3.Read 4.Append 5.Delete");
            int ch = int.Parse(Console.ReadLine());

            try
            {
                if (ch == 1)
                {
                    File.Create(path).Close();
                }
                else if (ch == 2)
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        string line;
                        do
                        {
                            line = Console.ReadLine();
                            if (line != "end")
                                sw.WriteLine(line);
                        } while (line != "end");
                    }
                }
                else if (ch == 3)
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        Console.WriteLine(sr.ReadToEnd());
                    }
                }
                else if (ch == 4)
                {
                    using (FileStream fs = new FileStream(path, FileMode.Append))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(Console.ReadLine());
                    }
                }
                else if (ch == 5)
                {
                    if (File.Exists(path))
                        File.Delete(path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}