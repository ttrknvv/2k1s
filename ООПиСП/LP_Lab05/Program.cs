namespace LP_Lab04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Curbstone a = new Curbstone(); // структура в классе Curbstone
            a.KindOfThree = "Дуб";
            a.BestBeforeDate = 20;
            a.NameOfFabricator = "Беларусь";
            a.DateOfManufacture = 23122022;
            a.NameOfCurbstone = "Лиза";
            a.GetInfoOfProduct();
            Console.WriteLine();

            ////////////////////////////////////////////////

            Furniture b = new Furniture(); // перечисление в классе Furniture
            b.GetCountOfSingleFurniture(Furniture.Furnit.Chair);
            Console.WriteLine();

            ///////////////////////////////////////////////////

            SlidingWardrobe c = new SlidingWardrobe(); // partial классы и partial методы
            Console.WriteLine(c);
            c.Count = 200;
            c.Buy();
            Console.WriteLine(c.Count);
            Console.WriteLine();

            ///////////////////////////////////////////////////////////
            
            Sofa a1 = new Sofa { Count = 200, Price = 30, NameOfFabricator = "Беларусь"}; // класс - контейнер
            Bed a2 = new Bed { Count = 100, Price = 20, NameOfFabricator = "Россия" };
            Wardrobe a3 = new Wardrobe { Count = 4, Price = 10, NameOfFabricator = "Беларусь" };
            Wardrobe a4 = new Wardrobe { Count= 10, Price = 50, NameOfFabricator = "Беларусь" };
            Storage store = new Storage();
            store.CountOf = 4;
            store.AddElement(a1);
            store.AddElement(a2);

            store.RemoveElement(a1);

            store.AddElement(a3);
            store.AddElement(a1);
            store.AddElement(a4);

            store.PrintAllStorage();

            Console.WriteLine();

            ////////////////////////////////////////

            ControlStorage control = new ControlStorage(); // класс - контроллер

            int x = control.CostOfAllWardrobe(store); ;
            Console.WriteLine("Сумма всех шкафов на складе: " + x);

            int x2 = control.PriceOfFabricator(store, "Беларусь");
            Console.WriteLine("Сумма всех элементов Беларуси: " + x2);

            // файл
            string aFile = "D:\\2k1s\\ООПиСП\\LP_Lab05\\file.txt";
            Storage store2 = new Storage();
            ControlStorage controlStorage2 = new ControlStorage();
            controlStorage2.ReadFileIntoStore(aFile, store2);

            // json - файл
            string aFile2 = "D:\\2k1s\\ООПиСП\\LP_Lab05\\file2.json";
            Storage store3 = new Storage();
            ControlStorage controlStorage3 = new ControlStorage();
            controlStorage2.ReadJsonIntoStore(aFile2, store3);


        }
    }
}