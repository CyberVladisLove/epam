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
            //getSquare();          //1.1
            //drawTriangle();       //1.2
            //drawAnotherTriangle();//1.3
            //drawXMassTree();      //1.4
            //sumOfNumbers();       //1.5
            //fontAdjustment();     //1.6
            //arrayProcessing();    //1.7
            //noPositive();         //1.8
            //nonNegativeSum();     //1.9
            //sum2DArray();         //1.10

            

        }
        static void getSquare()         //1.1
        {
            int a;
            int b;
            while (true)
            {
                Console.Write("Input a: ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Input b: ");
                b = Convert.ToInt32(Console.ReadLine());
                if (a <= 0 || b <= 0)
                {
                    Console.WriteLine("Can u input positive numbers, try again");
                }
                else break;

            }
            Console.WriteLine($"Square: {a * b}");
        }
        static void drawTriangle()      //1.2
        {
            Console.Write("Input N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<=i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }
        }
        static void drawAnotherTriangle()//1.3
        {
            Console.Write("Input N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n*2; j++)
                {
                    if (j < n - i || j > n + i)
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write("*");
                    }
                    

                }
                Console.WriteLine();

            }
        }
        static void drawXMassTree()     //1.4
        {
            Console.Write("Input N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0, countOfTriangle = 0; i < n; i++)
            {
                for (int j = 0; j < n * 2; j++)
                {
                    if (j < n - i || j > n + i) Console.Write(' ');
                    else Console.Write("*");
                    
                }
                Console.WriteLine();
                if (i == countOfTriangle)
                {
                    i = -1;
                    countOfTriangle++;
                }
                if (countOfTriangle == n) break;
            }
        }
        static void sumOfNumbers()      //1.5
        {
            int sum = 0;
            for (int i = 3; i < 1000; i++)
            {
                if (i%3 == 0 || i%5 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine($"sum numbers /3 /5 before 1000: {sum}");

        }
        static void fontAdjustment()    //1.6
        {
            List<String> fontParams = new();
            List<String> myFontParams = new();
            
            fontParams.Add("bold");
            fontParams.Add("italic");
            fontParams.Add("underline");

            while (true)
            {
                //если пустой лист параметров, то вывод "none"
                string message = myFontParams.Count > 0 ? 
                    string.Join(",", myFontParams.ToArray()) : "none";

                Console.WriteLine($"Параметры надписи: {message}");
                Console.WriteLine("Введите: ");

                //вывод меню выбора
                foreach (var param in fontParams)
                {
                    int num = fontParams.IndexOf(param) + 1;
                    Console.WriteLine($"{num}: {param}");
                }

                //ввод значения и корректировка индекса для работы с листом
                int index = Convert.ToInt32(Console.ReadLine()) - 1;

                //проверка, есть ли уже в листе такой параметр. если нет - добвляет, если есть - удаляет
                if (myFontParams.Contains(fontParams[index])){
                    myFontParams.Remove(fontParams[index]);
                }
                else myFontParams.Add(fontParams[index]);
            }

        }
        static void arrayProcessing()   //1.7
        {
            int[] arr = new int[10];
            Console.Write("arr:");

            //random
            for (int i = 0; i < arr.Length; i++)
            {
                Random rnd = new Random();
                arr[i] = rnd.Next(0,10);
                Console.Write($" {arr[i]}"); 
            }
            Console.WriteLine();

            //max,min
            int max = arr[0];
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max) max = arr[i];
                if (arr[i] < min) min = arr[i];
            }
            Console.WriteLine($"max: {max}");
            Console.WriteLine($"min: {min}");

            //sort
            Console.Write("sort:");
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length-1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }
            //print
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($" {arr[i]}");
            }
            Console.WriteLine();
        }
        static void noPositive()        //1.8
        {
            int[,,] arr = new int[3,3,3];
            
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        if(arr[i, j, k] > 0) arr[i, j, k] = 0;
                    }         
                }           
            }

        }
        static void nonNegativeSum()    //1.9
        {
            int[] arr = new int[5] {1,4,0,-1,-2};
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += (arr[i] > 0 ? arr[i] : 0);
            }
            Console.WriteLine(sum);
        }
        static void sum2DArray()        //1.10
        {
            int[,] arr = new int[3, 3] { {1, 4, 0 }, { 1, 2, 5 }, { 0, 2, 8 } };
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0) sum += arr[i, j];
                    Console.Write($"{arr[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"sum: {sum}");
        }
       

    }   
}
