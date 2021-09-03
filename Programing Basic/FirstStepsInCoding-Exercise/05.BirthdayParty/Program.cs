using System;

namespace _05.BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());
            double cake = rent * 0.20;
            double drinks = cake - cake * 0.45;
            double animator = rent / 3;
            double sum = rent + cake + drinks + animator;
            Console.WriteLine(sum);
        }
    }
}
