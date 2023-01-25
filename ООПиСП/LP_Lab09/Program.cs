namespace LP_Lab09_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                // 1 часть: класс, интерфейс, коллекция

                Queue <Services> clients = new Queue<Services> ();
                Services client1 = new Services { FirstNameClient = "Никита", LastNameClient = "Тараканов" };
                Services client2 = new Services { FirstNameClient = "Илья", LastNameClient = "Деревянко" };
                Services client3 = new Services { FirstNameClient = "Павел", LastNameClient = "Хлебович" };

                clients.InputQueue(client1); // добавление в очередь
                clients.InputQueue(client2);
                clients.InputQueue(client3);
                clients.PrintQueue();

                clients.DelQueue(); // удаление элемента
                clients.PrintQueue();

                clients.FindElement(client1); // поиск клиента
                clients.FindElement(client2);

                // 2 часть: универсальная коллекция

                Queue <int> queue = new Queue<int> (); // коллекция тип int
                queue.InputQueue(1);  // добавление элементов
                queue.InputQueue(2);
                queue.InputQueue(9);
                queue.InputQueue(10);
                queue.PrintQueue(); // вывод
                Console.WriteLine();
                queue.DelQueue(); // удаление элемента
                queue.PrintQueue();
                queue.FindElement(222); // поиск
                queue.FindElement(10);

                Dictionary<int, string> dic = new Dictionary<int, string> ();
                dic.AddElement(1, "Никита"); // добавление
                dic.AddElement(122, "Максим");
                dic.AddElement(69, "Олег");
                dic.AddElement(15, "Наташа");
                dic.PrintDictionary(); // вывод
                Console.WriteLine();
                dic.DeleteElement(); // удаление
                dic.PrintDictionary();
                Console.WriteLine();
                dic.PrintElement(2);
                dic.PrintElement(15);

                // 3 задание: наблюдаемая коллекция

                ObservableCollection<Services> serv = new ObservableCollection<Services> ();
                serv.CollectionChange += DisplayRedMessage; // подписка на событие              
                serv.AddElement(client1); // вызов обработчика
                serv.AddElement(client2);
                serv.AddElement(client3);
                serv.CollectionChange -= DisplayRedMessage;
                serv.CollectionChange += DisplayGreenMessage;
                serv.DeleteElement();
                serv.DeleteElement();
                serv.CollectionChange -= DisplayGreenMessage;
                serv.Print();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static public void DisplayRedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static public void DisplayGreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}