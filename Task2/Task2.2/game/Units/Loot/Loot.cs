using CustomLib;
namespace game
{
    abstract class Loot : Unit
    {
        //начинка
        private string _filling;
        public Loot(string filling, Point pos) : base(pos)
        {
            _filling = filling;
        }
        public string Filling
        {
            get { return _filling; }
            set { _filling = value; }
        }
        public abstract void ContactWithCharacter(Character c);
        

        
    }
}
