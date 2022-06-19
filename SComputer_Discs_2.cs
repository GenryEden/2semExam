using System;
using System.Collections.Generic;

// объявите струкуру, которая бы описывала персональный компьютер SComputer.
// ...
// Далее разработайте функцию, которая бы получала список элементов типа SComputer,
// отсортированный по общему размеру дисков и определяла бы бинарным поиском номер компьютера с заданным объемом дисков
namespace ConsoleApp1
{
    class Program
    {
        public struct SComputer
        {
            public List<double> Drives;
            private double SumVolume;

            public void AddDrives(double drive)
            {
                Drives.Add(drive);
            }
            public double GetSum()
            {
                foreach(double drive in Drives)
                {
                    SumVolume += drive;
                }
                return SumVolume;
            }

        }
        public static void Main(string[] args)
        {
            int resInd;
            List<SComputer> test=new List<SComputer>();
            for(int i = 0; i < 5; i++)
            {
                SComputer c = new SComputer();
                c.Drives = new List<double>();
                test.Add(c);
            }
            test[0].AddDrives(1.2);
            test[1].AddDrives(1.2);
            test[1].AddDrives(1.2);
            test[2].AddDrives(1.2);
            test[2].AddDrives(1.2);
            test[2].AddDrives(1.2);
            test[3].AddDrives(1.2);
            test[3].AddDrives(1.2);
            test[3].AddDrives(1.2);
            test[3].AddDrives(1.2);
            test[4].AddDrives(1.2);
            test[4].AddDrives(1.2);
            test[4].AddDrives(1.2);
            test[4].AddDrives(1.2);
            test[4].AddDrives(1.2);
            Search(test, 6, out resInd);
            if (resInd == -1)
            {
                Console.WriteLine("компьютер не найден");
            }
            else
            {
                Console.WriteLine("Номер компьютера {0}", resInd);
            }
            Console.ReadKey();
        }

        public static bool Search(List<SComputer> computers, double volume, out int resInd)
        {
            int mid;
            int index1 = 0;
            int index2 = computers.Count-1;
            while (index1<=index2)
            {
                mid = (index1 + index2) / 2;
                if(computers[mid].GetSum()==volume)
                {
                    resInd = mid;
                    return true;
                }
                else if (computers[mid].GetSum() < volume)
                {
                    index1 = mid+1;
                }
                else
                {
                    index2 = mid - 1;
                }
            }
            resInd = -1;
            return false;
        }
    }
}
