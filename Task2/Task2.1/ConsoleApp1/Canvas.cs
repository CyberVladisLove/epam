using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Canvas
    {
        private List<IDrawable> drawings = new();

        public Canvas(List<IDrawable> drawings)
        {
            this.drawings = new List<IDrawable>(drawings);
        }
        public void AddDrawings(params IDrawable[] drawings)
        {
            this.drawings.AddRange(drawings);
            Console.WriteLine("---Фигура-добавлена---");
        }

        public void Clear()
        {
            drawings.Clear();
        }
        public void Print()
        {
            
            Console.WriteLine("\n==========canvas==========");
            if (drawings.Count == 0) Console.WriteLine("Холст пустой");
            int i=1;
            foreach (IDrawable d in drawings)
            {
                Console.WriteLine($"{i++}) {d.DrawMe()}");
               
            }
            Console.WriteLine("========end-canvas========\n");    
        }
    }
}
