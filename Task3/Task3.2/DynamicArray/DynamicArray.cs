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

        private T[] _value;
        private int _count = 0;

        public DynamicArray()
        {
            _value = new T[8];
        }
        public DynamicArray(int capacity)
        {
            _value = new T[capacity];
        }
        public DynamicArray(IEnumerable<T> collection)
        {
            _count = collection.Count();
            
            if (_count <= 4) _value = new T[4];
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
            set
            {  
                if (value <= 4) Recreate(4);
                else Recreate(value);
            }
        } 
        public int Count => _count;
        
        public T this[int index]
        {

            get 
            {
                if (Math.Abs(index) >= Capacity)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (index < 0) return _value[_count + index];//доступ через отрицательный индекс
                else return _value[index];
            }
            set 
            {
                if (Math.Abs(index) >= Capacity)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else _value[index] = value;
            }
            
        }
        
        public void Add(T elem)
        {
            if (Count == Capacity) Recreate(CalculateCapacity(Count + 1));
            
            _value[_count++] = elem;
            
        }
        public void AddRange(IEnumerable<T> collection)
        {
            if (Count + collection.Count() > Capacity) 
            { 
                int newCapacity = CalculateCapacity(Count + collection.Count());
                Recreate(newCapacity);
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
                    Recreate(Capacity, i);
                    _count--;
                    return true;
                }
            }
            
            return false;
        }
        public bool Insert(int index, T elem)
        {
            if (index < 0 || index > Capacity)
            {
                throw new ArgumentOutOfRangeException();         
            }
           _count++;
           Recreate(CalculateCapacity(_count), index, elem);

            return true;
            
        }

        //определяет нужный размер capacity в зависимости от count, путем удвоения capacity 
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
        //пересоздает массив с новым capacity и копирует элементы из старого в новый 
        protected void Recreate(int capacity)
        {
            
            var newValue = new T[capacity];
            if (capacity < Count) _count = capacity;

            for (int i = 0; i < Count; i++)
            {
                newValue[i] = _value[i];
            }
            _value = newValue;
        }
        protected void Recreate(int capacity, int IndexOfRemoveElem)
        {
            var newValue = new T[capacity];

            for (int i = 0, j = 0; i < Count; i++)
            {
                if (i == IndexOfRemoveElem) continue;
                newValue[j++] = _value[i];
                
            }
            _value = newValue;
        }
        protected void Recreate(int capacity, int IndexOfInsertElem, T elem)
        {
            var newValue = new T[capacity];

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
        //protected void Recreate(int capacity, Func<T[], T[]> action)
        //{
        //    var newValue = new T[capacity];


        //    for (int i = 0; i < Count; i++)
        //    {
        //        newValue[i] = _value[i];
        //    }
        //    _value = action(newValue);
        //}
        

        public virtual IEnumerator<T> GetEnumerator()
        {
            foreach (var elem in _value) yield return elem;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var elem in _value) yield return elem;
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
            sb.Append(this[0]);
            for (int i = 1; i < Count; i++)
            {
                sb.Append(',').Append(_value[i]);
            }
            return sb.ToString();
        }
    }
}
