using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime.PizzeriaPrj
{
    public class Order
    {
        public event Action OnReady = delegate { };

        
        public int num;
        List<Pizza> composition = new();
        public string status = "в процессе";

        public Order(int num, List<Pizza> composition)
        {
            
            this.num = num;    
            this.composition = new(composition);
        }

        public void Ready()
        {
            status = "готов";
            
            OnReady();
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach(var item in composition)
            {
                sb.Append(item).Append(" ");
            }
            return $"{num}, его состав: {sb}";
        }
    }
}
