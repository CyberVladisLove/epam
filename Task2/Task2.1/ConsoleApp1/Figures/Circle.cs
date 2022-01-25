using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Circle : Figure
    {
        protected double r;
        public Circle(Point start, double r) : base(start)
        {
            if (r < 0) Program.ThrowException(this, "радиус не должен быть отрицательным");
            else this.r = r;
        }

        public override Point Start
        {
            get => start;     
        }
        public double R
        {
            get => r;
            set 
            {
                if (r < 0) Program.ThrowException(this, "радиус не должен быть отрицательным");
                else r = value;
            }
        }
        public override double Area
        {
            get => Math.PI * r * r;
        }
        public override double Length
        {
            get => 2 * Math.PI * r;
        }

        public override string DrawMe()
        {
            return ToString();
        }
        public override string ToString()
        {
            return $"Circle - center in {start}; radius: {r}; area: {Math.Round(Area, 2)}; length: {Math.Round(Length, 2)}";
        }
    }
}
