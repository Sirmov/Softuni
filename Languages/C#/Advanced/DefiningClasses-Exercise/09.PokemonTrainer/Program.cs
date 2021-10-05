using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string input = Console.ReadLine();
            while (input != "Tournament")
            {
                string[] inputArgs = input.Split();
                string trainerName = inputArgs[0];
                string pokemonName = inputArgs[1];
                string pokemonElement = inputArgs[2];
                int pokemonHealth = int.Parse(inputArgs[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainers[trainerName].Pokemons.Add(pokemon);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                foreach (var (key, trainer) in trainers)
                {
                    string element = input;

                    if (trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainers[key].BadgesCount++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;

                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainers[key].Pokemons.Remove(trainer.Pokemons[i]);
                                i--;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var (key, trainer) in trainers
                .OrderByDescending(t => t.Value.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }
        }
    }
}
