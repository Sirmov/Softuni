using System;

namespace _05.DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            string result = String.Empty;

            for (int i = 0; i < lines; i++)
            {
                char curr = char.Parse(Console.ReadLine());
                curr += (char)key;
                result += curr;
            }

            Console.WriteLine(result);
        }
    }
}
