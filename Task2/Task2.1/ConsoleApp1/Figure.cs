using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    abstract class Figure : IDrawable
    {
        protected Point start;
        protected bool isAdequate;//собственно поле, которое дает понять, может ли существовать прямоугольник который точка или нет(у которого все точки одинаковые)
        //false - фигура курильщика (может иметь хоть все одинаковые точки)
        //true - адекватная фигура (программа не дает создать упоротую фигуру)
        public Figure(Point start)
        {
            this.start = start;
        }
        abstract public Point Start { get;}
        abstract public double Area { get; }
        abstract public double Length { get; }


        abstract public string DrawMe();
        

    }

    
    
}
