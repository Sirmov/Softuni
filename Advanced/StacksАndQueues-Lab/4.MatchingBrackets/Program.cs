using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] equation = Console.ReadLine().ToCharArray();
            Stack<int> stack = new Stack<int>();


            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == '(')
                {
                    stack.Push(i);
                }
                else if (equation[i] == ')')
                {
                    int startIndex = stack.Pop();
                    Console.WriteLine(new string(equation).Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
