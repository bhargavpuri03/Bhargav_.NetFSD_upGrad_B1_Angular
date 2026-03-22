using System;
using System.Collections.Generic;

namespace C_.Net_Assignment_4
{
    internal class stack
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();

            stack.Push("A");
            stack.Push("B");
            stack.Push("C");

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            if (stack.Count > 0)
                Console.WriteLine(stack.Peek());

            var redo = new Stack<string>();
            redo.Push("Redo");
        }
    }
}