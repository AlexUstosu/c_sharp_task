using System;

using static System.Console;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadKey();
        }
    }

    abstract class Stuff
    {
        int _id;
        Single _price;
        public Single Price
        {
            get { return _price; }
            set { _price = value; }
        }

        Single _size;
        public Single Size
        {
            get { return _size; }
            set { _size = value; }
        }

        protected abstract void GetComposition();
    }

    class HouseholdChemicals : Stuff
    {
        public String DangerLevel { get; set; }
        protected override void GetComposition()
        {
            throw new NotImplementedException();
        }
    }

    class FoodStuff : Stuff
    {
        public DateTime ShelfLife { get; set; }
        protected override void GetComposition()
        {
            throw new NotImplementedException();
        }
    }

    class ComeThread
    {
        public ComeThread()
        {

        }
    }

    class Realizethread
    {
        public Realizethread()
        {
            
        }
    }

    class WrittenOffThread
    {
        public WrittenOffThread()
        {
            
        }
    }

    class TransferedThread
    {
        public TransferedThread()
        {
            
        }
    }
}


