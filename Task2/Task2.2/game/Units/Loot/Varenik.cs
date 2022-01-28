using CustomLib;
using game.Interfaces;

namespace game
{
    class Varenik : Loot, IContactable
    {
        public Varenik(string filling, Point pos) : base(filling, pos) { }
        public override string ToString()
        {
            return $"Вареник с начинкой {Filling}";
        }
        public override char GetSkin()
        {
            return '&';
        }
        public override void ContactWithCharacter(Character c)
        {
            c.TakeLoot(this);
            Field.DeleteUnit(this);
        }
    }
}