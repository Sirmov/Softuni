using System;
using System.Collections.Generic;

namespace _7.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] players = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>();
            int n = int.Parse(Console.ReadLine());
            int count = 1;

            for (int i = 0; i < players.Length; i++)
            {
                queue.Enqueue(players[i]);
            }

            while (queue.Count > 1)
            {
                if (count == n)
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                    count = 1;
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                    count++;
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
