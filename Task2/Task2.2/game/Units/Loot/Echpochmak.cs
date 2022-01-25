using CustomLib;
using game.Interfaces;

namespace game
{
    class Echpochmak : Loot, IContactable
    {
        public Echpochmak(string filling, Point pos) : base(filling, pos) { }
        public override string ToString()
        {
            return $"Эчпочмак с начинкой {Filling}";
        }
        public override char GetSkin()
        {
            return '%';
        }
        public override void ContactWithCharacter(Character c)
        {
            c.TakeLoot(this);
            Field.DeleteUnit(this);
        }
    }
}