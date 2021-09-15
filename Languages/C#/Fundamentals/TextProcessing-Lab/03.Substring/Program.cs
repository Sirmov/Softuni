using System;
using System.Text;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string remove = Console.ReadLine().ToLower();
            string str = Console.ReadLine();

            while (str.Contains(remove))
            {
                str = str.Remove(str.IndexOf(remove), remove.Length);
            }

            Console.WriteLine(str);
        }
    }
}
