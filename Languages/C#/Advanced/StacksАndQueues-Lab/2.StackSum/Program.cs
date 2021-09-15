using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            string command = Console.ReadLine();

            while (command.ToUpper() != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = tokens[0].ToUpper();

                if (operation == "ADD")
                {
                    int first = int.Parse(tokens[1]);
                    int second = int.Parse(tokens[2]);
                    stack.Push(first);
                    stack.Push(second);
                }
                else if (operation == "REMOVE")
                {
                    int count = int.Parse(tokens[1]);

                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
