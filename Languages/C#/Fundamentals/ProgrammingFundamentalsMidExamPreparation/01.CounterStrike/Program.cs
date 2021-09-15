using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int won = 0;

            while (command != "End of battle")
            {
                int distance = int.Parse(command);

                if (energy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {won} won battles and {energy} energy");
                    Environment.Exit(0);
                }
                else
                {
                    energy -= distance;
                    won++;
                }
                
                if (won % 3 == 0)
                {
                    energy += won;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {won}. Energy left: {energy}");
        }
    }
}
