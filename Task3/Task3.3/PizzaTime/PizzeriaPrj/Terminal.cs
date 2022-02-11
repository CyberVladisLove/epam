using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomLib;

namespace PizzaTime.PizzeriaPrj
{
    public class Terminal//то, через что осуществляется заказ(не имеет отношение непосредствено к пиццерии)
    {
        static Pizzeria pz = new();
        public static void Run()
        {
            Console.WriteLine("\n===3.3.3_Pizzeria===");
            bool isOpenApp = true;
            int numOrder = 1;
            while (isOpenApp)
            {
                
                Console.WriteLine("Input ur name: ");
                string name = Console.ReadLine();
                List<Pizza> orderList = new();
                bool isOpenTerminal = true;
                while (isOpenTerminal)
                {
                    Console.Write(
                    "===Выберите пиццу===\n" +
                    "1. Мясная\n" +
                    "2. Пепперони\n" +
                    "3. Сырная\n" +
                    "4. Мексиканская\n" +
                    "0. Завершить выбор и сделать заказ\n" + 
                    "Ввод:"
                    );
                    int val = CustomInput.ReadOnlyNumber(0, 4);
                    switch (val)
                    {
                    case 1:
                        orderList.Add(new Pizza("Мясная"));
                        break;
                    case 2:
                        orderList.Add(new Pizza("Пепперони"));
                        break;
                    case 3:
                        orderList.Add(new Pizza("Сырная"));
                        break;
                    case 4:
                        orderList.Add(new Pizza("Мексиканская"));
                        break;
                    case 0:
                        if (orderList.Count > 0)
                            isOpenTerminal = false;
                        break;
                    }
                }               
                Order order = new Order(numOrder++, orderList);
                Client cl = new(name, order);
                pz.AddOrder(order);
                pz.Cooking();

            }
        }
    }
}
