using System;

using static System.Console;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Figure[] figures = new Figure[5];
            figures[0] = new Circle();
            figures[1] = new Circle();
            figures[2] = new Triangle();
            figures[3] = new Triangle();
            figures[4] = new Square();

            foreach (Figure f in figures) {
                WriteLine(f.ToString());
            }

            Circle c = figures[0] as Circle;
            if (c.Equals(figures[1]))
                Console.WriteLine("TRUE");

            Object.Equals(c, figures[2]);

            c.GetType();

            c.ToString();

            c.GetHashCode();

            Object.ReferenceEquals(c, figures[0]);

            if (figures[0] is Circle)
                WriteLine(c.ToString());
            
            WriteLine(((Circle)figures[0]).ToString());

            ReadKey();
        }
    }
    abstract class Figure
    {
        public abstract void Show();
    }
    class Circle : Figure
    {
        public override void Show()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return "Circle : Figure";
        }
    }
    class Square : Figure
    {
        public override void Show()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return "Square : Figure";
        }
    }
    class Triangle : Figure
    {
        public override void Show()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return "Triangle : Figure";
        }
    }
}


