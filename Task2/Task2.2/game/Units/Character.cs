using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomLib;
namespace game
{
    //персонаж игрока
    class Character : Unit, Moveable
    {
        private string _name;
        private List<Loot> _inventory = new();
        public Character(string name,Point pos) : base(pos)
        {
            _name = name;     
        }

        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        List<Loot> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public void ShowInventory()
        {
            int i = 1;
            foreach (var loot in _inventory)
            {
                Console.WriteLine($"{i++}){loot}");
            }
        }

        public void MoveTo(Point pos)
        {
            Position = pos;
        }
        public void TakeLoot(Loot loot)
        {
            Inventory.Add(loot);
        }
        public override char GetSkin()
        {
            return char.ToUpper(_name[0]);
        }
        public void Die()
        {
            Program.IsOpen = false;
        }
        
    }
}
