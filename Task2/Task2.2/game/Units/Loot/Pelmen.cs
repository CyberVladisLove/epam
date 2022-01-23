using CustomLib;
using game.Interfaces;

namespace game
{
    class Pelmen : Loot, IContactable
    { 
        public Pelmen(string filling, Point pos) : base(filling, pos) { }
        public override string ToString()
        {
            return $"Пельмень с начинкой {Filling}";
        }
        public override char GetSkin()
        {
            return '@';
        }

        public override void ContactWithCharacter(Character c)
        {
            c.TakeLoot(this);
            Field.DeleteUnit(this);
        }
    }
}