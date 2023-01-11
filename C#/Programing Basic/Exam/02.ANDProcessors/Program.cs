using System;

namespace _02.ANDProcessors
{
    class Program
    {
        static void Main(string[] args)
        {
            int CPUTarget = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int hours = workers * days * 8;
            double CPU = Math.Floor(hours / 3.0);
            if (CPU >= CPUTarget)
            {
                Console.WriteLine($"Profit: -> {(CPU - CPUTarget) * 110.10:F2} BGN");
            }
            else
            {
                Console.WriteLine($"Losses: -> {(CPUTarget - CPU) * 110.10:F2} BGN");
            }
        }
    }
}
