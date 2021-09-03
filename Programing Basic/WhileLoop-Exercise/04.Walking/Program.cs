using System;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            int steps = 0;
            while (steps < goal)
            {
                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    input = Console.ReadLine();
                    steps += int.Parse(input);
                    if (steps < goal)
                    {
                        Console.WriteLine($"{goal - steps} more steps to reach goal.");
                    }
                    else
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{steps - goal} steps over the goal!");
                    }
                    Environment.Exit(0);
                }
                steps += int.Parse(input);
            }
            Console.WriteLine("Goal reached! Good job!");
            Console.WriteLine($"{steps - goal} steps over the goal!");
        }
    }
}
