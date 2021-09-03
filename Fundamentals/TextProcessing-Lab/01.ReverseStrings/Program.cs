using System;
using System.Text;
using System.Linq;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder reversed = new StringBuilder();
            string text = Console.ReadLine();

            while (text != "end")
            {
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    reversed.Append(text[i]);
                }

                Console.WriteLine($"{text} = {reversed}");
                reversed.Clear();
                text = Console.ReadLine();
            }
        }
    }
}
