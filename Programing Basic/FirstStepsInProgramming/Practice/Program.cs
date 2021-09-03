using System;

namespace fifth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Max: ");
            int max = int.Parse(Console.ReadLine());
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            Console.WriteLine($"First {first / max * 100:F2}");
            Console.WriteLine($"Second {second / max * 100:F2}");
            Console.WriteLine($"Third {third / max * 100:F2}");
        }
    }
}