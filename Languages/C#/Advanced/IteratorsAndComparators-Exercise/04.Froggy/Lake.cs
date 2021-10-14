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
            return new LakeEnumerator(Stones);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
