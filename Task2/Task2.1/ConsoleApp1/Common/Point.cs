using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Point : IDrawable
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public bool Equals(Point point)
        {
            if (X == point.X && Y == point.Y) return true;
            return false;
        }
        public string DrawMe()
        {
            return $"Point[{x}, {y}]";
        }
        public override string ToString()
        {
            return $"[{x}, {y}]";
        }
        public static double DistanceBetween(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
    }
}
