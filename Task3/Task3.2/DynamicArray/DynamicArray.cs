using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>, ICloneable
    {

        private T[] _value = new T[8];
        private int _count = 0;

        public DynamicArray() { }
        
        public DynamicArray(int capacity)
        {
            _value = new T[capacity];
        }
        public DynamicArray(IEnumerable<T> collection)
        {
            _count = collection.Count();
            
            if (_count <= 4) _value = new T[4];//как в листах мин значение поставил 4
            else _value = new T[CalculateCapacity(_count)];
                      
            int i = 0;
            foreach (var elem in collection)
            {
                _value[i++] = elem;
            }
        }

        public int Capacity
        {
            get => _value.Length;
                
            

            //принудительная установка Capacity
            set
            {  
                if (value <= 4) ReCopy(4);
                else ReCopy(value);
            }
        } 
        public int Count => _count; //назвал Count своим именем,тк нагляднее чем Length как в задании))
        
        public T this[int index]
        {

            get 
            {
                if (Math.Abs(index) >= Count) //проверка на выход за границы Count, модуль позволяет учитывать отрицательный индекс 
                    throw new ArgumentOutOfRangeException();
                
                else if (index < 0) return _value[_count + index]; //доступ через отрицательный индекс
                else return _value[index];
            }
            set 
            {
                if (Math.Abs(index) >= Count+1)
                    throw new ArgumentOutOfRangeException();
                
                else _value[index] = value;
            }
            
        }
        
        public void Add(T elem)
        {
            if (Count == Capacity) ReCopy(CalculateCapacity(Count + 1));
            
            _value[_count++] = elem;
            
        }
        public void AddRange(IEnumerable<T> collection)
        {
            if (Count + collection.Count() > Capacity) 
            { 
                int newCapacity = CalculateCapacity(Count + collection.Count());
                ReCopy(newCapacity);
            } 
  
            foreach (var elem in collection)
            {
                _value[_count++] = elem;
            }
        }
        public bool Remove(T elem)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_value[i].Equals(elem))
                {
                    ReCopy(Capacity, i);
                    _count--;
                    return true;
                }
            }
            
            return false;
        }
        public bool Insert(int index, T elem)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();         
            }
           _count++;
            ReCopy(CalculateCapacity(_count), index, elem);

            return true;
            
        }

        //определяет нужный размер capacity в зависимости от count, путем удвоения текущего capacity 
        protected int CalculateCapacity(int count)
        {
            if (Capacity > count) return Capacity;
            int newCapacity = Capacity;
            while (true)
            {
                newCapacity *= 2;
                if (newCapacity >= count) return newCapacity;
            }
        }
        //пересоздает массив с новым capacity 
        protected T[] ReCreate(int capacity)
        {
            if (capacity < Count) _count = capacity;
            return new T[capacity];
        }

        
        //перекопирует элементы
        protected void ReCopy(int capacity)
        {
            T[] newValue = ReCreate(capacity);

            for (int i = 0; i < Count; i++)
                newValue[i] = _value[i];

            _value = newValue;
        }
        //перекопирует и вставляет один элемент
        protected void ReCopy(int capacity, int IndexOfRemoveElem)
        {
            T[] newValue = ReCreate(capacity);
            
            for (int i = 0, j = 0; i < Count; i++)
            {
                if (i == IndexOfRemoveElem) continue;
                newValue[j++] = _value[i];
                
            }
            _value = newValue;
        }
        //перекопирует и удаляет один элемент
        protected void ReCopy(int capacity, int IndexOfInsertElem, T elem)
        {
            T[] newValue = ReCreate(capacity);
            
            for (int i = 0, j = 0; i < Count; i++, j++)
            {
                if (j == IndexOfInsertElem)
                {
                    newValue[j] = elem;
                    i--;
                }    
                else newValue[j] = _value[i];
            }
            _value = newValue;
        }
        //!вопрос! - можно и нужно ли было обойтись без перегрузки метода ReСopy, тк наблюдается частичный копипаст кода? например попытавшись сделать делегат под эти операции.
        //у меня не вышло придумать норм делегат, хотя операции перекопирования вроде бы похожи


        public virtual IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Count; i++)
                yield return this[i];  
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object Clone()
        {
            return this.UltraClone(); //смотри DynamicArrayExtensions
        }
        public T[] ToArray()
        {
            DynamicArray<T> dArr = (DynamicArray<T>) Clone();
            return dArr._value;
        }

        public override string ToString()
        {
            if (Count == 0) return "";
            StringBuilder sb = new();

            for(int i = 0; i< Count; i++)
                sb.Append(this[i]).Append(' ');
                  
            return sb.ToString();
        }
    }
}
