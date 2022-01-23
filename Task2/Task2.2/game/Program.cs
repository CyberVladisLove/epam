using System;
using System.Threading;
using System.Timers;
using CustomLib;
using game.Units.Enemies;
using game.Units.Obstacles;

namespace game
{
    public class Program
    {
        

        private static bool isOpen = true;
        public static bool IsOpen
        {
            get { return isOpen; }
            set {isOpen = value; }
        }
        
        static void Main(string[] args)
        {

            while(true)
            {
                isOpen = true;
                Console.Clear();
                Character c = Init();
                
                while (isOpen)
                {
                    if (Field.LootIsOver())
                    {
                        Console.WriteLine($"{c.Name} собрал все вкусняшки. Победа!");
                        Thread.Sleep(5000);
                        break;
                    }
                    KeyController(c);
                    Field.EnemiesController(c);
                    Render();
                    InfoOutput(c); 
                    Thread.Sleep(300);
                }

            } 

        }
        
        static void Render()
        {
            Console.Clear(); 
            Field.RenderUnits();
            Field.RenderMap();  
            
        }
        private static Character Init()
        {
            Console.WriteLine(
                "===Введите имя персонажа (рекомендуется: Floppa)===" );

            string name = Console.ReadLine();
            
            Console.WriteLine("\n===Инструкция===\n" +
                "Цель игры - собрать всю еду на карте\n" +
                "За вами охотится волк (w), он рандомно блуждает по карте\n" +
                "На карте есть препятствия - камни (#)\n" +
                "Еда помечена специальными символами\n" +
                $"{char.ToUpper(name[0])} - ваш персонаж\n" +
                "w - злой волк\n" +
                "# - камень\n" +
                "@ - пельмень\n" +     
                "% - эчпочмак\n" +
                "& - вареник\n"     
                );
            Console.WriteLine("Передвижение - wasd");
            Console.WriteLine("Совет - не зажимайте долго клавиши wasd. Одно движение - одно нажатие");
            Console.WriteLine("Нажмите Enter для начала игры");
            Console.ReadLine();

            Character c = new(name, new(4, 4));
            Wolf w = new(new(10, 10));
            
            Pelmen pelmen1 = new("говядина", new(5, 8));
            Pelmen pelmen2 = new("свинина", new(15, 7));
            Varenik varenik = new("картошка", new(21, 11));
            Echpochmak ech = new("баранина", new(10, 3));
            
            Stone st1 = new Stone(new(2, 3));
            Stone st2 = new Stone(new(3, 3));
            Stone st3 = new Stone(new(3, 2));
            Stone st4 = new Stone(new(2, 2));

            

            Stone st5 = new Stone(new(7, 8));
            Stone st6 = new Stone(new(17, 2));
            Stone st7 = new Stone(new(9, 4));
            Stone st8 = new Stone(new(10, 4));

            Field.AddUnits(c, pelmen1, pelmen2, varenik, ech, st1,st2,st3,st4,st5,st6,st7,st8,w);
            return c;
        }
        static void InfoOutput(Character c)
        {
            Console.WriteLine("Ваш инвентарь:");
            c.ShowInventory();
            Console.WriteLine("\nПодсказки:\n"+
                $"{char.ToUpper(c.Name[0])} - ваш персонаж\n" +
                "w - злой волк\n" +
                "@ - пельмень\n" +
                "% - эчпочмак\n" +
                "& - вареник\n"
                );

        }
        static void KeyController(Character c)
        {
            if (Console.KeyAvailable)
            {
                int x = c.Position.X;
                int y = c.Position.Y;
                var keyInfo = Console.ReadKey();
                switch (keyInfo.KeyChar)
                {
                    case 'a':
                        
                        Field.CheckCollision(c, new Point(x - 1, y));                             
                        break;
                    case 'd':
                        Field.CheckCollision(c, new Point(x + 1, y));                              
                        break;
                    case 'w':
                        Field.CheckCollision(c, new Point(x, y - 1));                               
                        break;
                    case 's':
                        Field.CheckCollision(c, new Point(x, y + 1));                  
                        break;
                    case 'ф':
                        goto case 'a';
                    case 'в':
                        goto case 'd';
                    case 'ц':
                        goto case 'w';
                    case 'ы':
                        goto case 's';
                }
            }
        }
        
    }
}
