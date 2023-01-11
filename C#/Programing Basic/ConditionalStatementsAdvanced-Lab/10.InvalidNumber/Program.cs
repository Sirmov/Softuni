using System;

namespace _10.InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            if (num >= 100 && num <= 200 || num == 0)
            {

            }
            else
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
