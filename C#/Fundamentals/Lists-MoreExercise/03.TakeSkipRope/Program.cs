using System;
using System.Collections.Generic;

namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string encrypted = Console.ReadLine();
            List<char> nonDigit = new List<char>();
            List<int> take = new List<int>();
            List<int> skip = new List<int>();
            int count = 0;

            foreach (var item in encrypted)
            {
                if (char.IsDigit(item))
                {
                    if (count % 2 == 0)
                    {
                        take.Add(int.Parse(item.ToString()));
                    }
                    else
                    {
                        skip.Add(int.Parse(item.ToString()));
                    }
                    count++;
                }
                else
                {
                    nonDigit.Add(item);
                }
            }

            string decrypted = string.Empty;
            count = 0;

            for (int i = 0; i < take.Count; i++)
            {
                string str = string.Empty;
                int index = take[i] + count;

                if (index > nonDigit.Count)
                {
                    index = nonDigit.Count;
                }

                for (int j = count; j < index; j++)
                {
                    str += nonDigit[j];
                }

                count += skip[i] + take[i];
                decrypted += str;
            }

            Console.WriteLine(decrypted);
        }
    }
}
