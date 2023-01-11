using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);

            Console.WriteLine(list.Contains(0));
            Console.WriteLine(list.Contains(5));
            Console.WriteLine(list.Contains(11));

            //list.RemoveAt(-1);
            //list.RemoveAt(12);

            //list.Swap(5, 12);
            list.Swap(0, 9);


        }
    }
}
