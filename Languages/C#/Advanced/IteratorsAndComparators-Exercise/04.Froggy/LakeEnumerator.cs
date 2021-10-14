using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    class LakeEnumerator : IEnumerator<int>
    {
        private List<int> collection;

        private bool isReturning;

        int index;

        public LakeEnumerator(List<int> collection)
        {
            this.collection = collection;
            index = -2;
            isReturning = false;
        }

        public int Current =>
            isReturning ? collection[collection.Count - 1 - index] : collection[index];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            index += 2;

            if (collection.Count < 1)
            {
                return false;
            }
            
            if (index >= collection.Count && (isReturning || collection.Count == 1))
            {
                return false;
            }
            else if (index >= collection.Count && !isReturning)
            {
                isReturning = true;

                if (collection.Count % 2 == 0)
                {
                    index = 0;
                }
                else
                {
                    index = 1;
                }

                return true;
            }
            else
            {
                return true;
            }
        }

        public void Reset()
        {
            index = -2;
        }
    }
}
