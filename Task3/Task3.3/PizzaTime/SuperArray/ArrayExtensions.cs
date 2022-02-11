using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime
{
    public static class ArrayExtensions
    {
        
        public static void ApplyToArray<T>(this T[] array, Func<T, T> action)
        {
            for(int i = 0; i<array.Length; i++) 
                array[i] = action(array[i]);
        }
        public static U SearchInArray<T, U>(this T[] array, Func<T[], U> action) => action(array);

        //использовал в SearchInArray дополнительно U, тк T[] у нас может быть интовый массив,
        //то например среднее значение все же лучше возвращать дробное (U == float||double)


    }
}
