using System;
using System.Text;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Sign up")
            {
                string[] commandArgs = command.Split(" ");
                string operation = commandArgs[0];

                if (operation == "Case")
                {
                    string type = commandArgs[1];

                    if (type == "upper")
                    {
                        StringBuilder flip = new StringBuilder(username.Length);

                        for (int i = 0; i < username.Length; i++)
                        {
                            flip.Append(char.ToUpper(username[i]));
                        }

                        username = flip.ToString();
                    }
                    else if (type == "lower")
                    {
                        StringBuilder flip = new StringBuilder(username.Length);

                        for (int i = 0; i < username.Length; i++)
                        {
                            flip.Append(char.ToLower(username[i]));
                        }

                        username = flip.ToString();
                    }

                    Console.WriteLine(username);
                }
                else if (operation == "Reverse")
                {
                    int start = int.Parse(commandArgs[1]);
                    int end = int.Parse(commandArgs[2]);

                    if (isValid(start, end, username))
                    {
                        StringBuilder reverse = new StringBuilder();
                        string substring = username.Substring(start, end - start + 1);

                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reverse.Append(substring[i]);
                        }

                        Console.WriteLine(reverse);
                    }
                }
                else if (operation == "Cut")
                {
                    string substring = commandArgs[1];

                    if (username.Contains(substring))
                    {
                        username = username.Remove(username.IndexOf(substring), substring.Length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}");
                    }
                }
                else if (operation == "Replace")
                {
                    char ch = char.Parse(commandArgs[1]);
                    username = username.Replace(ch, '*');
                    Console.WriteLine(username);
                }
                else if (operation == "Check")
                {
                    char ch = char.Parse(commandArgs[1]);

                    if (username.Contains(ch))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {ch}.");
                    }
                }

                command = Console.ReadLine();
            }
        }

        static bool isValid(int start, int end, string str)
        {
            if ((start >= 0 && start < str.Length) && (end >= 0 && end < str.Length))
            {
                return true;
            }

            return false;
        }
    }
}
