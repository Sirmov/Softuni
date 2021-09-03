using System;

namespace _01.Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string group = string.Empty;

            if (age < 2)
            {
                group = "baby";
            }
            else if (age < 14)
            {
                group = "child";
            }
            else if (age < 20)
            {
                group = "teenager";
            }
            else if (age < 66)
            {
                group = "adult";
            }
            else
            {
                group = "elder";
            }

            Console.WriteLine(group);
        }
    }
}
