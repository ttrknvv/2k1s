using System;
using System.Text;

namespace LP_Lab03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Passwords password1 = new Passwords("1234test");
            Passwords password2 = new Passwords("test1234");
            Passwords password3 = new Passwords("74118ttrkn");
            Passwords password4 = new Passwords("9876tarak");
            Passwords password5 = new Passwords("nikit5460");
            Console.WriteLine(new string('-', 50) + "\nТестирование приложения\n" + new string('-', 50));
            Console.WriteLine("Использование перегруженных операторов:");

            ////////////////////////////////////////////////////////////////////////////
            ///
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Использование - (замена последнего символа) :");
            Console.WriteLine($"Исходный пароль: {password1.Password}");
            password1.Password = password1 - 'a';
            Console.WriteLine($"Пароль - 'a': {password1.Password}");

            ////////////////////////////////////////////////////////////////////////////

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Использование > < (сравнение длин паролей) :");
            Console.Write($"Исходные сравнения: {password1.Password} > {password3.Password} : ");
            Console.WriteLine(password1 > password3);
            Console.Write($"Исходные сравнения: {password1.Password} < {password3.Password} : ");
            Console.WriteLine(password1 < password3);

            ////////////////////////////////////////////////////////////////////////////

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Использование == != (проверка паролей на неравенство/ равенство) :");
            Console.Write($"Исходные сравнения: {password2.Password} == {password4.Password} : ");
            Console.WriteLine(password1 == password3);
            Console.Write($"Исходные сравнения: {password2.Password} != {password4.Password} : ");
            Console.WriteLine(password1 != password3);

            ////////////////////////////////////////////////////////////////////////////

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Использование ++ (сброс пароля по умолчанию) :");
            Console.WriteLine($"Исходные данные: {password3.Password} : ");
            password3 = password3++;
            Console.WriteLine("после ++ : " + password3.Password);

            ////////////////////////////////////////////////////////////////////////////

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Использование true / false (проверка на стройкость) :");
            if (password5) { Console.WriteLine("Стойкий!"); }
            else { Console.WriteLine("Нестойкий!"); }

            ////////////////////////////////////////////////////////////////////////////

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Использование расширенного метода выделения среднего символа пароля: ");
            Console.WriteLine($"Исходные данные: {password4.Password}");
            Console.WriteLine("Средний символ: " + password4.GetMiddleSymbol());

            ////////////////////////////////////////////////////////////////////////////

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Использование расширенного метода проверка допустимой длины пароля: ");
            Console.WriteLine($"Исходные данные: {password4.Password}");
            Console.WriteLine("Проверка: " + password4.Password.ValidationOfSize());

            ////////////////////////////////////////////////////////////////////////////
            // Инициализация вложенного класса
            Passwords.Developer develops = new Passwords.Developer(1, "Никита", "4 group", 3);
            develops[0] = password1;

            ////////////////////////////////////////////////////////////////////////////

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Использование использование методов из : StaticticOperation");
            Console.WriteLine($"Метод суммы кодировок пароля {password1.Password} : " + StatisticOperation.SummOfCodes(password1));
            Console.WriteLine($"Метод разницы между макс и мин длинами пароля {password1.Password} : " + StatisticOperation.DifferenceBetweenLandS(password1));
            Console.WriteLine($"Метод подсчета количества символов в пароле {password1.Password} : " + StatisticOperation.CountOfElements(password1));

            ////////////////////////////////////////////////////////////////////////////

            Console.WriteLine(new string('-', 50));
            string str = "бегу БЕГУ я Я быстро БЫСТРО";
            string[] str2 = str.ToArrayString(); 
            Console.WriteLine("Еще один метод расширения для string: ");
            Console.WriteLine($"Входные данные: {str}"); ;
            Console.WriteLine("Выходные данные(массив): ");
            foreach (var c in str2) { Console.WriteLine(c); }

            Console.WriteLine("Метод расщирения для типа Passwords: ");
            Console.WriteLine($"Входные данные {password1.Password}");
            Console.WriteLine("Выходные данные: " + password1.Encryption());

            Console.ReadKey();
        }
    }
}