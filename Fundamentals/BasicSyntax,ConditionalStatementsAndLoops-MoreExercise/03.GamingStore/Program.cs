using System;

namespace _03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double spent = 0;

            while (input != "Game Time")
            {
                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }

                switch (input)
                {
                    case "OutFall 4":
                        if (balance >= 39.99)
                        {
                            balance -= 39.99;
                            spent += 39.99;
                            Console.WriteLine($"Bought {input}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "CS: OG":
                        if (balance >= 15.99)
                        {
                            balance -= 15.99;
                            spent += 15.99;
                            Console.WriteLine($"Bought {input}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Zplinter Zell":
                        if (balance >= 19.99)
                        {
                            balance -= 19.99;
                            spent += 19.99;
                            Console.WriteLine($"Bought {input}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Honored 2":
                        if (balance >= 59.99)
                        {
                            balance -= 59.99;
                            spent += 59.99;
                            Console.WriteLine($"Bought {input}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch":
                        if (balance >= 29.99)
                        {
                            balance -= 29.99;
                            spent += 29.99;
                            Console.WriteLine($"Bought {input}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch Origins Edition":
                        if (balance >= 39.99)
                        {
                            balance -= 39.99;
                            spent += 39.99;
                            Console.WriteLine($"Bought {input}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${spent:F2}. Remaining: ${balance:F2}");
        }
    }
}
