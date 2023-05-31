using ConsoleApp2;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp2
{
    partial class MyClass
    {

        private int x;

        public int X
        {
            get 
            { 
                return x; 
            }
            set 
            {
                    x = value; 
            }
        }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            private set { myVar = value; }
        }
        public int MyProperty1 { get; set; } = 25;


        private int y;
        private int z;
        private int n;

        public MyClass() : this(1,2,3,4)
        {
           // Console.WriteLine("Конструктор по умолчанию!");
        }

        public MyClass(int x)
        {
            this.x = x;
            //Console.WriteLine("Второстепенный конструктор!");
        }
        public MyClass(int x, int y) : this(x)
        {
            this.y = y;
            //Console.WriteLine("Второстепенный конструктор!");
        }

        public MyClass(int x, int y, int z, int n) : this(x,y)
        {
            this.z = z;
            this.n = n;

            //Console.WriteLine("Главный конструктор!");
        }

       
        public int method(in int x, params int[] parametrs)
        {
            Console.WriteLine("Параметр  с ссылкой - ");
            Console.WriteLine(x);

            int result = x;

            for (int i = 0; i < parametrs.Length; i++)
            {
                result += parametrs[i];
            }
            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();

            myClass.X = 10;

            int x = 6;
            int y = 0;

            int temp = myClass.method(x, y, 2, 5 , 8, 9 , 10);

            myClass.f_1();

            Console.WriteLine(temp);

            Console.ReadKey();
        }
    }
}
