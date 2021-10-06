using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
    class DoublyLinkedList<T>
    {
        private Node<T> first;
        private Node<T> last;

        public int Count { get; set; } = 0;

        public void AddFirst(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                newNode.Next = first;
                first.Previous = newNode;
                first = newNode;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (last == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.Next = newNode;
                newNode.Previous = last;
                last = newNode;
            }

            Count++;
        }

        public Node<T> RemoveFirst()
        {
            Node<T> returnNode;

            if (first == null)
            {
                throw new InvalidOperationException("Linked list is empty!");
            }
            else if (first == last)
            {
                returnNode = first;

                first = null;
                last = null;
                Count--;

                return returnNode;
            }
            else
            {
                returnNode = first;

                first.Next.Previous = null;
                first = first.Next;
                Count--;

                return returnNode;
            }
        }

        public Node<T> RemoveLast()
        {
            Node<T> returnNode;

            if (last == null)
            {
                throw new InvalidOperationException("Linked list is empty!");
            }
            else if (first == last)
            {
                returnNode = last;

                first = null;
                last = null;
                Count--;

                return returnNode;
            }
            else
            {
                returnNode = last;

                last.Previous.Next = null;
                last = last.Previous;
                Count--;

                return returnNode;
            }
        }

        public void ForEach(Action<T> action)
        {
            Node<T> currentNode = first;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            Node<T> currentNode = first;

            for (int i = 0; i < Count; i++)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return array;
        }
    }
}
