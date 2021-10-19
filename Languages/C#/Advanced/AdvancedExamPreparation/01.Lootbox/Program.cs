using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int claimedItems = 0;

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int sum = firstLootBox.Peek() + secondLootBox.Peek();

                if (sum % 2 == 0)
                {
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                    claimedItems += sum;
                }
                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }
            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
