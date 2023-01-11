using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int magazineSize = int.Parse(Console.ReadLine());
            int magazine = magazineSize;
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int payment = int.Parse(Console.ReadLine());

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int bullet = bullets.Peek();
                int @lock = locks.Peek();

                if (bullet <= @lock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    bullets.Pop();
                    payment -= bulletPrice;
                    magazine--;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    payment -= bulletPrice;
                    magazine--;
                }

                if (magazine == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    magazine = magazineSize;
                }
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${payment}");
            }
        }
    }
}
