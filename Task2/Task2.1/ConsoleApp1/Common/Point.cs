using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Point : IDrawable, ICloneable
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public bool Equals(Point point)
        {
            if (X == point.X && Y == point.Y) return true;
            return false;
        }
        public string DrawMe()
        {
            return $"Point[{X}, {Y}]";
        }
        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
        public static double DistanceBetween(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
