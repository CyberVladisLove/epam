using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime.PizzeriaPrj
{
    public class Pizza
    {
        string name;

        public Pizza(string name)
        {
            this.name = name;
        }
        public override string ToString() => name;
        
    }
}
