using System;

namespace _03.StreamOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int cCount = 0;
            int oCount = 0;
            int nCount = 0;
            string input = Console.ReadLine();
            string word = "";
            while (input != "End")
            {
                if (input == "c")
                {
                    cCount++;
                }
                if (input == "o")
                {
                    oCount++;
                }
                if (input == "n")
                {
                    nCount++;
                }

            }
        }
    }
}
