using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)

        {
            averages();           //2.1
            doubler();            //2.2
            lowercase();          //2.3
            validator();          //2.4
        }

        static void averages()          //2.1
        {
            Console.WriteLine("===2.1=== ");
            Console.WriteLine("Input str: ");
            String str = Convert.ToString(Console.ReadLine());
            char[] separators = new char[] { ' ', '.', ',', '-', '!', '?', '"', ';', ':' };
            string[] words = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            double aveLength = 0;//решил оставить результат дробным

            for (int i = 0; i < words.Length; i++)
            {

                aveLength += words[i].Length;
            }

            aveLength /= words.Length;
            Console.WriteLine($"Average length: {Math.Round(aveLength, 2)}");
        }
        static void doubler()           //2.2
        {
            Console.WriteLine("===2.2=== ");
            Console.WriteLine("Input str1: ");
            String str1 = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Input str2: ");
            String str2 = Convert.ToString(Console.ReadLine());

            StringBuilder res = new StringBuilder();

            foreach (var ch in str1)
            {
                if (str2.Contains(ch))
                {
                    res.Append(String.Concat(ch, ch));
                }
                else res.Append(ch);
            }

            Console.WriteLine("res: " + res);
        }
        static void lowercase()         //2.3
        {
            Console.WriteLine("===2.3=== ");
            Console.WriteLine("Input str1: ");
            string str1 = Convert.ToString(Console.ReadLine());
            char[] separators = new char[] { ' ', '.', ',', '-', '!', '?', '"', ';', ':' };
            string[] words = str1.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int count = 0;

            foreach (var ch in words)
            {
                if (char.IsLower(ch[0]))
                {
                    count++;
                }
            }

            Console.WriteLine("count of lowercase words: " + count);
        }
        static void validator()         //2.4
        {
            Console.WriteLine("===2.4=== ");
            Console.WriteLine("Input str: ");
            string str = Convert.ToString(Console.ReadLine());
            char[] separators = new char[] { '.', '!', '?' };


            char nullChar = (char)0;
            foreach (var sep in separators)
            {
                if (str.Contains(sep))
                {
                    str = str.Replace($"{sep}", $"{sep}{nullChar}"); //ставлю нулевой символ рядом с разделителями
                                                                     //чтобы потом по этому нулевому символы разделить строку на предложения
                                                                     //это нужно для сохранения знаков разделителей (. ? !)
                }
            }

            string[] sentences = str.Split(nullChar, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < sentences.Length; i++)//обрезаю все пробелы в начале и коцне каждого предложения
            {
                sentences[i] = sentences[i].Trim(' ');
            }


            StringBuilder res = new StringBuilder();

            for (int i = 0; i < sentences.Length; i++)
            {
                if (char.IsLower(sentences[i][0]))
                {
                    string tmp = Char.ToUpper(sentences[i][0]) + sentences[i].Substring(1) + " ";
                    res.Append(tmp);
                }
                else res.Append(sentences[i] + " ");

            }
            Console.WriteLine(res);
        }
    }
}
