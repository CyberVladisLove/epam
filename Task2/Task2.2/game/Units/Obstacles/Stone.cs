using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomLib;

namespace game.Units.Obstacles
{
    class Stone : Obstacle
    {
        public Stone(Point pos) : base(pos)
        {

        }
        public override char GetSkin()
        {
            return '#';
        }

        public override void Stop()
        {
            
        }
    }
}
