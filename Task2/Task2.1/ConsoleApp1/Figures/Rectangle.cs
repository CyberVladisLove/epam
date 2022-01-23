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
            if (start.Equals(diagonalPoint)) Program.ThrowException(this, "совпадение точек");
            if (start.X == diagonalPoint.X || start.Y == diagonalPoint.Y)
            {
                Program.ThrowException(this, "наклонные прямоугольники в данной версии приложения не поддерживаются");
            }
            else this.diagonalPoint = diagonalPoint;
            
        }

        public override Point Start
        {
            get => start;    
        }
        public Point DiagonalPoint
        {
            get => diagonalPoint;
            set
            {
                if (Start.Equals(DiagonalPoint)) Program.ThrowException(this, "совпадение точек");
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
        public override double Area
        {
            get => Width * Height;
        }
        public override double Length
        {
            get => 2 * (Width + Height);
        }

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
