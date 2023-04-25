using ConsoleApp2;
using System;


namespace ConsoleApp2
{
    internal class Program
    {
        struct Point
        {
           public double x;
           public double y;
        }

        static void Main(string[] args)
        {
            Point B = new Point();

            Console.WriteLine("Введите координаты точки");

            Console.WriteLine("x - ");
            B.x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("y - ");
            B.y = Convert.ToDouble(Console.ReadLine());

            double f = 0;
            if (Math.Abs(B.x) > 1)
            {
                f = Math.Pow(Math.Sin(Math.Pow(B.x,3)), 2 );
            }
            else if(Math.Abs(B.x) <= 1)
            {
                f = Math.Sqrt(6 * Math.Asin(Math.Pow(B.x,7)) + 
                    4.5F * Math.Pow(B.x, 6) +
                    4D * Math.Pow(B.x, 2) + 2 );
            }
            else
            {
                Console.WriteLine("Ошибка!");
            }

            if(Math.Abs(f - B.y) < Math.Pow(10, -3))
                Console.WriteLine($"f(x) - {f}, где погрешность < eps");
            else
                Console.WriteLine($"f(x) - {f}, где погрешность > eps");

            Console.ReadKey();
        }
    }
}
