using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public static class DynamicArrayExtensions
    {
        //работает если установить Newtonsoft.Json;
        //расширение позволяет нормально клонировать DynamicArray, чтобы массив нового объекта не имел ссылки на элементы массива в старом объекте
        public static DynamicArray<T> UltraClone<T>(this DynamicArray<T> obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<DynamicArray<T>>(json);
        }
    }
}
