using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomLib;

namespace WeakestText
{
    class WeakestLink
    {
        public static void Run()
        {
            int n;
            int num;
            while (true)
            {
                Console.WriteLine("Введите N:");
                n = CustomInput.ReadOnlyNumber();
                if (n <= 0) Console.Write("Введите положительное число");
                else break;
            }
            while (true)
            {
                Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд:");
                num = CustomInput.ReadOnlyNumber();
                if (num > n) Console.Write("Вычеркивание невозможно, т.к. число больше N");
                else break;
            }

            List<int> humans = new();
            Console.WriteLine("Изначально: ");
            for (int i = 1; i <= n; i++)
            {
                humans.Add(i);
                Console.Write(humans[i - 1] + " ");
            }
            Console.WriteLine();
            int raund = 1;
            int count = humans.Count;
            int a = 0;
            while (raund != 6)
            {

                for (int i = num + a; i <= count; i += num * raund)
                {
                    humans.Remove(i);

                }
                a += raund;

                Console.WriteLine("Раунд №" + raund);
                raund++;
                foreach (var i in humans)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
