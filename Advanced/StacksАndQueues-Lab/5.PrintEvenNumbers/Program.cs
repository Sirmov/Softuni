using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                queue.Enqueue(input[i]);
            }

            List<int> evenNumbers = new List<int>();

            while (queue.Count > 0)
            {
                if (queue.Peek() % 2 == 0)
                {
                    evenNumbers.Add(queue.Dequeue());
                }
                else
                {
                    queue.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
