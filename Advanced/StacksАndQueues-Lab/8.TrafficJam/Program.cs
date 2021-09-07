using System;
using System.Collections.Generic;

namespace _8.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            Queue<string> trafic = new Queue<string>();
            string input = Console.ReadLine();
            int totalPassed = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < capacity; i++)
                    {
                        if (trafic.Count == 0)
                        {
                            break;
                        }

                        Console.WriteLine($"{trafic.Dequeue()} passed!");
                        totalPassed++;
                    }
                }
                else
                {
                    trafic.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{totalPassed} cars passed the crossroads.");
        }
    }
}
