using System;
using System.Collections.Generic;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] equation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>(equation.Length);

            for (int i = equation.Length - 1; i >= 0; i--)
            {
                stack.Push(equation[i]);
            }

            while (stack.Count > 1)
            {
                int firstOperand = int.Parse(stack.Pop());
                char operation = char.Parse(stack.Pop());
                int secondOperand = int.Parse(stack.Pop());

                if (operation == '+')
                {
                    int sum = firstOperand + secondOperand;
                    stack.Push(sum.ToString());
                }
                else
                {
                    int sum = firstOperand - secondOperand;
                    stack.Push(sum.ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
