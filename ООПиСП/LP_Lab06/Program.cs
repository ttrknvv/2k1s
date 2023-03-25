using System.Diagnostics;

namespace LP_Lab06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.FileLogger(new Exception("Недостаточно лет"));
            Logger.ConsoleLogger(new Exception("Недостаточно лет"));
            // 5 ситуаций исключений
            int number;
            try
            {
                Console.WriteLine("Введите ваш возраст: "); // 1
                number = Convert.ToInt32(Console.ReadLine());
                if(number < 18)
                {
                    throw new AgeException("Вы не достигли совершенолетия!", number);
                }

                Console.WriteLine("Введите делитель: "); // 2
                number = Convert.ToInt32(Console.ReadLine());
                if (number == 0)
                {
                    throw new InfinityException("На ноль делить нельзя!");
                }

                Console.WriteLine("Введите букву: "); // 3
                char letter = Convert.ToChar(Console.ReadLine());
                if (letter >= 'а' && letter <= 'я' || letter >= 'А' && letter <= 'Я')
                {
                    throw new CyrillicException("Символ кириллицы вводить нельзя!");
                }

                checked // 4
                {
                    int a = int.MaxValue;
                    //a++;
                }

                object obj = null; // 5
                if (obj == null)
                {
                    //throw new InfinityException("Сравнивать объекст с null нельзя!");
                }
            }
            catch(AgeException a)
            {
                a.HelpLink = "Microsoft";
                Console.WriteLine(a.Message);
                Console.WriteLine($"Недопустимое значение: {a.Value}");
                Console.WriteLine($"Время: {DateTime.Now}");
                Console.WriteLine($"Обратитесь к документации {a.HelpLink}");
                throw; // многоразовая обработка исключение и его проброс по стеку
            }
            catch(InfinityException b)
            {
                b.HelpLink = "Microsoft";
                Console.WriteLine(b.Message);
                Console.WriteLine($"Время: {DateTime.Now}");
                Console.WriteLine($"Обратитесь к документации {b.HelpLink}");
            }
            catch(NullableObjectException c)
            {
                c.HelpLink = "Microsoft";
                Console.WriteLine(c.Message);
                Console.WriteLine($"Время: {DateTime.Now}");
                Console.WriteLine($"Обратитесь к документации {c.HelpLink}");
            }
            catch(CyrillicException d)
            {
                d.HelpLink = "Microsoft";
                Console.WriteLine(d.Message);
                Console.WriteLine($"Время: {DateTime.Now}");
                Console.WriteLine($"Обратитесь к документации {d.HelpLink}");
            }
            catch(OverflowException e)
            {
                e.HelpLink = "Microsoft";
                Console.WriteLine(e.Message);
                Console.WriteLine($"Время: {DateTime.Now}");
                Console.WriteLine($"Обратитесь к документации {e.HelpLink}");
            }
            finally // блок finally
            {
                Console.WriteLine("Исправьте исключение при их наличии");
            }

            int number2 = -100;
            Debug.Assert(number2 > 0, "Exception number < 0"); // Assert
        }
    }
}