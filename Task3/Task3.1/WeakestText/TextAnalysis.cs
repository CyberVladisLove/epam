using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakestText
{
    class TextAnalysis
    {
        public static void Run()
        {
            Console.WriteLine("\n===3.1.2_TextAnalysis===");
            Console.WriteLine("Input text: ");
            string text = Console.ReadLine();
            //"Hello Hello hello Hello my My My friend. my friend friend what are you doing you";
            char[] separators = new char[] { ' ', '.', ',', '!', '?', '"', ';', ':' };

            var wordCount = text.ToLower()
                                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                                .GroupBy(x => x)
                                .OrderByDescending(x => x.Count())
                                .ToDictionary(x => x.Key, x => x.Count());

            Console.WriteLine("\n===Список слов===");

            foreach (var w in wordCount)
                Console.WriteLine($"{w.Key}: {w.Value}");
                      
            Console.WriteLine("\n===Вердикт анализа===");

            if (wordCount.First().Value == wordCount.Last().Value)//когда все слова использованы равное число раз
                Console.WriteLine($"Каждое слово использовано в количестве {wordCount.First().Value}");
            
            else
            {
                Console.WriteLine("Наиболее часто использованные слова:");
                foreach (var w in wordCount)
                {
                    //когда в топе несколько слов с равной частотой использования, они все будут выведены
                    if (w.Value < wordCount.First().Value) break;
                    else Console.WriteLine($"{w.Key}: {w.Value}");
                }
                Console.WriteLine("Постарайтесь заменить их синонимами");
            }
        }    
    }
}
