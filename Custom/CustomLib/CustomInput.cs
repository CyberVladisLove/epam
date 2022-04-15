using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLib
{
    public class CustomInput
    {
        public static int ReadOnlyNumber()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int res)) return res;
                else Console.WriteLine("Введите пожалуйста целое число");
            }

        }

        //ввод чисел строго в диапазоне включительно a и b
        public static int ReadOnlyNumber(int a, int b)
        {
            while (true)
            {
                int res = ReadOnlyNumber();
                if (res >= a && res <= b) return res;
                else Console.WriteLine($"Введите пожалуйста целое число в диапазоне {a} - {b}");
            }

        }
        public static Point InputNewPoint()
        {
            Console.Write("Введите координаты точки:\nx=");
            int x = ReadOnlyNumber();
            Console.Write("y=");
            int y = ReadOnlyNumber();
            return new Point(x, y);
        }
    }
}
