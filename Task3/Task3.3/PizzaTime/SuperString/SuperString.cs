using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime
{
    class SuperString
    {
        public static void Run()
        {
            Console.WriteLine("===3.3.2_SuperString===");
            Console.WriteLine("Input text: ");
            string text = Console.ReadLine();
            //"Hello Hello hello Hello my My My friend. my friend friend what are you doing you";

            Console.WriteLine(text.GetLanguage());

        }
    }
}
