using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string[] commandArgs = command.Split(' ', 2);
            string[] elements = commandArgs[1].Split(", ").ToArray();
            var stack = new Stack<string>(elements);

            command = Console.ReadLine();
            while (command != "END")
            {
                commandArgs = command.Split(' ', 2);
                string operation = commandArgs[0];

                if (operation == "Push")
                {
                    elements = commandArgs[1].Split(", ").ToArray();
                    stack.Push(elements);
                }
                else if (operation == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
