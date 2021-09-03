using System;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder(Console.ReadLine());
            int reminder = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '>')
                {
                    int power = int.Parse(text[i + 1].ToString()) + reminder;

                    for (int j = 0; j < power; j++)
                    {
                        if (i + 1 < text.Length)
                        {
                            if (text[i + 1] == '>')
                            {
                                reminder = power - j;
                                break;
                            }

                            text.Remove(i + 1, 1);
                        }
                    }
                }
            }

            Console.WriteLine(text);
        }
    }
}
