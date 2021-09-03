using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> secondHand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (firstHand.Count != 0 && secondHand.Count != 0)
            {
                int firstCard = firstHand[0];
                int secondCard = secondHand[0];

                if (firstCard > secondCard)
                {
                    firstHand.Add(firstCard);
                    firstHand.Remove(firstCard);
                    firstHand.Add(secondCard);
                    secondHand.Remove(secondCard);
                }
                else if (secondCard > firstCard)
                {
                    secondHand.Add(secondCard);
                    secondHand.Remove(secondCard);
                    secondHand.Add(firstCard);
                    firstHand.Remove(firstCard);
                }
                else
                {
                    firstHand.Remove(firstCard);
                    secondHand.Remove(secondCard);
                }
            }

            if (firstHand.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstHand.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondHand.Sum()}");
            }
        }
    }
}
