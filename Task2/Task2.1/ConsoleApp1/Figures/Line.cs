using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Line : Figure
    {
        protected Point finish;

        public Line(Point start, Point finish) : base(start)
        {
            if (start.Equals(finish)) Program.ThrowException(this, "совпадение точек");
            else this.finish = finish;
        }
        public override Point Start
        {
            get => start;     
        }
        public Point Finish
        {
            get => finish;
            set
            {
                if (Start.Equals(value)) Program.ThrowException(this, "совпадение точек");
                else finish = value;
            }
        }
        public override double Area
        {
            get => 0;
        }
        public override double Length
        {
            get => Math.Sqrt(Math.Pow((finish.X - start.X),2) + Math.Pow((finish.Y - start.Y), 2));
        }

        public override string DrawMe()
        {
            return ToString();
        }
        
        public override string ToString()
        {
            return $"Line: start{start} finish{finish}; length: {Math.Round(Length, 2)}";
        }
    }
}
