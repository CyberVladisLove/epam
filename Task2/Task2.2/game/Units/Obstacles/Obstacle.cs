using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomLib;
using game.Interfaces;

namespace game
{
    //препятствие (камни и тд..)
    abstract class Obstacle : Unit, IStopable
    {
        public Obstacle(Point pos) : base(pos)
        {
            
        }
        public override abstract char GetSkin();


        public abstract void Stop();
        
        
    }
}
