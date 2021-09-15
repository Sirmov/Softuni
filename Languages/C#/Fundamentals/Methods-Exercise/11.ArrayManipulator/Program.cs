using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command.IndexOf("exchange ") >= 0)
                {
                    int index = int.Parse(GetIndex(command, "exchange "));
                    array = Exchange(array, index);
                }
                else if (command.IndexOf("max ") >= 0)
                {
                    string parity = (GetParity(command, "max "));
                    MaxParityIndex(array, parity);
                }
                else if (command.IndexOf("min ") >= 0)
                {
                    string parity = (GetParity(command, "min "));
                    MinParityIndex(array, parity);
                }
                else if (command.IndexOf("first ") >= 0)
                {

                    string count = GetCount(command, "first ");
                    string parity = GetParity(command, "first " + count + " ");
                    FirstParityNums(array, int.Parse(count), parity);
                }
                else if (command.IndexOf("last ") >= 0)
                {
                    string count = GetCount(command, "last ");
                    string parity = GetParity(command, "last " + count + " ");
                    LastParityNums(array, int.Parse(count), parity);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        static void LastParityNums(int[] array, int count, string parity)
        {
            int[] arr = array.ToArray();
            int[] result = new int[count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = -1;
            }
            int found = 0;

            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (parity == "even")
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 == 0)
                    {
                        result[found] = arr[i];
                        found++;
                    }

                    if (found == count)
                    {
                        break;
                    }
                }
            }
            else if (parity == "odd")
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 != 0)
                    {
                        result[found] = arr[i];
                        found++;
                    }

                    if (found == count)
                    {
                        break;
                    }
                }
            }

            Console.Write("[");
            for (int i = found - 1; i >= 0; i--)
            {
                if (i == 0 && result[i] != -1)
                {
                    Console.Write(result[i]);
                }
                else if (result[i] != -1 && i != 0)
                {
                    Console.Write(result[i] + ", ");
                }
            }
            Console.Write("]");
            Console.WriteLine();
        }

        static void FirstParityNums(int[] array, int count, string parity)
        {
            int[] arr = array.ToArray();
            int[] result = new int[count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = -1;
            }
            int found = 0;

            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (parity == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        result[found] = arr[i];
                        found++;
                    }

                    if (found == count)
                    {
                        break;
                    }
                }
            }
            else if (parity == "odd")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0)
                    {
                        result[found] = arr[i];
                        found++;
                    }

                    if (found == count)
                    {
                        break;
                    }
                }
            }

            Console.Write("[");
            for (int i = 0; i < found; i++)
            {
                if (i == found - 1 && result[i] != -1)
                {
                    Console.Write(result[i]);
                }
                else if (result[i] != -1 && i != found - 1)
                {
                    Console.Write(result[i] + ", ");
                }
            }
            Console.Write("]");
            Console.WriteLine();
        }

        static string GetCount(string command, string index)
        {
            string str = string.Empty;
            int i = index.Length;

            while (command[i] != ' ')
            {
                str += command[i];
                i++;
            }

            return str;
        }

        static void MinParityIndex(int[] arr, string parity)
        {
            int min = int.MaxValue;
            int index = -1;
            int[] array = arr.ToArray();

            if (parity == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] <= min && array[i] % 2 == 0)
                    {
                        min = array[i];
                        index = i;
                    }
                }
            }
            else if (parity == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] <= min && array[i] % 2 != 0)
                    {
                        min = array[i];
                        index = i;
                    }
                }
            }

            if (min == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        static void MaxParityIndex(int[] arr, string parity)
        {
            int max = int.MinValue;
            int index = -1;
            int[] array = arr.ToArray();

            if (parity == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] >= max && array[i] % 2 == 0)
                    {
                        max = array[i];
                        index = i;
                    }
                }
            }
            else if (parity == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] >= max && array[i] % 2 != 0)
                    {
                        max = array[i];
                        index = i;
                    }
                }
            }

            if (max == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        static int[] Exchange(int[] arr, int index)
        {
            int[] array = arr.ToArray();
            
            if (index < 0 || index >= array.Length)
            {
                Console.WriteLine("Invalid index");
                return array;
            }

            int[] arr1 = new int[index + 1];
            int[] arr2 = new int[array.Length - (index + 1)];

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = array[i];
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = array[array.Length - 1 - i];
            }

            arr2 = arr2.Reverse().ToArray();

            for (int i = 0; i < arr2.Length; i++)
            {
                array[i] = arr2[i];
            }

            for (int i = arr2.Length; i < array.Length; i++)
            {
                array[i] = arr1[i - arr2.Length];
            }

            return array;
        }

        static string GetParity(string command, string index)
        {
            int start = command.IndexOf(index) + index.Length;
            int end = command.Length;
            string result = string.Empty;

            for (int i = start; i < end; i++)
            {
                result += command[i];
            }

            return result;
        }

        static string GetIndex(string command, string index)
        {
            int start = command.IndexOf(index) + index.Length;
            int end = command.Length;
            string result = string.Empty;

            for (int i = start; i < end; i++)
            {
                result += command[i];
            }

            return result;
        }
    }
}
