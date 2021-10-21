using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new Dictionary<string, Ingredient>();
            CurrentAlcoholLevel = 0;
        }

        public Dictionary<string, Ingredient> Ingredients { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel { get; private set; }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.ContainsKey(ingredient.Name) &&
                Ingredients.Count < Capacity &&
                ingredient.Alcohol <= MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient.Name, ingredient);
                CurrentAlcoholLevel += ingredient.Alcohol;
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.ContainsKey(name))
            {
                CurrentAlcoholLevel -= Ingredients[name].Alcohol;
                return Ingredients.Remove(name);
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            if (Ingredients.ContainsKey(name))
            {
                return Ingredients[name];
            }

            return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(i => i.Value.Alcohol).FirstOrDefault().Value;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
