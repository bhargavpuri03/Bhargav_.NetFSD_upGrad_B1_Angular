using System;
using System.Collections.Generic;
using System.Text;

namespace C_.Net_Assignment_1
{
	internal class area
	{
		static void Main(String[] args)
		{
			Console.Write("Enter length: ");
			int l = Convert.ToInt32(Console.ReadLine());

			Console.Write("Enter breadth: ");
			int b = Convert.ToInt32(Console.ReadLine());

			int rectArea = l * b;

			Console.WriteLine("Rectangle Area = " + rectArea);

			Console.Write("Enter side of square: ");
			int s = Convert.ToInt32(Console.ReadLine());

			int squareArea = s * s;

			Console.WriteLine("Square Area = " + squareArea);
		}
	}
}