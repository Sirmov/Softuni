using System;

namespace _01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            double students = double.Parse(Console.ReadLine());
            double lectures = double.Parse(Console.ReadLine());
            double bonus = double.Parse(Console.ReadLine());

            double maxBonus = 0;
            int maxAttendance = 0;

            for (double i = 0; i < students; i++)
            {
                double attendance = double.Parse(Console.ReadLine());
                double currBonus = attendance / lectures * (5 + bonus);
                if (currBonus > maxBonus)
                {
                    maxBonus = currBonus;
                    maxAttendance = (int)attendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendance} lectures.");
        }
    }
}
