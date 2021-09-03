using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int sum = 0;
            while (pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                sum += CapturePokemon(pokemons, index);
            }

            Console.WriteLine(sum);
        }
        private static int CapturePokemon(List<int> pokemons, int index)
        {
            if (index < 0 || index >= pokemons.Count)
            {
                return SpecialCase(pokemons, index);
            }

            int distance = pokemons[index];
            pokemons.RemoveAt(index);
            for (int i = 0; i < pokemons.Count; i++)
            {
                if (pokemons[i] <= distance)
                {
                    pokemons[i] += distance;
                }
                else if (pokemons[i] > distance)
                {
                    pokemons[i] -= distance;
                }
            }

            return distance;
        }

        static int SpecialCase(List<int> pokemons, int index)
        {
            int distance = 0;
            int firstPokemon = pokemons[0];
            int lastPokemon = pokemons[pokemons.Count - 1];

            if (index < 0)
            {
                distance = firstPokemon;
                pokemons.RemoveAt(0);
                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= distance)
                    {
                        pokemons[i] += distance;
                    }
                    else if (pokemons[i] > distance)
                    {
                        pokemons[i] -= distance;
                    }
                }
                pokemons.Insert(0, pokemons[pokemons.Count - 1]);
            }
            else if (index >= pokemons.Count)
            {
                distance = lastPokemon;
                pokemons.RemoveAt(pokemons.Count - 1);
                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= distance)
                    {
                        pokemons[i] += distance;
                    }
                    else if (pokemons[i] > distance)
                    {
                        pokemons[i] -= distance;
                    }
                }
                pokemons.Add(pokemons[0]);
            }

            return distance;
        }
    }
}
