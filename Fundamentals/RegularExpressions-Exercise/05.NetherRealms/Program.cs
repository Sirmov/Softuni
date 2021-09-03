using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"[^\s,]+");
            Regex numbers = new Regex(@"[\d]+(\.[0-9]+)?|-[\d+]+(\.[0-9]+)?");
            Regex multiplication = new Regex(@"[*/]");
            string input = Console.ReadLine();
            List<Demon> demons = new List<Demon>();

            foreach (Match demon in regex.Matches(input))
            {
                int health = 0;

                foreach (var ch in demon.Value)
                {
                    if (!char.IsDigit(ch) && ch != '+' && ch != '-' && ch != '*' && ch != '/' && ch != '.')
                    {
                        health += ch;
                    }
                }

                double damage = 0;

                foreach (Match match in numbers.Matches(demon.Value))
                {
                    damage += double.Parse(match.Value);
                }

                foreach (Match match in multiplication.Matches(demon.Value))
                {
                    if (match.Value == "*")
                    {
                        damage *= 2;
                    }
                    else if (match.Value == "/")
                    {
                        damage /= 2;
                    }
                }

                demons.Add(new Demon(demon.Value, health, damage));
            }

            foreach (var demon in demons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }
    }

    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public Demon(string name, int health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
