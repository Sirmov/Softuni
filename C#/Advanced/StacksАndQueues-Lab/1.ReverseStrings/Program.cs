using System;
using System.Collections.Generic;
using System.Text;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            StringBuilder output = new StringBuilder(stack.Count);

            while (stack.Count > 0)
            {
                output.Append(stack.Pop());
            }

            Console.WriteLine(output);
        }
    }
}
