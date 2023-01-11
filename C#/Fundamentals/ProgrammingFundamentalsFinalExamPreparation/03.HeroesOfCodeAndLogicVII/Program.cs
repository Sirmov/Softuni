using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Heroe> heroes = new Dictionary<string, Heroe>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] heroe = Console.ReadLine().Split();
                int hp = int.Parse(heroe[1]);
                int mp = int.Parse(heroe[2]);

                if (!heroes.ContainsKey(heroe[0]))
                {
                    heroes.Add(heroe[0], new Heroe(hp, mp));
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commnadArgs = command.Split(" - ");
                string operation = commnadArgs[0];
                string name = commnadArgs[1];

                if (operation == "CastSpell")
                {
                    heroes[name].CastSpell(name, int.Parse(commnadArgs[2]), commnadArgs[3]);
                }
                else if (operation == "TakeDamage")
                {
                    if (heroes[name].TakeDamage(name, int.Parse(commnadArgs[2]), commnadArgs[3]))
                    {
                        heroes.Remove(name);
                    }
                }
                else if (operation == "Recharge")
                {
                    heroes[name].Recharge(name, int.Parse(commnadArgs[2]));
                }
                else if (operation == "Heal")
                {
                    heroes[name].Heal(name, int.Parse(commnadArgs[2]));
                }

                command = Console.ReadLine();
            }

            foreach (var hero in heroes.OrderByDescending(x => x.Value.Health).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value.Health}");
                Console.WriteLine($"  MP: {hero.Value.Mana}");
            }
        }
    }

    class Heroe
    {
        public int Health { get; set; }
        public int Mana { get; set; }

        public Heroe(int health, int mana)
        {
            Health = health;
            Mana = mana;
        }

        public void CastSpell(string name, int mp, string spell)
        {
            if (Mana >= mp)
            {
                Mana -= mp;
                Console.WriteLine($"{name} has successfully cast {spell} and now has {Mana} MP!");
            }
            else
            {
                Console.WriteLine($"{name} does not have enough MP to cast {spell}!");
            }
        }

        public bool TakeDamage(string name, int damage, string attacker)
        {
            Health -= damage;

            if (Health > 0)
            {
                Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {Health} HP left!");
            }
            else
            {
                Console.WriteLine($"{name} has been killed by {attacker}!");
                return true;
            }

            return false;
        }

        public void Recharge(string name, int amount)
        {
            if (Mana + amount > 200)
            {
                Console.WriteLine($"{name} recharged for {200 - Mana} MP!");
                Mana = 200;
            }
            else
            {
                Mana += amount;
                Console.WriteLine($"{name} recharged for {amount} MP!");
            }
        }

        public void Heal(string name, int amount)
        {
            if (Health + amount > 100)
            {
                Console.WriteLine($"{name} healed for {100 - Health} HP!");
                Health = 100;
            }
            else
            {
                Health += amount;
                Console.WriteLine($"{name} healed for {amount} HP!");
            }
        }
    }
}
