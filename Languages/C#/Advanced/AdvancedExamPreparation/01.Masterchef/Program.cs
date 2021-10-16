using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredientsValue =
                new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> ingredientsFreshness =
                new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            SortedDictionary<string, int> dishes = new SortedDictionary<string, int>
            {
                { "Dipping sauce", 0 },
                { "Green salad", 0 },
                { "Chocolate cake", 0 },
                { "Lobster", 0 }
            };

            while (ingredientsValue.Count > 0 && ingredientsFreshness.Count > 0)
            {
                if (ingredientsValue.Peek() == 0)
                {
                    ingredientsValue.Dequeue();
                    continue;
                }

                int freshnessLevel = ingredientsValue.Peek() * ingredientsFreshness.Peek();

                switch (freshnessLevel)
                {
                    case 400:
                        dishes["Lobster"]++;
                        Cook(ingredientsValue, ingredientsFreshness);
                        break;
                    case 300:
                        dishes["Chocolate cake"]++;
                        Cook(ingredientsValue, ingredientsFreshness);
                        break;
                    case 250:
                        dishes["Green salad"]++;
                        Cook(ingredientsValue, ingredientsFreshness);
                        break;
                    case 150:
                        dishes["Dipping sauce"]++;
                        Cook(ingredientsValue, ingredientsFreshness);
                        break;
                    default:
                        ingredientsFreshness.Pop();
                        ingredientsValue.Enqueue(ingredientsValue.Dequeue() + 5);
                        break;
                }
            }

            if (!dishes.Any(d => d.Value == 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredientsValue.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredientsValue.Sum()}");
            }

            foreach (var dish in dishes)
            {
                if (dish.Value > 0)
                {
                    Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                }
            }
        }

        private static void Cook(Queue<int> ingredientsValue, Stack<int> ingredientsFreshness)
        {
            ingredientsValue.Dequeue();
            ingredientsFreshness.Pop();
        }
    }
}
