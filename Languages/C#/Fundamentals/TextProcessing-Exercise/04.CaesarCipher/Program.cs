using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder message = new StringBuilder();

            foreach (var ch in text)
            {
                message.Append((char) (ch + 3));
            }

            Console.WriteLine(message);
        }
    }
}
