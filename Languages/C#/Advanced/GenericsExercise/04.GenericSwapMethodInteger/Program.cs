using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int itemsCount = int.Parse(Console.ReadLine());
            List<int> items = new List<int>();

            for (int i = 0; i < itemsCount; i++)
            {
                items.Add(int.Parse(Console.ReadLine()));
            }

            int[] swapIndexes = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            SwapElements(items, swapIndexes[0], swapIndexes[1]);

            foreach (var item in items)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        static void SwapElements<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
