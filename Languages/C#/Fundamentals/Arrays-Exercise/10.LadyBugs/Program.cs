using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] field = new int[fieldSize];

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 0 && input[i] < field.Length)
                {
                    field[input[i]] = 1;
                }
            }

            string command = Console.ReadLine();
                
            while (command != "end")
            {
                string[] commandsArr = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int index = int.Parse(commandsArr[0]);
                string direction = commandsArr[1];
                int power = int.Parse(commandsArr[2]);

                

                if (index >= 0 && index < field.Length && field[index] == 1)
                {
                    if (direction == "right")
                    {
                        if (index + power < 0 || index + power >= field.Length)
                        {
                            field[index] = 0;
                        }
                        else if (field[index + power] == 1)
                        {
                            int count = 0;
                            if (power < 0)
                            {
                                count = 1;
                            }
                            else
                            {
                                count = -1;
                            }
                            while (true)
                            {
                                if (index + power + count < 0 || index + power + count >= field.Length)
                                {
                                    field[index] = 0;
                                    break;
                                }

                                if (field[index + power + count] != 1)
                                {
                                    field[index] = 0;
                                    field[index + power + count] = 1;
                                    break;
                                }

                                if (power < 0)
                                {
                                    count++;
                                }
                                else
                                {
                                    count--;
                                }
                            }
                        }
                        else if (field[index + power] != 1)
                        {
                            field[index] = 0;
                            field[index + power] = 1;
                        }
                    }
                    else if (direction == "left")
                    {
                        if (index - power < 0 || index - power >= field.Length)
                        {
                            field[index] = 0;
                        }
                        else if (field[index - power] == 1)
                        {
                                int count = 1;
                            while (true)
                            {
                                if (index - power + count < 0 || index - power + count >= field.Length)
                                {
                                    field[index] = 0;
                                    break;
                                }

                                if (field[index - power + count] != 1)
                                {
                                    field[index] = 0;
                                    field[index - power + count] = 1;
                                    break;
                                }

                                count++;
                            }
                        }
                        else if (field[index - power] != 1)
                        {
                            field[index] = 0;
                            field[index - power] = 1;
                        }
                    }
                    
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
