using System;

namespace _07.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double record = meters * secondsPerMeter;
            record += Math.Floor(meters / 15) * 12.5;

            if (record < worldRecord)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {record:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {record - worldRecord:F2} seconds slower.");
            }
        }
    }
}
