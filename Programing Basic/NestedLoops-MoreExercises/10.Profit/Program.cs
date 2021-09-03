using System;

namespace _10.Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());
            int five = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int k = 0; k <= one; k++)
            {
                for (int j = 0; j <= two; j++)
                {
                    for (int i = 0; i <= five; i++)
                    {
                        if (i * 5 + j * 2 + k * 1 == sum)
                        {
                            Console.WriteLine($"{k} * 1 lv. + {j} * 2 lv. + {i} * 5 lv. = {sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
