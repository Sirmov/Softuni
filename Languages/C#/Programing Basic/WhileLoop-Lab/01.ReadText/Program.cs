using System;

namespace _01.ReadText
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            while (text != "Stop")
            {
                Console.WriteLine(text);
                text = Console.ReadLine();
            }
        }
    }
}
