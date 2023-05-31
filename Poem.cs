using System;


namespace ConsoleApp3005
{
    public delegate void PickUpPhoneDelegate (string who);
    class Elephant
    {
        public string Name { get; set; }
        public string From { get; set; }
        public string IWant { get; set; }

        public override string ToString()
        {
            return $"Говорит: {Name} \n" + $"Откуда: {From}\n" + $"Что вам надо? {IWant}" ; 
        }

        public void AnswerForCall(string who)
        {
            Console.Write(this.ToString());
        }
    }

    class Caller
    {
        public event PickUpPhoneDelegate callEvent;
        public void Call()
        {
            if(callEvent != null)
            {
                Console.WriteLine("Я звоню!");
                callEvent("Я звоню!");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Elephant elephant = new Elephant { Name = "Слон", From = "От верблюда", IWant = "Шоколада" };
            Caller caller = new Caller();

            caller.callEvent += elephant.AnswerForCall;

            caller.Call();

            Console.ReadKey();

        }
    }
}
