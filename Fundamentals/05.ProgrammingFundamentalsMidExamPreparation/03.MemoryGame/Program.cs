using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string input = Console.ReadLine();
            int moves = 0;

            while (input != "end")
            {
                moves++;
                int index1 = int.Parse(input.Split()[0]);
                int index2 = int.Parse(input.Split()[1]);

                if (index1 == index2 || !AreValid(index1, index2, elements))
                {
                    string element = $"-{moves}a";
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    elements.Insert(elements.Count / 2, element);
                    elements.Insert(elements.Count / 2, element);
                }
                else if (elements[index1] == elements[index2])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {elements[index1]}!");
                    elements.RemoveAt(Math.Max(index1, index2));
                    elements.RemoveAt(Math.Min(index1, index2));
                    if (elements.Count == 0)
                    {
                        Console.WriteLine($"You have won in {moves} turns!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", elements));
        }

        static bool AreValid(int index1, int index2, List<string> elements)
        {
            return index1 >= 0 && index1 < elements.Count && index2 >= 0 && index2 < elements.Count;
        }
    }
}
