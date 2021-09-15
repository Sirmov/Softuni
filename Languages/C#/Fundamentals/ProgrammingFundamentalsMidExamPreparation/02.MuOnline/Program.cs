using System;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;
            string[] rooms = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < rooms.Length; i++)
            {
                string[] roomArgs = rooms[i].Split();
                string type = roomArgs[0];
                int value = int.Parse(roomArgs[1]);

                if (type == "potion")
                {
                    health = Heal(health, value);
                }
                else if (type == "chest")
                {
                    bitcoins += value;
                    Console.WriteLine($"You found {value} bitcoins.");
                }
                else
                {
                    health = Fight(health, type, value);
                    if (health <= 0)
                    {
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }

        static int Fight(int health, string monster, int value)
        {
            health -= value;
            if (health > 0)
            {
                Console.WriteLine($"You slayed {monster}.");
            }
            else
            {
                Console.WriteLine($"You died! Killed by {monster}.");
            }
            return health;
        }

        static int Heal(int health, int value)
        {
            int healedAmount = 0;
            if (health + value >= 100)
            {
                healedAmount = 100 - health;
                health = 100;
            }
            else
            {
                healedAmount = (health + value) - health;
                health = health + value;
            }

            Console.WriteLine($"You healed for {healedAmount} hp.");
            Console.WriteLine($"Current health: {health} hp.");
            return health;
        }
    }
}
