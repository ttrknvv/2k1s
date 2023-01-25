using System.Collections.Specialized;
using static System.Net.Mime.MediaTypeNames;

namespace SE_Lab0
{
    internal class Program
    {
        public delegate void findNumb(int a1, int a2);
        static void FindMax(int a1, int a2) 
        {
            if (a1 > a2) Console.WriteLine($"max {a1}");
            else Console.WriteLine($"max {a2}");
        }
        static void FindMin(int a1, int a2)
        {
            if (a1 > a2) Console.WriteLine($"min {a2}");
            else Console.WriteLine($"min {a1}");
        }
        static void isEquals(int a1, int a2)
        {
            if (a1 - a2 == 0) Console.WriteLine($"{a1} и {a2} равны");
            else Console.WriteLine($"{a1} и {a2} не равны");
        }
        static void Main(string[] args)
        {
            findNumb a22;
            a22 = FindMax; // групповая адресация
            a22 += FindMin;
            a22 += isEquals;
            a22(2, 3);  
            
            ProgrammerLanguage language1 = new ProgrammerLanguage() { AgeOfCreateLanguage = 1985, NameLanguage = "C++", TehnologiesLanguage = "Функциональное, ООП", VersionLanguage = "C++17" };
            ProgrammerLanguage language2 = new ProgrammerLanguage() { AgeOfCreateLanguage = 1972, NameLanguage = "C", TehnologiesLanguage = "Функциональное, ООП", VersionLanguage = "C99" };
            ProgrammerLanguage language3 = new ProgrammerLanguage() { AgeOfCreateLanguage = 1998, NameLanguage = "C#", TehnologiesLanguage = "ООП", VersionLanguage = "C#5.0" };
            Programmer programmer1 = new Programmer();

            programmer1.NewProperty += language1.OnNewProperties; // подписка на событие NewProperties
            programmer1.NewProperty += language2.OnNewProperties;
            programmer1.NewProperty += language3.OnNewProperties;
            programmer1.ChangeVersion();

            Console.WriteLine("Поменявшиеся версии языков:");
            Console.WriteLine($"{language1.NameLanguage} : {language1.VersionLanguage}");
            Console.WriteLine($"{language2.NameLanguage} : {language2.VersionLanguage}");
            Console.WriteLine($"{language3.NameLanguage} : {language3.VersionLanguage}");

            string[] name = { language1.NameLanguage, language2.NameLanguage, language3.NameLanguage };

            Console.WriteLine();

            programmer1.Rename += language1.OnRename; // подписка на событие rename
            programmer1.Rename += language2.OnRename;
            programmer1.Rename += language3.OnRename;
            programmer1.RenameLanguage();

            Console.WriteLine("Поменявшиеся названия языков:");
            Console.WriteLine($"С названия {name[0]} на {language1.NameLanguage}");
            Console.WriteLine($"С названия {name[1]} на {language2.NameLanguage}");
            Console.WriteLine($"С названия {name[2]} на {language3.NameLanguage}");
            ProgrammerLanguage Older = programmer1.GetOldLanguage(language1, language2);

            string a = "НИКИТА маша САША пАшА 123";
            EditString.ExampleAction(a, EditString.ShowString); // 1

            bool f = EditString.ExamplePredicate(a, EditString.FindCyrilicSymbol); // 2
            if (f) Console.WriteLine("Криллица есть");
            else Console.WriteLine("Криллицы нет");

            f = EditString.ExamplePredicate(a, EditString.FindNumber); // 3
            if (f) Console.WriteLine("Цифра есть");
            else Console.WriteLine("Цифр нет");

            string example1 = EditString.ExampleFunc(a, EditString.ToUpperCase); // 4
            string example2 = EditString.AddString(a, example1); // 5
        }
    }
}