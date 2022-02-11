﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Array
{
    public class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray() : base() { }
        public CycledDynamicArray(int capacity) : base(capacity) { }
        public CycledDynamicArray(IEnumerable<T> collection) : base(collection) { }
        
        public override IEnumerator<T> GetEnumerator()
        {
            while (true) 
            {
                for (int i = 0; i < Count; i++) yield return this[i];
                //Thread.Sleep(200);
            }
        }
    }
}
