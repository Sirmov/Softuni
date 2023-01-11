using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int wastedFood = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                int guest = guests.Peek();

                while (guest > 0)
                {
                    int plate = plates.Peek();
                    guest -= plate;

                    if (guest <= 0)
                    {
                        wastedFood += Math.Abs(guest);
                        guests.Dequeue();
                    }

                    plates.Pop();
                }
            }

            if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
