namespace LP_Lab04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sofa sofa = new Sofa(); // пример создания объекта
            sofa.Price = 200;
            sofa.NameOfFabricator = "Belarus";
            sofa.Count = 200;
            sofa.GetInfoOfProduct();
            Console.WriteLine();

            Product product = new Product(3000); // пример метода ToString
            Console.WriteLine(product);
            Console.WriteLine();

            if (sofa is ICount count) // пример приведения к интерфейсу
            {
                count.Buy();
                Console.WriteLine(sofa.Count);
            }
            Console.WriteLine();

            Chair chair = new Chair(); // пример приведения к абстрактному классу
            chair.Count = 150;
            if(chair is Count count2)
            {
                count2.Refund();
                Console.WriteLine(chair.Count);
            }
            Console.WriteLine();

            Furniture a = new Furniture();// переопределенные методы ToString
            Wardrobe a2 = new Wardrobe();
            Hanger a3 = new Hanger();
            Console.WriteLine(a + "\n" + a2 + "\n" + a3);
            Console.WriteLine();

            // дополнительный класс Printer c полиморфным методом
            ICount[] count3 = { new Bed(), new Chair(), new Curbstone(), new Hanger(), new SlidingWardrobe(), new Sofa(), new Wardrobe() };
            foreach (var i in count3)
            {
                Printer.IAmPrinting(i);
            }
      }
    }
}