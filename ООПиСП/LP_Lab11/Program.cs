namespace LP_Lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Рефлексия
            // 1 задание
            Reflector.PathToFile = "D:\\2k1s\\ООПиСП\\LP_Lab11\\InfoClass.txt"; // записать путь к файлу
            Reflector.NameOfClass = "LP_Lab11.RandomClass";
            Reflector.StartWriteInfo(); // начальная информация
            Reflector.WriteNameOfAssembly();  // Определение имени сборки
            Reflector.WritePublicConstructor(); // запись в файл информации о наличии публичных конструкторов
            var n1 = Reflector.GetAllPublicMethods(); // получение всех публичных методов
            var n2 = Reflector.GetDataAndPropetry(); // получение всех полей и свойств
            var n3 = Reflector.GetAllInterface(); // получение всем реализованных интерфейсов
            Reflector.WriteAllMethodIncludeParam("LP_Lab11.RandomClass", typeof(double));
            string[] paramets = File.ReadAllLines("D:\\2k1s\\ООПиСП\\LP_Lab11\\parameters.txt");
            Reflector.Invoke("LP_Lab11.RandomClass", "ExampleDouble", paramets);
            Random numb = new Random();
            Reflector.Invoke("LP_Lab11.RandomClass", "ExampleDouble", new object[] {numb.NextDouble(), 
                                numb.NextDouble(), numb.NextInt64(0, 99999)});

            Reflector.PathToFile = "D:\\2k1s\\ООПиСП\\LP_Lab11\\InfoClass2.txt"; // записать путь к файлу
            Reflector.NameOfClass = "System.Random";
            Reflector.StartWriteInfo(); // начальная информация
            Reflector.WriteNameOfAssembly();  // Определение имени сборки
            Reflector.WritePublicConstructor(); // запись в файл информации о наличии публичных конструкторов
            var n12 = Reflector.GetAllPublicMethods(); // получение всех публичных методов
            var n22 = Reflector.GetDataAndPropetry(); // получение всех полей и свойств
            var n32 = Reflector.GetAllInterface(); // получение всем реализованных интерфейсов
            Reflector.WriteAllMethodIncludeParam("LP_Lab11.RandomClass", typeof(double));
            var obj = Reflector.Create(typeof(RandomClass)); // создание объекта
        }
    }
}