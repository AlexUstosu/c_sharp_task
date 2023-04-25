using ConsoleApp2;
using System;


namespace ConsoleApp2
{
    internal class Program
    {
        enum DayOfWeek
        {
            monday = 1, tuesday, wednesday, thirsday, friday, saturday, sunday
        }

        static void Main(string[] args)
        {
            string strDayOfWeek = "";
            int callDuration = 0;
            double cost = 0;

            const double K = 3.5;

            Console.WriteLine("Введите день недели -> ");
            strDayOfWeek = Console.ReadLine();

            Console.WriteLine("\nВведите продолжительность разговора(мин) -> ");
            callDuration = Convert.ToInt16(Console.ReadLine());

            DayOfWeek dayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), strDayOfWeek.ToLower());

            switch (dayOfWeek)
            {
                case DayOfWeek.monday:
                case DayOfWeek.tuesday:
                case DayOfWeek.wednesday:
                case DayOfWeek.thirsday:
                case DayOfWeek.friday:
                    cost = callDuration * K;
                    Console.WriteLine($"Cтоимость звонка -> {cost}\n"); ;
                    break;
                case DayOfWeek.saturday:
                case DayOfWeek.sunday:
                    cost = callDuration * K * 0.8;
                    Console.WriteLine($"Cтоимость звонка со скидкой-> {cost}\n"); ;
                    break;
                default:
                    Console.WriteLine("Невероятная ошибка");
                    break;
            }

            Console.ReadKey();
        }
    }
}
