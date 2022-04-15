using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime.PizzeriaPrj
{
    class Pizzeria
    {
        public Queue<Order> orders = new();

        public Pizzeria()
        {
        }

        public void AddOrder(Order order)
        {
            orders.Enqueue(order);
        }
        public void Cooking()
        {
            while(orders.Count > 0)
            {
                //сначала делал с помощью task, но получалось что пиццерия не может одновременно готовить несколько заказов
                //var order = orders.Dequeue();
                //var task = new Task(() => {order.Ready(); ; });
                //task.Wait(TimeSpan.FromSeconds(5));
                //task.Start();
                //await task;

                //в данном случае может готовить несколько заказов
                var t1 = new System.Threading.Timer(Issuing, orders.Dequeue(), TimeSpan.FromSeconds(7), TimeSpan.Zero);//заказ готовится 7 секунд
            }      
            
        }
        public void Issuing(Object obj)
        {
            var order = (Order)obj;
            Console.WriteLine($"\n---заказ №{order.num} готов---");
            order.Ready();
            
        }
        
    }
}
