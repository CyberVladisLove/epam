
using System;
using System.Collections.Generic;
using System.Linq;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            A boba = new A("aboba");
            A amogus = new A("amogus");
            List<A> list1 = new List<A> { boba, amogus };
            DynamicArray<A> arr = new(list1);
            DynamicArray<A> arrClone = (DynamicArray<A>)arr.Clone();
            boba.name = "amigos";
            
            
            foreach (var elem in arr)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine("\nCap arr:" + arr.Capacity);
            Console.WriteLine("Count arr:" + arr.Count);

            foreach (var elem in arrClone)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine("\nCap arrClone:" + arrClone.Capacity);
            Console.WriteLine("Count arrClone:" + arrClone.Count);

        }
    }
}
