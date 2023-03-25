namespace LP_Lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 point
            PotokiMethods.PrintInfoProcesses();
            // 2 point
            PotokiMethods.workWithDomen();
            //AppDomain domen = AppDomain.CreateDomain("Domen");
            //domen.Load("Assembly");
            //AppDomain.Unload(domen);
            // 3 point
            Thread simpleThread = new Thread(new ParameterizedThreadStart(PotokiMethods.printNumb));
            simpleThread.Start(8);
            Console.WriteLine($"{simpleThread.Priority} {simpleThread.Name} {simpleThread.ManagedThreadId}");
            simpleThread.Join();
            // 4 point
            Thread potok = new Thread(PotokiMethods.EvenNumb);
            potok.Priority = ThreadPriority.AboveNormal;
            potok.Start(20);
            potok.Join();
            Console.WriteLine();

            Thread potok2 = new Thread(PotokiMethods.OddNumbers);
            potok2.Priority = ThreadPriority.BelowNormal;
            potok2.Start(20);
            potok2.Join();
            // 5 point
            TimerCallback tm = new TimerCallback(PotokiMethods.printMess);
            Timer timer = new Timer(tm, null, 1000, 1000);
            Thread.Sleep(4000);
        }
    }
}