using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Ring : Circle
    {
        protected double r_little;
        public Ring(Point start, double r, double r_little) : base(start, r)
        {
            if (r_little < 0 || r_little >= r) 
            {
                throw new ArgumentOutOfRangeException($"внутренний радиус должен быть не отрицательным и меньше внешнего в фигуре {GetType()}");
            } 
           
            else this.r_little = r_little;

        }
        public double R_little
        {
            get => r_little;
            set 
            {
                if (value >= r || value < 0)
                {
                    throw new ArgumentOutOfRangeException($"внутренний радиус должен быть не отрицательным и меньше внешнего в фигуре {GetType()}");
                }

                else r_little = value;
            } 
        }

        public override double Area
        {
            get => Math.PI * (r * r - r_little * r_little);
        }
        public override double Length
        {
            get => 2 * Math.PI * (r + r_little);
        }

        public override string DrawMe()
        {
            return ToString();
        }
        
        public override string ToString()
        {
            return $"Ring: center in {start}; big radius: {r}; little radius: {r_little}; area: {Math.Round(Area, 2)}; length: {Math.Round(Length, 2)}";
        }
    }
}
