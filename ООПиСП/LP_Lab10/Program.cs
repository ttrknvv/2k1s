namespace LP_Lab10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // 1 задание: Array string and LINQ

            string[] Month = new string[] { "January", "February", "March", "April", "May", "June", "July", "August",
                                            "September", "October", "November", "December"}; // месяцы
            Console.WriteLine("Введите размер: ");
            int size = Convert.ToInt32(Console.ReadLine()); // получить размер
            IEnumerable<string> Month2 = from n in Month where n.Length == size select n; // запрос LINQ 1
            Console.WriteLine("Месяцы с заданной длиной имени: ");
            foreach(var a in Month2)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("Летние и зимние месяцы: ");
            IEnumerable<string> Month3 = from n in Month where n == "June" || n == "July" || n == "August" ||
                                         n == "January" || n == "February" || n == "December"
                                         select n; // запрос LINQ 2
            foreach (var a in Month3)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("Месяцы по возрастанию букв алфавита: ");
            IEnumerable<string> Month4 = from n in Month orderby n select n; // запрос LINQ 3
            foreach (var a in Month4)
            {
                Console.WriteLine(a);
            }

            IEnumerable<string> Month5 = from n in Month where n.Length >= 4 && n.Contains('u') select n; // запрос LINQ 4
            Console.WriteLine("Месяцы для имени которых не мене 4-ех и содержат букву u: ");
            foreach(var a in Month5)
            {
                Console.WriteLine(a);
            }
             // 2 задание: список класса
            List<Student> students = new List<Student>();
            students.Add(new Student() { FirstName = "Nikita", LastName = "Tarakanov", Faculty = "FIT", 
                                         Course = 2, Group = 4, Birthday = 07022004});
            students.Add(new Student() { FirstName = "Oleg", LastName = "Derevyanko", Faculty = "FIT", 
                                         Course = 3, Group = 5, Birthday = 07032003});
            students.Add(new Student() { FirstName = "Maxim", LastName = "Toshik", Faculty = "LID", 
                                         Course = 1, Group = 9, Birthday = 07022007});
            students.Add(new Student() { FirstName = "Alexander", LastName = "Hleb", Faculty = "DER", 
                                         Course = 4, Group = 4, Birthday = 07022001});
            students.Add(new Student() { FirstName = "Ekaterina", LastName = "Snow", Faculty = "Dozor", 
                                         Course = 2, Group = 9, Birthday = 07022002});
            students.Add(new Student() { FirstName = "Mariya", LastName = "Barateon", Faculty = "Gavan", 
                                         Course = 3, Group = 5, Birthday = 07022003});
            students.Add(new Student() { FirstName = "Vysheslav", LastName = "Lanister", Faculty = "Gavan", 
                                         Course = 4, Group = 4,Birthday = 07022009});
            students.Add(new Student() { FirstName = "Ilya", LastName = "Stark", Faculty = "Winterfel", 
                                         Course = 3, Group = 2, Birthday = 07022001});
            students.Add(new Student() { FirstName = "Evglida", LastName = "Night", Faculty = "FIT", 
                                         Course = 2, Group = 4, Birthday = 07022000});
            students.Add(new Student() { FirstName = "Kasper", LastName = "Dogov", Faculty = "TiD", 
                                         Course = 4, Group = 1, Birthday = 07021999});
            students.Add(new Student() { FirstName = "King", LastName = "OfNight", Faculty = "NAD", 
                                         Course = 1, Group = 10, Birthday = 07022001});

            // 3 задание: запросы LINQ
            Console.WriteLine();
            Console.WriteLine("\nСтуденты по алфавиту факультета FIT: "); // список студентов заданной специальности по алфавиту

            List<Student> stud1 = students.Where(p => p.Faculty == "FIT").ToList();
            stud1 = (from p in stud1 orderby p.LastName select p).ToList();
            foreach (var a in stud1)
            {
                a.GetInformationOfStudent();
            }
            Console.WriteLine();
            Console.WriteLine("\nСтуденты группы 4 факультета FIT: "); // список заданной учебной группы и факультета
            var stud2 = (from p in students where p.Faculty == "FIT" && p.Group == 4 select p).ToList();
            foreach (var a in stud2)
            {
                a.GetInformationOfStudent();
            }
            Console.WriteLine();
            Console.WriteLine("\nСамые молодой студент: "); // самый молодой студент
            var stud3 = from p in students orderby p.GetBirthday() select p;
            stud3.Last().GetInformationOfStudent();
            var stud4 = students.Where(p => p.Group == 4).ToList();// количество студентов заданной группы по фамилии
            stud4 = (from p in stud4 orderby p.LastName select p).ToList();
            Console.WriteLine("\nКоличесво студентов 4 группы: "); 
            Console.WriteLine(stud4.Count());
            Console.WriteLine();
            Console.WriteLine("\nСтудент King: "); // первый студент с заданным именем
            var stud5 = students.Find(p => p.FirstName == "King");
            stud5.GetInformationOfStudent();

            // 4 задание собственные методы запросов

            int[] arrI = { 1, 5, 8, 2, 9, 10, 11 };
            arrI = arrI.Sort(1).ToArray(); // сортировка по возрастанию
            int result = arrI.MeanFromMaxAndMin(); // среднее значение между максимальным и минимальным
            int []arrI2 = new int[10];
            arrI2 = arrI2.RandgeOrder().ToArray(); // генерация последовательности от 1 до count
            List<int> res = arrI2.CreateCollection(p => p > 6); // формирует список по предикату
            bool isTrue = arrI.ConditionIsTrue(p => p < 12); // проверка на условие всех элементов
            List<int> res2 = arrI.JoinCondition(arrI2, p => p < 5); // формирование списка объединения с условием
        }
    }
}