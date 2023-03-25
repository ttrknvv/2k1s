using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab15
{
    static class Tasks
    {
        public static void Task1()
        {
            Console.WriteLine("===============================   TASK 1   ===============================");
            Task Eratos = new Task(() => ErSieve(100));
            Console.WriteLine($"ID текущей задачи:{Eratos.Id}");
            Console.WriteLine($"Статус во время создания:{Eratos.Status}");
            Eratos.Start();
            Console.WriteLine($"Статус во время выполнения:{Eratos.Status}\n");
            Eratos.Wait();
            Console.WriteLine($"Статус во время завершения:{Eratos.Status}");
            void ErSieve(int n)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                bool[] flags = new bool[n];

                for (int i = 0; i < flags.Length; i++)
                    flags[i] = true;

                flags[1] = false;
                for (int i = 2, j = 0; i < n;)
                {
                    if (flags[i])
                    {
                        j = i * 2;
                        while (j < n)
                        {
                            flags[j] = false;
                            j += i;
                        }
                    }
                    i++;
                }

                Console.WriteLine($"Поиск простых чисел от 1 до {n}:");
                for (int i = 2; i < flags.Length; i++)
                {
                    if (flags[i])
                    {
                        Thread.Sleep(10);
                        Console.Write($"{i} ");
                    }
                }
                Console.WriteLine();

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("Общее время:" + elapsedTime);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        public static void Task2()
        {
            Console.WriteLine("===============================   TASK 2   ===============================");
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            Task Eratos2 = new Task(() => EratosSieve2(100));
            Console.WriteLine($"ID текущей задачи:{Eratos2.Id}");
            Console.WriteLine($"Статус во время создания:{Eratos2.Status}");
            Eratos2.Start();

            Console.WriteLine("Нажмите 0 для остановки процеса:\n");
            string s = Console.ReadLine();
            if (s == "0")
                tokenSource.Cancel();
            Console.WriteLine($"Статус во время завершения:Completed");

            void EratosSieve2(int n)
            {
                CancellationToken tokenForEr = tokenSource.Token;

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                bool[] flags = new bool[n];

                for (int i = 0; i < flags.Length; i++)
                    flags[i] = true;

                flags[1] = false;
                for (int i = 2, j = 0; i < n;)
                {
                    Console.WriteLine($"Выполнение задачи {Task.CurrentId}...");
                    System.Threading.Thread.Sleep(1000);
                    if (flags[i])
                    {
                        j = i * 2;
                        while (j < n)
                        {
                            flags[j] = false;
                            j += i;
                        }
                    }
                    i++;

                    if (tokenSource.Token.IsCancellationRequested)
                        return;

                    if (tokenForEr.IsCancellationRequested)                         /// почему-то останавливает процесс при вводе любого
                    {                                                               /// символа. если кто знает что не так
                        Console.WriteLine("\nПроцесс был остановлен.");            /// то как говорится contact me
                        break;
                        return;
                    }
                }
                Console.WriteLine($"Поиск простых чисел от 1 до {n}:");
                for (int i = 2; i < flags.Length; i++)
                {
                    if (flags[i])
                    {
                        Thread.Sleep(10);
                        Console.Write($"{i} ");
                    }
                }
                Console.WriteLine();

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("Общее время:" + elapsedTime);
            }
        }
        public static void Task3()
        {
            Console.WriteLine("===============================   TASK 3   ===============================");
            Task<int> task3_1 = new Task<int>(() =>
            {
                int x = 2;
                for (int i = 1; i < 7; i++)
                    x *= i;
                Console.WriteLine($"Первый результат:{x}");
                return x;
            });

            Task<int> task3_2 = new Task<int>(() =>
            {
                int x = 1;
                for (int i = 1; i < 4; i++)
                {
                    x++;
                    x *= x;
                }
                Console.WriteLine($"Второй результат:{x}");
                return x;
            });

            Task<int> task3_3 = new Task<int>(() =>
            {
                int z = -300;
                for (int i = 0; i < 54; i++)
                    z += i;
                Console.WriteLine($"Третий результат:{z}");
                return z;
            });

            Task[] tasks = { task3_1, task3_2, task3_3 };
            foreach (Task task in tasks)
                task.Start();
            Task.WaitAll(tasks);
            Console.WriteLine("Результирующая сумма:" + (task3_1.Result + task3_2.Result + task3_3.Result));
        }
        public static void Task4()
        {
            Console.WriteLine("===============================   TASK 4   ===============================");
            Task<int> task1 = new Task<int>(() => Sum(42, 53));
            Task task2 = task1.ContinueWith(sum => Display(sum.Result));
            task1.Start();
            task2.Wait();
            int Sum(int a, int b)
            {
                Console.WriteLine($"Первый параметр:{a}\nВторой параметр:{b}");
                return (a + b);
            }
            void Display(int sum)
            {
                Console.WriteLine($"Сумма двух параметров:{sum}");
            }
        }
        public static void Task5()
        {
            Console.WriteLine("===============================   TASK 5   ===============================");
            List<long> list = new List<long>() { 8, 10, 7, 12 };

            Console.WriteLine("Параллельный цикл:\n");
            ParallelLoopResult result = Parallel.ForEach<long>(list, Factorial);
            void Factorial(long x)
            {
                long res = 1;

                for (int i = 1; i <= x; i++)
                {
                    res *= i;
                }
                Console.WriteLine($"Выполняется задача:{Task.CurrentId}");
                Console.WriteLine($"Результат нахождения факториала:{res}");
            }

            Console.WriteLine("\nСтандартный цикл:\n");
            foreach (long l in list)
            {
                long result1 = 1;
                for (int i = 1; i <= l; i++)
                    result1 *= i;
                Console.WriteLine($"Фаткориал от {l} это {result1}.");
            }
        }
        public static void Task6()
        {
            Console.WriteLine("===============================   TASK 6   ===============================");
            Parallel.Invoke(
                Display,
                () =>
                {
                    Console.WriteLine($"Выполняется задача:{Task.CurrentId}");
                },
                () => Factorial(5)
             );
            void Display()
            {
                Console.WriteLine($"Выполняется задача:{Task.CurrentId}");
            }


            void Factorial(long x)
            {
                long result = 1;

                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
                Console.WriteLine($"Выполняется задача:{Task.CurrentId}");
                Console.WriteLine($"Результат нахождения факториала:{result}");
            }
        }
        public static void Task7()
        {

            BlockingCollection<string> bc = new BlockingCollection<string>(5);
            CancellationTokenSource ts = new CancellationTokenSource();
            CancellationToken token7 = ts.Token;

            Task[] sellers = new Task[10]
            {
                            new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Кровать"); } }),
                            new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Стул"); } }),
                            new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Стол"); } }),
                            new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Холодильник"); } }),
                            new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Ковер"); } }),

                            new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Дождик"); } }),
                            new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Ручка"); } }),
                            new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Колесо"); } }),
                            new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Тарелка"); } }),
                            new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Вилка"); } }),
            };

            Task[] consumers = new Task[5]
            {
                            new Task(() => { while(true){ Thread.Sleep(200);   bc.Take(); } }),
                            new Task(() => { while(true){ Thread.Sleep(400);   bc.Take(); } }),
                            new Task(() => { while(true){ Thread.Sleep(500);   bc.Take(); } }),
                            new Task(() => { while(true){ Thread.Sleep(400);   bc.Take(); } }),
                            new Task(() => { while(true){ Thread.Sleep(250);   bc.Take(); } })
            };

            foreach (var item in sellers)
                if (item.Status != TaskStatus.Running)
                    item.Start();

            foreach (var item in consumers)
                if (item.Status != TaskStatus.Running)
                    item.Start();
            int count = 0;
            while (true)
            {
                if (bc.Count != count && bc.Count != 0)
                {
                    count = bc.Count;
                    Thread.Sleep(400);
                    Console.Clear();
                    Console.WriteLine("============   TASK 7   =============");
                    Console.WriteLine("--------------- Склад ---------------");

                    foreach (var item in bc)
                        Console.WriteLine(item);

                    Console.WriteLine("-------------------------------------");
                    /*    if (bc.Count == count)
                        {
                            ts.Cancel();
                            if (ts.Token.IsCancellationRequested)
                                return;

                            if (token7.IsCancellationRequested)                         /// почему-то останавливает процесс при вводе любого
                            {                                                               /// символа. если кто знает что не так
                                Console.WriteLine("\nПроцесс был остановлен.");            /// то как говорится contact me
                                break;
                                return;
                            }
                        }*/
                }
            }
        }
        public static void Task8()
        {
            Console.WriteLine("===============================   TASK 8   ===============================");
            FactorialAsync();
            Console.WriteLine("Некоторые действия в методе Main");
            Console.ReadKey();                              // тут надо нажать на любую кнопку, чтобы запустить следующую задачу!!!!
            async void FactorialAsync()
            {
                Console.WriteLine("Начало метода FactorialAsync");
                await Task.Run(() => Factorial());
                Console.WriteLine("Конец метода FactorialAsync");

            }
            void Factorial()
            {
                int result = 1;
                for (int i = 1; i <= 6; i++)
                {
                    result *= i;
                }
                Thread.Sleep(1000);
                Console.WriteLine($"Результат факториала:{result}");
            }
        }
    }
}
