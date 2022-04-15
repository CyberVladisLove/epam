using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PizzaTime
{
    public static class StringExtensions
    {
        public static string GetLanguage(this string s)
        {
            string str = new(s);

            List<Language> langs = new();
            if (Regex.IsMatch(str, "[а-яА-ЯеЁ]")) langs.Add(Language.Russian);
            if (Regex.IsMatch(str, "[a-zA-Z]")) langs.Add(Language.English);
            if (Regex.IsMatch(str, "[0-9]")) langs.Add(Language.Number);

            if (langs.Count > 1) 
                return Verdict(Language.Mixed);

            return Verdict(langs.FirstOrDefault());
        }

        public enum Language
        {
            English,
            Russian,
            Number,
            Mixed
        }

        public static string Verdict(Language lang)
        {
            switch (lang)
            {
                case Language.English: return "английский язык";
                case Language.Russian: return "русский язык";
                case Language.Number: return "набор чисел";
                case Language.Mixed: return "много языков";
                default: return "undefined";
            }
            
        }
    }
}
