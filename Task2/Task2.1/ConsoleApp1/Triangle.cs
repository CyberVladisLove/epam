using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Triangle : Figure
    {
        protected Point p2;
        protected Point p3;

        public Triangle(Point p1, Point p2, Point p3) : base(p1)
        {
            if (p1.Equals(p2) || p1.Equals(p3) || p2.Equals(p3)) Program.ThrowException(this,"совпадение точек");
            
            else
            {
                this.p2 = p2;
                this.p3 = p3;
            }
            
        }

        public override Point Start
        {
            get => start;      
        }
        
        //стороны треугольника
        public double A
        {
            get 
            {
                Point p1 = Start;
                return Point.DistanceBetween(p1, p2);
            }
        }
        public double B
        {
            get
            {
                Point p1 = Start;
                return Point.DistanceBetween(p1, p3);
            }
        }
        public double C
        {
            get
            {
                return Point.DistanceBetween(p2, p3);
            }
        }

        public override double Area
        {
            
            get {
                double p = Length / 2;
                double s = Math.Sqrt(p*(p - A)* (p - B)* (p - C));          
                return s;
            }
             
        }
        public override double Length
        {
            get
            {
                return A + B + C;
            }
        }

        public override string DrawMe()
        {
            return ToString();
        }
        
        public override string ToString()
        {
            return $"Triangle - points: {start} {p2} {p3}; area: {Math.Round(Area, 2)}; length: {Math.Round(Length, 2)}";
        }
    }
}
