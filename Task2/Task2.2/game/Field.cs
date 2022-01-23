using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CustomLib;
using game.Interfaces;
using game.Units.Enemies;
using game.Units.Obstacles;

namespace game
{
    static class Field
    {
        private static List<Unit> _units = new();

        private static CustomString[] _map =
        {
            new("╔══════════════════════╗"),
            new("║                      ║"),
            new("║                      ║"),
            new("║                      ║"),
            new("║                      ║"),
            new("║                      ║"),
            new("║                      ║"),
            new("║                      ║"),
            new("║                      ║"),
            new("║                      ║"),
            new("║                      ║"),
            new("║                      ║"),
            new("╚══════════════════════╝")
        };
        public static int Width
        {
            get{return _map[0].Length;}
        }
        public static int Height
        {
            get { return _map.Length; }
        }

        public static void AddUnits(params Unit[] units)
        {
            Field._units.AddRange(units);
        }
        public static void DeleteUnit(Unit unit)
        {
            Field._units.Remove(unit);
            EditMap(unit.Position.X, unit.Position.Y,' ');
        }
        public static bool LootIsOver()
        {
            foreach (var unit in _units)
            {
                if (unit is Loot)
                {
                    return false;
                }
                
            }
            return true;
        }

        public static void RenderUnits()
        {
            foreach(var unit in _units)
            {
                int x = unit.Position.X;
                int y = unit.Position.Y;
                _map[y][x] = unit.GetSkin();
            }
        }
        public static void EditMap(int x, int y, char val)
        {
            _map[y][x] = val;       
        }
        public static void RenderMap()
        {
            foreach (var str in _map)
            {
                Console.WriteLine(str);
            }
        }
        public static void CheckCollision(Character c, Point nextPosition)
        {
            int xNext = nextPosition.X;
            int yNext = nextPosition.Y;
            if (xNext > 0 && xNext < Width-1 && yNext > 0 && yNext < Height - 1)
            {
                for (int i = 0; i < _units.Count; i++)
                {
                    if (_units[i].Position == nextPosition)
                    {
                        if (_units[i] is IContactable)
                        {   
                            IContactable unitIC = _units[i] as IContactable;
                            unitIC.ContactWithCharacter(c);
                        }                      
                        if (_units[i] is IStopable) return;
                    }                   
                }
                int x = c.Position.X;
                int y = c.Position.Y;
                EditMap(x, y, ' ');
                c.MoveTo(nextPosition);
            }
        }
        public static void EnemiesController(Character c)
        {
            for (int i = 0; i < _units.Count; i++)
            {
                if (_units[i] is Wolf)
                {
                    Wolf wolf = _units[i] as Wolf;
                    Random rnd = new();
                    int val1 = rnd.Next(-1,2);
                    int val2 = rnd.Next(-1,2);
                    Point now = wolf.Position;
                    Point next = new(now.X + val1, now.Y + val2);
                    for (int j = 0; j < _units.Count; j++)
                    {
                        if (_units[j] is Obstacle && next == _units[j].Position) return;        
                    }
                    if (next.X > 0 && next.X < Width - 1 && next.Y > 0 && next.Y < Height - 1)
                    {
                        wolf.MoveTo(next);
                        EditMap(now.X, now.Y, ' ');
                        if (wolf.Position == c.Position) wolf.ContactWithCharacter(c);
                    }
                }  
            }

        }

    }
}
