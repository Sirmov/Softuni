using System;

namespace _10.MultiplyBy2
{
    class Program
    {
        static void Main(string[] args)
        {
            double current = double.Parse(Console.ReadLine());
            while (current >= 0)
            {
                Console.WriteLine($"Result: {current * 2:F2}");
                current = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Negative number!");
        }
    }
}
