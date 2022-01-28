using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Rectangle : Figure
    {
        //diagonalPoint - точка, диагонально противоположная точке "start".
        //Таким образом прямоугольник у меня задается двумя диагонально противоположными точками.
        protected Point diagonalPoint;
        public Rectangle(Point start, Point diagonalPoint) : base(start)
        {
            if (start.Equals(diagonalPoint)) throw new ArgumentException($"совпадение точек в фигуре {GetType()}");
            if (start.X == diagonalPoint.X || start.Y == diagonalPoint.Y)
            {
                throw new ArgumentException("наклонные прямоугольники в данной версии приложения не поддерживаются");
            }
            else this.diagonalPoint = new Point(diagonalPoint);
            
        }

        public override Point Start
        {
            get => new Point(start);    
        }
        public Point DiagonalPoint
        {
            get => new Point(diagonalPoint);
            set
            {
                if (Start.Equals(value)) throw new ArgumentException($"совпадение точек в фигуре {GetType()}");
                else diagonalPoint = value;
            }
        }
        public int Width
        {
            get => Math.Abs(diagonalPoint.X - start.X);
        }
        public int Height
        {
            get => Math.Abs(diagonalPoint.Y - start.Y);
        }
        public Point P2
        {
            get => new Point(start.X, diagonalPoint.Y);
            
        }
        public Point P4
        {
            get => new Point(diagonalPoint.X, start.Y);
            
        }
        public override double Area => Width * Height;
        
        public override double Length => 2 * (Width + Height);
        

        public override string DrawMe()
        {
            return ToString();
        }
        
        public override string ToString()
        {
            string whoAmI = "Rectangle";
            if (Height == Width) whoAmI = "Square";
            return $"{whoAmI}: points: {start} {P2} {diagonalPoint} {P4}; area: {Area}; length: {Length}";
        }
    }
}
