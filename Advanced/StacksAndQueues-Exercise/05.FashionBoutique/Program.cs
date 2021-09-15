using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clothes = new Stack<int>(input);
            int rackCapacity = int.Parse(Console.ReadLine());
            int racks = 1;
            int currCapacity = 0;

            while (clothes.Count > 0)
            {
                if (clothes.Peek() + currCapacity <= rackCapacity)
                {
                    currCapacity += clothes.Pop();
                }
                else
                {
                    racks++;
                    currCapacity = clothes.Pop();
                }
            }

            Console.WriteLine(racks);
        }
    }
}
