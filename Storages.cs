using System;

namespace ConsoleApp2305
{
    abstract class Storage
    {
        private string _name;
        private string _model;

        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public abstract UInt32 getV();
        public abstract UInt32 getFreeV(UInt32 closeV);
        public void Copy(string name) 
        {
            Console.WriteLine($"Процесс копирования данных с носителя {name}...");
        }
        public abstract string getInfo();

    }
    class DvdClass : Storage
    {
        public UInt32 Volume { get; set; }
        public string DvdType { get; set; }
        public UInt32 Speed { get; set; }

        public override UInt32 getV()
        {
            return Volume;
        }
        public override UInt32 getFreeV(UInt32 closeV)
        {
            return Volume - closeV;
        }
        public override string ToString()
        {
            return $"\t\t\tНоситель: DVD\nТип: {DvdType}\n" +
                $"Объём: " + getV().ToString() + 
                $"Скорость: {Speed}"; 
        }
        public override string getInfo()
        {
            return this.ToString();
        }
    }
    class HddClass : Storage
    {
        public UInt32 Volume { get; set; }
        public UInt32 CountChapter { get; set; }
        public UInt32 Speed { get; set; }

        public override UInt32 getV()
        {
            return Volume;
        }
        public override UInt32 getFreeV(UInt32 closeV)
        {
            return Volume - closeV;
        }
        public override string ToString()
        {
            return $"\t\t\tНоситель: HDD\n" +
                $"Скорость: {Speed}" +
                $"Кол-во разделов: {CountChapter}\n" + 
                $"Объём разделов: " + getV().ToString();
        }
        public override string getInfo()
        {
            return this.ToString();
        }
    }
    class FlashClass : Storage
    {
        public UInt32 Volume { get; set; }
        public UInt32 Speed { get; set; }

        public override UInt32 getV()
        {
            return Volume;
        }
        public override UInt32 getFreeV(UInt32 closeV)
        {
            return Volume - closeV;
        }
        public override string ToString()
        {
            return $"\t\t\tНоситель: Flash\n" +
                $"Скорость: {Speed}" +
                $"Объём: " + getV().ToString();
        }
        public override string getInfo()
        {
            return this.ToString();
        }
    }

    internal class InformationTransfer
    {
        public Storage[] storages;

        public InformationTransfer(int size)
        {
            storages = new Storage[size];
        }

        public int Lenght
        {
            get { return storages.Length; }
        }


        public Storage this[int index]
        {
            get 
            { 
                if(index >= 0 || index < storages.Length)
                {
                    return storages[index];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                storages[index] = value;
            }
        }

        public UInt32 CalculateMemoryAmount(Storage[] storage)
        {
            UInt32 summMemory = 0;
            for (int i = 0; i < storage.Length; i++)
            {
                summMemory += storage[i].getV();
            }
            return summMemory;
        }

        public UInt32[] CalculateTimeAmount(Storage[] storage)
        {
            UInt32 memory = CalculateMemoryAmount(storage);

            UInt32[] time = new UInt32[storage.Length];

            UInt32 currentVolume;

            for (int i = 0; i < storage.Length; i++)
            {
                if (storage[i] is DvdClass)
                {
                    time[i] = storage[i].getV() / ((DvdClass)storage[i]).Speed;
                }
                else if (storage[i] is HddClass)
                {
                    time[i] = storage[i].getV() / ((HddClass)storage[i]).Speed;
                }
                else
                {
                    time[i] = storage[i].getV() / ((FlashClass)storage[i]).Speed;

                }

                memory -= storage[i].getV();
            }
            return time;
        }

        public UInt32 CalculateInfoAmount(UInt32 amount)
        {
            return CalculateMemoryAmount(this.storages) + amount;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для работы с носителями информации");
            Console.WriteLine("Введите количество носителей - ");
            
            if(Int32.TryParse(Console.ReadLine(), out int storageCount))
            {
                InformationTransfer carriers = new InformationTransfer(storageCount);

                for (int i = 0; i < storageCount; i++)
                {
                    Console.WriteLine("Какой носитель? 1 - DVD 2 - HDD 3 - FlashCard");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            carriers[i] = new DvdClass { Volume = 5, DvdType = "односторонний", Speed = 1350 };
                            break;

                        case 2:
                            carriers[i] = new HddClass { Volume = 1000, CountChapter = 3, Speed = 1 };
                            break;

                        case 3:
                            carriers[i] = new FlashClass { Volume = 16,  Speed = 1 };
                            break;

                        default:
                            break;
                    }
                    
                }

                Console.WriteLine($"Количество памяти - {carriers.CalculateMemoryAmount(carriers.storages)}");
                
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных! Неверное количество носителей");
            }
            Console.ReadKey();

        }
    }
}
