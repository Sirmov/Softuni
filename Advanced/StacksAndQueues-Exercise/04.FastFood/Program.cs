using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(input);

            int max = int.MinValue;
            Queue<int> temp = new Queue<int>(orders);
            while (temp.Count > 0)
            {
                if (temp.Peek() > max)
                {
                    max = temp.Peek();
                }

                temp.Dequeue();
            }
            Console.WriteLine(max);

            while (orders.Count > 0 && food > 0)
            {
                if (food >= orders.Peek())
                {
                    food -= orders.Peek();
                    orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
