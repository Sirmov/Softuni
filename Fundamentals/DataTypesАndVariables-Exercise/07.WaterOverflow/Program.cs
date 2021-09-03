using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = 255;
            int capacity = 0;
            int iterations = int.Parse(Console.ReadLine());

            for (int i = 0; i < iterations; i++)
            {
                int curr = int.Parse(Console.ReadLine());
                if (capacity + curr > maxCapacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    capacity += curr;
                }
            }

            Console.WriteLine(capacity);
        }
    }
}
