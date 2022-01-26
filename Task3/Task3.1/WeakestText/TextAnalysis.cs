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
            Console.WriteLine("Input text: ");
            string text = //Console.ReadLine();
            "Hello Hello hello Hello my My My friend. my friend friend what are you doing you";
            char[] separators = new char[] { ' ', '.', ',', '!', '?', '"', ';', ':' };

            var wordCount = text.ToLower()
                                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                                .GroupBy(x => x)
                                .OrderByDescending(x => x.Count())
                                .ToDictionary(x => x.Key, x => x.Count());

            foreach (var w in wordCount)
            {
                Console.WriteLine($"{w.Key}: {w.Value}");
            }       
           
            Console.WriteLine("\n===Вердикт анализа===");

            if (wordCount.First().Value == wordCount.Last().Value)   
            {
                Console.WriteLine($"Каждое слово использовано в количестве {wordCount.First().Value}");
            }
            else
            {
                Console.WriteLine("Наиболее часто использованные слова:");
                foreach (var w in wordCount)
                {
                    if (w.Value < wordCount.First().Value) break;
                    else Console.WriteLine($"{w.Key}: {w.Value}");
                }
                Console.WriteLine("Постарайтесь заменить их синонимами");
            }
        }    
    }
}
