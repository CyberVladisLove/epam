using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Common
{
    public class CustomString
    {
        private char[] _charArr;
        public CustomString() : this(Array.Empty<char>()) { }
        public CustomString(string str) : this(str.ToCharArray()) { }
        public CustomString(char[] _charArr)
        {
            this._charArr = _charArr;
        }
        public char[] CharArr
        {
            get
            {
                return _charArr;
            }
            set
            {
                _charArr = value;
            }
        }
        public int Length
        {
            get { return _charArr.Length; }
        }

        //indexer
        public char this[int index]
        {
            get => CharArr[index];
            set => CharArr[index] = value;
        }

        //Equals
        #region 
        public bool Equals(char[] _charArr)
        {
            return Equals(new CustomString(_charArr));
        }
        public bool Equals(string str)
        {
            return Equals(new CustomString(str));
        }
        public bool Equals(CustomString customStr)
        {
            if (Length != customStr.Length) return false;


            for (int i = 0; i < Length; i++)
            {
                if (this[i] != customStr[i]) return false;
            }

            return true;
        }
        public override bool Equals(object? obj)
        {
            return obj is CustomString cs && Equals(cs);

        }
        public static bool operator ==(CustomString customStr1, CustomString customStr2)
        {
            return customStr1.Equals(customStr2);
        }
        public static bool operator !=(CustomString customStr1, CustomString customStr2)
        {
            return !(customStr1 == customStr2);
        }
        #endregion
        public override int GetHashCode()
        {
            return HashCode.Combine(_charArr);
        }
        //Contains
        #region
        public bool Contains(char ch)
        {
            return Contains(new CustomString(new char[] { ch }));
        }
        public bool Contains(char[] _charArr)
        {
            return Contains(new CustomString(_charArr));
        }
        public bool Contains(string str)
        {
            return Contains(new CustomString(str));
        }
        public bool Contains(CustomString customStr)
        {

            if (Length < customStr.Length) return false;

            for (int i = 0; i <= Length - customStr.Length; i++)
            {
                int j;
                for (j = 0; j < customStr.Length; j++)
                {
                    if (this[i + j] != customStr[j]) break;
                }
                if (j == customStr.Length) return true;

            }
            return false;
        }
        #endregion

        //Concat
        #region
        public CustomString Concat(string str)
        {
            return this + new CustomString(str);
        }
        public CustomString Concat(CustomString customStr)
        {
            return this + customStr;
        }
        public static CustomString operator +(CustomString customStr1, CustomString customStr2)
        {
            char[] _charArr = new char[customStr1.Length + customStr2.Length];
            CustomString res = new(_charArr);
            for (int i = 0; i < customStr1.Length; i++)
            {
                res[i] = customStr1[i];
            }
            for (int i = customStr1.Length; i < res.Length; i++)
            {
                res[i] = customStr2[i - customStr1.Length];
            }

            return res;
        }
        #endregion

        public int IndexOf(char ch)//ищет индекс первого вхождения символа
        {
            if (!Contains(ch)) return -1;

            for (int i = 0; i < Length; i++)
            {
                if (this[i] == ch) return i;
            }
            return -1;

        }

        public char[] ToCharArray()
        {
            return _charArr;
        }


        //методы, которые бы я добавил:
        #region

        //у строк в .NET я не нашел метод Reverse, реверс обычно приходится делать через Array
        public CustomString Reverse()
        {
            char[] chArr = new char[Length];
            for (int i = 0; i < Length; i++)
            {
                chArr[i] = this[Length - i - 1];
            }
            return new CustomString(chArr);

        }

        //считает сколько раз встречается каждый символ и возвращает результат, отсортированный по алфавиту 
        public Dictionary<char, int> GetCountOfEachChar()
        {
            var result = ToString()
                        .GroupBy(ch => ch)
                        .OrderBy(ch => ch.Key)
                        .ToDictionary(ch => ch.Key, ch => ch.Count());

            return result;
        }

        //формирует основую информацию о строке и выводит на экран
        public void PrintInfo()
        {
            Console.WriteLine($"CustomString: {this}");
            Console.WriteLine($"Length: {Length}");
            Console.WriteLine($"HashCode: {GetHashCode()}");
            Console.WriteLine("Count of each char:");
            var charCount = GetCountOfEachChar();

            foreach (var ch in charCount)
            {
                Console.WriteLine($"{ch.Key} - {ch.Value}");
            }

        }
        #endregion

        public override string ToString()
        {
            if (Length == 0) return "";
            StringBuilder sb = new();
            foreach (char ch in _charArr) sb.Append(ch);

            return sb.ToString();
        }


    }
}
