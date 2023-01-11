using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    class Lake : IEnumerable<int>
    {
        public Lake(params int[] stones)
        {
            Stones = stones.ToList();
        }

        public List<int> Stones { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return Stones[i];
                }
            }

            for (int i = Stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return Stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
