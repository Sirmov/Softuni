using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"([#\|])(?<name>[A-Za-z\s]+)\1(?<date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<cal>[0-9]{1,5})\1");
            List<Food> foods = new List<Food>();
            string input = Console.ReadLine();

            foreach (Match match in regex.Matches(input))
            {
                string name = match.Groups["name"].Value;
                string date = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["cal"].Value);
                foods.Add(new Food(name, date, calories));
            }

            int totalCalories = 0;

            foreach (var item in foods)
            {
                totalCalories += item.Calories;
            }

            Console.WriteLine($"You have food to last you for: {Math.Floor(totalCalories / 2000.0)} days!");
            foreach (var item in foods)
            {
                Console.WriteLine($"Item: {item.Name}, Best before: {item.ExpirationDate}, Nutrition: {item.Calories}");
            }
        }
    }

    class Food
    {
        public string Name { get; set; }
        public string ExpirationDate { get; set; }
        public int Calories { get; set; }

        public Food(string name, string exparationDate, int calories)
        {
            Name = name;
            ExpirationDate = exparationDate;
            Calories = calories;
        }
    }
}
