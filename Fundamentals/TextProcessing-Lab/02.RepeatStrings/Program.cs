using System;
using System.Text;
using System.Linq;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            StringBuilder str = new StringBuilder();

            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        str.Append(word[j]);
                    }
                }
            }

            Console.WriteLine(str);
        }
    }
}
