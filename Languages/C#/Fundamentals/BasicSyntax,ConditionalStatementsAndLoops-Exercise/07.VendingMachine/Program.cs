using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = 0;
            string moneyInput = Console.ReadLine();
            while (moneyInput != "Start")
            {
                switch (double.Parse(moneyInput))
                {
                    //0.1, 0.2, 0.5, 1, and 2
                    case 0.1:
                        balance += 0.1;
                        break;
                    case 0.2:
                        balance += 0.2;
                        break;
                    case 0.5:
                        balance += 0.5;
                        break;
                    case 1:
                        balance += 1;
                        break;
                    case 2:
                        balance += 2;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {moneyInput}");
                        break;
                }
                moneyInput = Console.ReadLine();
            }

            string productInput = Console.ReadLine();
            while (productInput != "End")
            {
                switch (productInput)
                {
                    case "Nuts":
                        if (balance >= 2)
                        {
                            balance -= 2;
                            Console.WriteLine($"Purchased {productInput.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Water":
                        if (balance >= 0.7)
                        {
                            balance -= 0.7;
                            Console.WriteLine($"Purchased {productInput.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Crisps":
                        if (balance >= 1.5)
                        {
                            balance -= 1.5;
                            Console.WriteLine($"Purchased {productInput.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Soda":
                        if (balance >= 0.8)
                        {
                            balance -= 0.8;
                            Console.WriteLine($"Purchased {productInput.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Coke":
                        if (balance >= 1)
                        {
                            balance -= 1;
                            Console.WriteLine($"Purchased {productInput.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
                productInput = Console.ReadLine();
            }
            Console.WriteLine($"Change: {balance:F2}");
        }
    }
}
