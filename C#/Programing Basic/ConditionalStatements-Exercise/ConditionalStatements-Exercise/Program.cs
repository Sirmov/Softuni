using System;

namespace _01.SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            // Може да се оптимизира ($"{:D2}")
            int firstTime = int.Parse(Console.ReadLine());
            int secondsTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());
            
            int totalTime = firstTime + secondsTime + thirdTime;
            int minutes = totalTime / 60;
            int seconds = totalTime % 60;
            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
