using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomLib;
namespace game
{
    public abstract class Unit
    {
        protected Point position;
        public Unit(Point position)
        {
            this.position = position;
        }
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
        abstract public char GetSkin();
        

    }
}
