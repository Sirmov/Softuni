using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dragon>> dragons = new Dictionary<string, List<Dragon>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string type = input[0];
                Dragon dragon = new Dragon(input[1], input[2], input[3], input[4]);

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new List<Dragon>());
                }

                if (dragons[type].Any(x => x.Name == dragon.Name))
                {
                    dragons[type].Find(x => x.Name == dragon.Name).Damage = dragon.Damage;
                    dragons[type].Find(x => x.Name == dragon.Name).Health = dragon.Health;
                    dragons[type].Find(x => x.Name == dragon.Name).Armor = dragon.Armor;
                }
                else
                {
                    dragons[type].Add(dragon);
                }
            }

            foreach (var type in dragons)
            {
                Console.WriteLine($"{type.Key}::({type.Value.Average(x => x.Damage):F2}/{type.Value.Average(x => x.Health):F2}/{type.Value.Average(x => x.Armor):F2})");

                foreach (var dragon in type.Value.OrderBy(x => x.Name))
                {
                    Console.WriteLine(dragon.ToString());
                }
            }
        }
    }

    class Dragon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public Dragon(string name, string damage, string health, string armour)
        {
            Name = name;

            if (damage == "null")
            {
                Damage = 45;
            }
            else
            {
                Damage = int.Parse(damage);
            }

            if (health == "null")
            {
                Health = 250;
            }
            else
            {
                Health = int.Parse(health);
            }

            if (armour == "null")
            {
                Armor = 10;
            }
            else
            {
                Armor = int.Parse(armour);
            }
        }

        public override string ToString()
        {
            return $"-{Name} -> damage: {Damage}, health: {Health}, armor: {Armor}";
        }
    }
}
