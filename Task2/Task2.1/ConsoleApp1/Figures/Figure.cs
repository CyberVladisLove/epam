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
