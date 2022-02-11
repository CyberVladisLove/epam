using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime 
{ 
    public class SuperArray
    {
        public static void Run()
        {
            int[] intArr = new int[5] { 1, 4, 4, 5, 5 };
            float[] flaotArr = new float[5] { 1f, 2f, 5f, 4f, 5f };

            intArr.ApplyToArray(Divide2);
            flaotArr.ApplyToArray(Divide2);

            foreach (var a in intArr) Console.Write(a + " ");
            Console.WriteLine();
            foreach (var a in flaotArr) Console.Write(a + " ");
            Console.WriteLine();
            Console.WriteLine(intArr.SearchInArray(MostOftenElement));
            
            
        }

        private static int Pow2(int num) => num * num;
        private static int Divide2(int num) => num / 2;
        private static int Multiply2(int num) => num * 2;

        private static float Pow2(float num) => num * num;
        private static float Divide2(float num) => num / 2;
        private static float Multiply2(float num) => num * 2;

        private static float Average(int[] arr) => (float)arr.Sum() / (float)arr.Length; 
        private static int Sum(int[] arr) => arr.Sum();
        private static int MostOftenElement(int[] arr)
          => arr.GroupBy(x => x)
                .OrderByDescending(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Count())
                .FirstOrDefault()
                .Key;
    }
}
