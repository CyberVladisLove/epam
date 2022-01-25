using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomLib;
namespace OOP
{
    class Program
    {
        private static Canvas canvas = new(new());

        static void Main(string[] args)
        {
            #region        
            //CustomString cs = new CustomString("ss");
            //CustomString cs1 = new CustomString("sas");

            //CustomString str = cs + cs1;
            //Console.WriteLine(cs == cs1);
            #endregion

            bool isOpen = true;
            while (isOpen)
            {
                Console.Write(
                    "===Выберите действие===\n" +
                    "1. Add figure\n" +
                    "2. Print figures\n" +
                    "3. Clear canvas\n" +
                    "4. Close app\n" +
                    "Ввод:"
                    );

                int val = ReadOnlyNumber(1, 4);
                Console.WriteLine();
                switch (val)
                {
                    case 1:
                        AddFigure();
                        break;
                    case 2:
                        canvas.Print();
                        break;
                    case 3:
                        canvas.Clear();
                        break;
                    case 4:
                        isOpen = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void AddFigure()
        {

            Console.Write(
                "===Выберите тип фигуры===\n" +
                "1. Point\n" +
                "2. Line\n" +
                "3. Circle\n" +
                "4. Ring\n" +
                "5. Rectangle\n" +
                "6. Triangle\n" +
                "Ввод:"
                );
            int val = ReadOnlyNumber(1, 6);
            Console.WriteLine();

            try
            {
                switch (val)
                {
                    case 1:
                        Console.WriteLine("======Point======");
                        canvas.AddDrawings(InputNewPoint());
                        break;
                    case 2:
                        Console.WriteLine("======Line======");
                        Console.WriteLine("---point #1---");
                        Point p1 = InputNewPoint();
                        Console.WriteLine("---point #2---");
                        Point p2 = InputNewPoint();
                    
                        Line line = new(p1, p2);
                        canvas.AddDrawings(line); 
                        break;
                    case 3:
                        Console.WriteLine("======Cirlce======");
                        Console.WriteLine("---center---");
                        Point p = InputNewPoint();
                        Console.Write("---raduis---\nr=");
                        int r = ReadOnlyNumber();
                        
                        Circle circle = new(p, r);
                        canvas.AddDrawings(circle);    
                        break;
                    case 4:
                        Console.WriteLine("======Ring======");
                        Console.WriteLine("---center---");
                        Point point = InputNewPoint();
                        Console.Write("---big-raduis---\nR=");
                        int radius = ReadOnlyNumber();
                        Console.Write("---little-raduis---\nr=");
                        int little_radius = ReadOnlyNumber();
                       
                        Ring ring = new(point, radius, little_radius);
                        canvas.AddDrawings(ring);   
                        break;
                    case 5:
                        Console.WriteLine("======Rectangle======");
                        Console.WriteLine("---point #1---");
                        Point point1 = InputNewPoint();
                        Console.WriteLine("---point #2 (диагонально противоположная к point #1)---");
                        Point point2 = InputNewPoint();
                    
                        Rectangle rect = new(point1, point2);
                        canvas.AddDrawings(rect);                      
                        break;
                    case 6:
                        Console.WriteLine("======Triangle======");
                        Console.WriteLine("---point #1---");
                        Point a = InputNewPoint();
                        Console.WriteLine("---point #2---");
                        Point b = InputNewPoint();
                        Console.WriteLine("---point #3---");
                        Point c = InputNewPoint();
                    
                        Triangle triangle = new(a, b, c);
                        canvas.AddDrawings(triangle);                  
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    $"\n{e.Message}\n" +
                    $"Фигура не была создана :(");
            }
            Console.WriteLine();
        }
        public static void ThrowException(Figure fig, string message)
        {
            string nameSp = typeof(Program).Namespace;

            //получаю тип сущности и обрезаю название namespace, чтобы например вместо OOP.Entity выводилось просто Entity
            string typeFigure = fig.GetType().ToString().Replace(nameSp + ".", ""); 
            throw new Exception($"Ошибка: {message} в фигуре {typeFigure}");
        }
        static int ReadOnlyNumber()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int res)) return res;
                else Console.WriteLine("Введите пожалуйста целое число");
            }

        }

        //ввод чисел строго в диапазоне включительно a и b
        static int ReadOnlyNumber(int a, int b)
        {
            while (true)
            {
                int res = ReadOnlyNumber();
                if (res>=a && res<=b) return res;
                else Console.WriteLine($"Введите пожалуйста целое число в диапазоне {a} - {b}");       
            }

        }
        static Point InputNewPoint()
        {
            Console.Write("Введите координаты точки:\nx=");
            int x = ReadOnlyNumber();
            Console.Write("y=");
            int y = ReadOnlyNumber();
            return new Point(x, y);
        }
    }
    
    
}
