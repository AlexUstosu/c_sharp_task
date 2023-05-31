using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorTest
{
    class Point 
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {
            
        }

        public Point( int x, int y)
        {
            X = x;
            Y = y;
        }


        public static Point operator++ (Point p)
        {
            p.X++;
            p.Y++;
            return p;
        }
        public static Point operator --(Point p)
        {
            p.X--;
            p.Y--;
            return p;
        }
        public static Point operator+ (Point left, Point right)
        {
            return new Point { X = left.X + right.X,
                               Y = left.Y + right.Y};
        }
        public static Point operator- (Point left, Point right)
        {
            return new Point { X = left.X - right.X,
                               Y = left.Y - right.Y};
        }
        public static Point operator* (Point left, Point right)
        {
            return new Point
            {
                X = left.X * right.X,
                Y = left.Y * right.Y
            };
        }
        public static Point operator *(Point left, int right)
        {
            left.X *= right;
            left.Y *= right;
            return left;
        }
        public static Point operator -( Point right)
        {
            return new Point
            {
                X = - right.X,
                Y = - right.Y
            };
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public static bool operator== (Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }

        public static bool operator true(Point point)
        {
            return point.X != 0 || point.Y != 0 ?  true : false;
        }
        public static bool operator false(Point point)
        {
            return point.X == 0|| point.Y == 0 ? true : false;
        }

        public static Point operator |(Point left, Point right)
        {
            if ((left.X != 0 || left.Y != 0) ||
               (right.X != 0 || right.Y != 0))
                return right;
            return new Point();
        }
        public static Point operator &(Point left, Point right)
        {
            if ((left.X != 0 && left.Y != 0) &&
               (right.X != 0 && right.Y != 0))
                return right;
            return new Point();
        }

        public override string ToString()
        {
            return "X - " + X.ToString() + ", Y - " + Y.ToString();
        }

        
    }
    class Point1 : Point
    {
        public static implicit operator Point1(Point2 p)
        {
            return new Point1();
        }
    }
    class Point2 : Point
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Point p_1 = new Point(10,-1);
            Point p_2 = p_1;



            
           Console.WriteLine(p_1.Equals(p_2));




            //Console.WriteLine("Унарный оператор(Инкремент) - > " + (p_1++).ToString());
            //Console.WriteLine("Унарный оператор(Декримент) - > " + (p_2--).ToString());

            //Console.WriteLine("Оператор(+) - > " + (p_1 + p_2).ToString());
            //Console.WriteLine("Оператор(-) - > " + (p_1-p_2).ToString());

            //Console.WriteLine("Оператор(*) - > " + (p_1 * p_2).ToString());









            Console.ReadKey();
        }
    }
}
