using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            while (command != "3:1")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] == "merge")
                {
                    int startingIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);
                    Merge(data, startingIndex, endIndex);
                }
                else if (commandArgs[0] == "divide")
                {
                    int index = int.Parse(commandArgs[1]);
                    int partitions = int.Parse(commandArgs[2]);
                    Devide(data, index, partitions);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', data));
        }

        static void Devide(List<string> data, int index, int parts)
        {
            string str = data[index];
            int partsLength = str.Length / parts;
            bool isExact = str.Length % parts == 0;
            List<string> result = new List<string>();
            int count = 0;

            for (int i = 0; i < parts; i++)
            {
                string part = String.Empty;

                if (!isExact && i == parts - 1)
                {
                    for (int j = count; j < str.Length; j++)
                    {
                        part += str[j];
                    }
                }
                else
                {
                    for (int j = 0; j < partsLength; j++)
                    {
                        part += str[j + count];
                    }
                }

                result.Add(part);
                count += partsLength;
            }

            data.InsertRange(index, result);
            data.RemoveAt(index + parts);
        }

        static void Merge(List<string> data, int startingIndex, int endIndex)
        {
            if (startingIndex >= data.Count - 1 || endIndex <= 0)
            {
                return;
            }

            if (startingIndex < 0)
            {
                startingIndex = 0;
            }

            if (endIndex > data.Count - 1)
            {
                endIndex = data.Count - 1;
            }

            string merged = string.Empty;

            for (int i = startingIndex; i <= endIndex; i++)
            {
                merged += data[i];
            }

            data.Insert(startingIndex, merged);
            data.RemoveRange(startingIndex + 1, endIndex - startingIndex + 1);
        }
    }
}
