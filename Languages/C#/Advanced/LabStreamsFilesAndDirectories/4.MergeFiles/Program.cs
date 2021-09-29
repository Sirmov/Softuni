using System;
using System.IO;

namespace _4.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines1 = File.ReadAllLines("input1.txt");
            string[] lines2 = File.ReadAllLines("input2.txt");

            int shorterLenght = Math.Min(lines1.Length, lines2.Length);

            for (int i = 0; i < shorterLenght; i++)
            {
                File.AppendAllLines(@"..\..\..\output.txt", new string[] { lines1[i] });
                File.AppendAllLines(@"..\..\..\output.txt", new string[] { lines2[i] });
            }

            int count = lines1.Length - lines2.Length;
            Func<string[]> func = () => null;

            if (count > 0)
            {
                func = () => lines1;
            }
            else
            {
                func = () => lines2;
            }

            count = Math.Abs(count);

            for (int i = count - 1; i >= 0; i--)
            {
                File.AppendAllLines(@"..\..\..\output.txt", new string[] { func()[func().Length - 1 - i] });
            }
        }
    }
}
