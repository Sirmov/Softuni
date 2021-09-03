using System;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArgs = command.Split();
                string operation = commandArgs[0];

                if (operation == "swap")
                {
                    int first = int.Parse(commandArgs[1]);
                    int second = int.Parse(commandArgs[2]);
                    int temp = array[first];
                    array[first] = array[second];
                    array[second] = temp;
                }
                else if (operation == "multiply")
                {
                    int first = int.Parse(commandArgs[1]);
                    int second = int.Parse(commandArgs[2]);
                    array[first] = array[first] * array[second];
                }
                else if (operation == "decrease")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = array[i] - 1;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}
