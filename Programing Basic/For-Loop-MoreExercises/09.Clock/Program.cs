using System;

namespace _09.Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = 0;
            int hours = 0;
            for (int i = 0; i < 1440; i++)
            {
                if (minutes > 59)
                {
                    minutes = 0;
                    hours++;
                }
                Console.WriteLine($"{hours} : {minutes}");
                minutes++;
            }
        }
    }
}
