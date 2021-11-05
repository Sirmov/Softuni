using System;

namespace _08.CollectionHierarchy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] elements = Console.ReadLine().Split();
            int[][] addOutput = new int[3][];
            addOutput[0] = new int[elements.Length];
            addOutput[1] = new int[elements.Length];
            addOutput[2] = new int[elements.Length];

            for (int i = 0; i < elements.Length; i++)
            {
                addOutput[0][i] = addCollection.Add(elements[i]);
            }

            for (int i = 0; i < elements.Length; i++)
            {
                addOutput[1][i] = addRemoveCollection.Add(elements[i]);
            }

            for (int i = 0; i < elements.Length; i++)
            {
                addOutput[2][i] = myList.Add(elements[i]);
            }

            foreach (var item in addOutput)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            int removeCount = int.Parse(Console.ReadLine());

            string[][] removeOutput = new string[2][];
            removeOutput[0] = new string[removeCount];
            removeOutput[1] = new string[removeCount];

            for (int i = 0; i < removeCount; i++)
            {
                removeOutput[0][i] = addRemoveCollection.Remove();
            }

            for (int i = 0; i < removeCount; i++)
            {
                removeOutput[1][i] = myList.Remove();
            }

            foreach (var item in removeOutput)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}