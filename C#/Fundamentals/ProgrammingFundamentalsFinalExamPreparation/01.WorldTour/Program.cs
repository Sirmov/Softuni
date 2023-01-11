using System;
using System.Text;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] commandArgs = command.Split(":");
                string operation = commandArgs[0];

                if (operation == "Add Stop")
                {
                    int index = int.Parse(commandArgs[1]);

                    if (index >= 0 && index <= input.Length)
                    {
                        input.Insert(index, commandArgs[2]);
                    }

                    Console.WriteLine(input);
                }
                else if (operation == "Remove Stop")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);

                    if (startIndex >= 0 && startIndex < input.Length &&
                        endIndex >= 0 && endIndex < input.Length)
                    {
                        input.Remove(startIndex, (endIndex - startIndex) + 1);
                    }

                    Console.WriteLine(input);
                }
                else if (operation == "Switch")
                {
                    string oldString = commandArgs[1];
                    string newString = commandArgs[2];

                    input = input.Replace(oldString, newString);

                    Console.WriteLine(input);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}
