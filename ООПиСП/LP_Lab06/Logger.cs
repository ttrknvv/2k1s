using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab06
{
    static public class Logger
    {
        static public void FileLogger(Exception ex, int line = -1, int col = -1)
        {
            File.AppendAllText("D:\\2k1s\\ООПиСП\\LP_Lab06\\Logger.txt", "Исключение: ");
            File.AppendAllText("D:\\2k1s\\ООПиСП\\LP_Lab06\\Logger.txt", ex.Message);
            File.AppendAllText("D:\\2k1s\\ООПиСП\\LP_Lab06\\Logger.txt", $"\nСтрока: {line}, Столбец: {col}\n");
            File.AppendAllText("D:\\2k1s\\ООПиСП\\LP_Lab06\\Logger.txt", $"Время и дата: {DateTime.Now}");
        }

        static public void ConsoleLogger(Exception ex, int line = -1, int col = -1)
        {
            Console.WriteLine($"Исключение: {ex.Message}, строка: {line}, столбец: {col}");
            Console.WriteLine($"Дата и время: {DateTime.Now}");
            Console.WriteLine("Тип записи лога: ConsoleLogger");
        }
        static public void ConsoleLogger(string ex, int line = -1, int col = -1)
        {
            Console.WriteLine($"Исключение: {ex}, строка: {line}, столбец: {col}");
            Console.WriteLine($"Дата и время: {DateTime.Now}");
            Console.WriteLine("Тип записи лога: ConsoleLogger");
        }
        static public void FileLogger(string ex, int line = -1, int col = -1)
        {
            //File.Create("D:\\2k1s\\ООПиСП\\LP_Lab06\\Logger.txt");
            File.AppendAllText("D:\\2k1s\\ООПиСП\\LP_Lab06\\Logger.txt", ex);
            File.AppendAllText("D:\\2k1s\\ООПиСП\\LP_Lab06\\Logger.txt", $"\nВремя и дата: {DateTime.Now}");
            File.AppendAllText("D:\\2k1s\\ООПиСП\\LP_Lab06\\Logger.txt", $"\nСтрока: {line}, Столбец: {col}\n");
        }
    }
}
