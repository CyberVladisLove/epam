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
            if (start.Equals(finish)) throw new ArgumentException($"совпадение точек в фигуре {GetType()}");
            else this.finish = new Point(finish);
        }
        public override Point Start
        {
            get => new Point(start);     
        }
        public Point Finish
        {
            get => new Point(finish);
            set
            {
                if (Start.Equals(value)) throw new ArgumentException($"совпадение точек в фигуре {GetType()}");
                else finish = value;
            }
        }
        public override double Area => 0;
        
        public override double Length
        {
            get => Point.DistanceBetween(start, finish);
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
