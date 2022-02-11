using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime.PizzeriaPrj
{
    public class Client
    {
        string name;
        Order order;

        
        public Client(string name, Order order)
        {
            this.name = name;
            this.order = order;
            order.OnReady += TakeOrder;
        }

        public void TakeOrder()
        {
            order.status = "получен";
            Console.WriteLine($"\n========{name}: я получил заказ {order.ToString()}");
        }


    }
}
