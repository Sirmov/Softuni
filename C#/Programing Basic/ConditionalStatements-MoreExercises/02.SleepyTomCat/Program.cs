namespace ConsoleApp1
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            int freeDays = int.Parse(Console.ReadLine());
            int workDays = 365 - freeDays;
            int playMinutes = freeDays * 127 + workDays * 63;
            int minutesLessToPlay = ((playMinutes - 30000) % 60) * -1;
            int hoursLessToPlay = ((playMinutes - 30000) / 60) * -1;
            int minutesToPlay = (playMinutes - 30000) % 60;
            int hoursToPlay = (playMinutes - 30000) / 60;
            if (playMinutes < 30000)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hoursLessToPlay} hours and {minutesLessToPlay} minutes less for play");
            }
            else
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hoursToPlay} hours and {minutesToPlay} minutes more for play");
            }
        }
    }
}