using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    //каждая фигура и точка - рисуемые объекты, реализуют интерфейс для того чтобы передать их всех по интерфейсной ссылке в холст
    interface IDrawable
    {
        public string DrawMe();
    }
}
