using ConsoleApp2;
using System;


namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] array = new int[20]; 

            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 11);
            }

            Console.WriteLine("Входной массив - > ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                Console.Write(" ");
            }

            //Нахождение среднего арифм.
            double sr = 0;
            for (int i = 0; i < array.Length; i++)
                sr += array[i];

            sr /= array.Length;

            //Нахождение кол-ва
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (sr < array[i])
                    count++;
            }

            //Нахождение процентного отношения
            double per;

            per = ((double)count / array.Length)*100;

            Console.WriteLine($"\nСреднее арифм. - > {sr}");
            Console.WriteLine($"Процентное отношение - > {per}%");

            Console.ReadKey();
        }
    }
}
