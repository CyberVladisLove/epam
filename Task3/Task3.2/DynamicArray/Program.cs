
using System;
using System.Collections.Generic;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            A boba = new A("boba");
            A amogus = new A("amogus");
            List<A> list1 = new List<A> { boba, amogus };
            
            DynamicArray<A> arr = new(list1);


            var array = arr.ToArray();
            
            var arr2 = (DynamicArray < A > )arr.Clone();
            foreach (var elem in array)
            {
                Console.Write(elem + " ");
            }
            boba.name = "an4ous";
            foreach (var elem in array)
            {
                Console.Write(elem + " ");
            }
            //Console.WriteLine(arr.Capacity);
            //Console.WriteLine(arr.Count);
            //arr.Remove("d");
            ////arr.Remove("d");
            //Console.WriteLine("after remove: " + arr);
            //Console.WriteLine(arr.Capacity);
            //Console.WriteLine(arr.Count);


        }
    }
}
