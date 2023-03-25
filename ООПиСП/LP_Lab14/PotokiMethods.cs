using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab14
{
    static class PotokiMethods
    {
        public static void PrintInfoProcesses()
        {
            var processes = Process.GetProcesses();
            foreach(Process process in processes)
            {
                try
                {
                    Console.WriteLine($"{process.Id} {process.ProcessName} {process.StartTime}");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static void workWithDomen()
        {
            var domain = Thread.GetDomain();
            Console.WriteLine($"\n\n\nИмя:  {domain.FriendlyName}");
            Console.WriteLine($"Setup Информация:  {domain.SetupInformation.ToString()}");
            Console.WriteLine("Сборки:");
            foreach (var item in domain.GetAssemblies())
            {
                Console.WriteLine("    " + item.FullName.ToString());
            }
        }
        public static void printNumb(object n)
        {
            int n2 = (int)n;
            using(StreamWriter write = new StreamWriter("D:\\2k1s\\ООПиСП\\LP_Lab14\\Task3.txt"))
            {
                for(int j = 1; j <= n2; j++)
                {
                    Console.WriteLine(j);
                    write.WriteLine(j);
                    Thread.Sleep(500);
                }
            }
        }
        public static void EvenNumb(object n)
        {
                for (int i = 0; i <= (int)n; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine($"{i} ");
                        File.AppendAllText("D:\\2k1s\\ООПиСП\\LP_Lab14\\Task4.txt", Convert.ToString(i) + "\n");
                        Thread.Sleep(100);
                    }
                }
        }
        public static void OddNumbers(object n)
        {
                for (int i = 0; i <= (int)n; i++)
                {
                    if (i % 2 != 0)
                    {
                        Console.WriteLine($"{i} ");
                        File.AppendAllText("D:\\2k1s\\ООПиСП\\LP_Lab14\\Task4.txt", Convert.ToString(i) + "\n");
                        Thread.Sleep(120);
                    }
                }
            }
        public static void printMess(object a)
        {
            Console.WriteLine("Hello, World");
        }
    }
}
