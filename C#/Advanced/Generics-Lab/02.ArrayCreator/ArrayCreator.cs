using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    static public class ArrayCreator
    {
        static public T[] Create<T>(int lenght, T item)
        {
            T[] array = new T[lenght];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = item;
            }

            return array;
        }
    }
}
