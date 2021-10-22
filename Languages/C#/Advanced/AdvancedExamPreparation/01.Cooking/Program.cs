using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            Dictionary<int, string> recipes = new Dictionary<int, string>
            {
                { 25, "Bread" },
                { 50, "Cake" },
                { 75, "Pastry" },
                { 100, "Fruit Pie" }
            };

            SortedDictionary<string, int> pastries = new SortedDictionary<string, int>
            {
                { "Bread", 0 },
                { "Cake", 0 },
                { "Pastry", 0 },
                { "Fruit Pie", 0 },
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Peek();
                int ingredient = ingredients.Peek();
                int sum = liquid + ingredient;

                if (recipes.ContainsKey(sum))
                {
                    pastries[recipes[sum]]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }

            if (pastries.Any(p => p.Value == 0))
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var pastry in pastries)
            {
                Console.WriteLine($"{pastry.Key}: {pastry.Value}");
            }
        }
    }
}
