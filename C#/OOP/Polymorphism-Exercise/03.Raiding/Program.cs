using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HeroFactory factory = null;
            List<BaseHero> heroes = new List<BaseHero>();

            while (heroes.Count != n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    factory = new HeroFactory(name, type);
                    heroes.Add(factory.CreateHero());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            long bossHealth = long.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                bossHealth -= hero.Power;
            }

            if (bossHealth <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}