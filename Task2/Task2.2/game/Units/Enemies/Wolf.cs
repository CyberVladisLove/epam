using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CustomLib;
using game.Interfaces;

namespace game.Units.Enemies
{
    class Wolf : Unit, Moveable,IContactable
    {
        public Wolf(Point pos) : base(pos)
        {    
        }
        public override char GetSkin()
        {
            return 'w';
        }

        public void MoveTo(Point pos)
        {
            Position = pos;
        }
        public void ContactWithCharacter(Character c)
        { 
            c.Die();
            Console.WriteLine($"\n{c.Name} радостно пополнил инвентарь волка");
            Thread.Sleep(2000);

        }
    }
}
