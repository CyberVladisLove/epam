using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CustomLib;

namespace WeakestText
{

    class WeakestLink
    {
        public static void Run()
        {
            Console.WriteLine("===3.1.1_WeakestLink===");

            int n;
            int num;
            while (true)
            {
                Console.WriteLine("Введите N:");
                n = Math.Abs(CustomInput.ReadOnlyNumber());
                if (n <= 0) Console.Write("Введите положительное число");
                else break;
            }
            while (true)
            {
                Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд:");
                num = Math.Abs(CustomInput.ReadOnlyNumber());
                if (num > n) Console.Write("Вычеркивание невозможно, т.к. число больше N");
                else break;
            }

            List<int> humans = new();
            
            for (int i = 1; i <= n; i++) humans.Add(i);  
            
            int raund = 0;
           
            while (humans.Count >= num - 1)
            {
                
                Console.Write($"Raund №{raund++}: Людей осталось: {humans.Count}\tСписок: [ ");

                List<int> forRemove = new(); //сюда попадают элементы, которые нужно удалить из основного листа
                //это нужно потому что удалять элементы из листа в процессе обхода енумератором нельзя, но запомнить их и удалить потом - пжлст

                IEnumerator<int> humansEnumerator = humans.GetEnumerator();
                int i = 1;

                while (humansEnumerator.MoveNext())
                {
                    var item = humansEnumerator.Current;
                    if (i++ % num == 0) forRemove.Add(item);   
                    Console.Write(item + " ");         
                }
                Console.WriteLine("]");
                
                if (humans.Count == num - 1) { Console.WriteLine("Далее вычеркивание невозможно"); break; } 
                humans.RemoveAll(x => forRemove.Contains(x));
                
            }
        }
    }



}