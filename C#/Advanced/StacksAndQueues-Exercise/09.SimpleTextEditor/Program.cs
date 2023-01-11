using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            Stack<string> textVersions = new Stack<string>();
            textVersions.Push(text.ToString());
            int operationsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < operationsCount; i++)
            {
                string command = Console.ReadLine();
                string[] commandArgs = command.Split();
                int operation = int.Parse(commandArgs[0]);

                if (operation == 1)
                {
                    text.Append(command.Substring(2));
                    textVersions.Push(text.ToString());
                }
                else if (operation == 2)
                {
                    int count = int.Parse(commandArgs[1]);
                    for (int j = 0; j < count; j++)
                    {
                        text.Remove(text.Length - 1, 1);
                    }
                    textVersions.Push(text.ToString());
                }
                else if (operation == 3)
                {
                    int index = int.Parse(commandArgs[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (operation == 4)
                {
                    if (text.ToString() == textVersions.Peek())
                    {
                        textVersions.Pop();
                        text = new StringBuilder(textVersions.Peek());
                    }
                }
            }
        }
    }
}
