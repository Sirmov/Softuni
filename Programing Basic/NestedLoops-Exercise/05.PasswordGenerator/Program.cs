using System;

namespace _05.PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 1; k <= l; k++)
                    {
                        for (int m = 1; m <= l; m++)
                        {
                            for (int o = 1; o <= n; o++)
                            {
                                string one = "";
                                string two = "";
                                switch (k)
                                {
                                    case 1:
                                        one = "a";
                                        break;
                                    case 2:
                                        one = "b";
                                        break;
                                    case 3:
                                        one = "c";
                                        break;
                                    case 4:
                                        one = "d";
                                        break;
                                    case 5:
                                        one = "e";
                                        break;
                                    case 6:
                                        one = "f";
                                        break;
                                    case 7:
                                        one = "g";
                                        break;
                                    case 8:
                                        one = "h";
                                        break;
                                    case 9:
                                        one = "i";
                                        break;
                                }
                                switch (m)
                                {
                                    case 1:
                                        two = "a";
                                        break;
                                    case 2:
                                        two = "b";
                                        break;
                                    case 3:
                                        two = "c";
                                        break;
                                    case 4:
                                        two = "d";
                                        break;
                                    case 5:
                                        two = "e";
                                        break;
                                    case 6:
                                        two = "f";
                                        break;
                                    case 7:
                                        two = "g";
                                        break;
                                    case 8:
                                        two = "h";
                                        break;
                                    case 9:
                                        two = "i";
                                        break;
                                }
                                if (o > i && o > j)
                                {
                                Console.Write($"{i}{j}{one}{two}{o} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
