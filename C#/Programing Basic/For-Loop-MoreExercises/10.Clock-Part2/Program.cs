using System;

namespace _10.Clock_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconds = 0;
            int minutes = 0;
            int hours = 0;
            for (int i = 0; i < 86400; i++)
            {
                if (seconds > 59)
                {
                    seconds = 0;
                    minutes++;
                }
                if (minutes > 59)
                {
                    minutes = 0;
                    hours++;
                }
                Console.WriteLine($"{hours} : {minutes} : {seconds} ");
                seconds++;
            }
        }
    }
}
