
using System;
using System.Collections.Generic;
using System.Linq;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //A boba = new A("aboba");
            //A amogus = new A("amogus");
            //List<A> list1 = new List<A> { boba, amogus,boba, boba, amogus, boba,boba, amogus, boba,boba, amogus, boba };
            //List<A> list2 = new List<A> {new A("barabashka") };
            List<int> list1 = new List<int> { 1,2,3 };

            Console.WriteLine("===Создание массива===");
            DynamicArray<int> arr = new(list1);
            
            PrintInfo(arr);

            Console.WriteLine("===Add(4)===");
            arr.Add(4);
            PrintInfo(arr);

            Console.WriteLine("===AddRange(5,6)===");
            arr.AddRange(new List<int>() {5,6});
            PrintInfo(arr);

            Console.WriteLine("===Insert(4,555)===");
            arr.Insert(4,555);
            PrintInfo(arr);

            Console.WriteLine("===Remove(1)===");
            arr.Remove(1);
            PrintInfo(arr);

            

        }
        public static void PrintInfo<T>(DynamicArray<T> arr)
        {
            //Console.WriteLine(arr.ToString());
            foreach (var item in arr) Console.Write(item + " ");
            Console.WriteLine("\nCapacity = " + arr.Capacity);
            Console.WriteLine("Count = " + arr.Count);
            Console.WriteLine();
        }
    }
}
