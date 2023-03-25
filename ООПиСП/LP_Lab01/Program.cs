using System;
using System.Text;

/*
 * Типы данных, массивы, кортежи, строки
 */

namespace Project
{
    class Program
    {
        static string _LineStr = "Я поле с _";
        static void Main(string[] args )
        {
            Console.WriteLine("\tТипы данных"); // a, b(convert)

            // Числовые типы (целочисленные)
            Console.WriteLine("Введите переменную типа Byte");
            byte bvalue = 0;
            bvalue = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + bvalue);

            Console.WriteLine("Введите переменную типа Sbyte");
            sbyte sbvalue = 127;
            sbvalue = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + sbvalue);

            Console.WriteLine("Введите переменную типа Uint16");
            ushort usvalue = 0;
            usvalue = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + usvalue);

            Console.WriteLine("Введите переменную типа Int16");
            short svalue = -32768;
            svalue = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + svalue);

            Console.WriteLine("Введите переменную типа Uint32");
            uint uivalue = 0;
            uivalue = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + uivalue);

            Console.WriteLine("Введите переменную типа Int32");
            int ivalue = -2147483648;
            ivalue = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + ivalue);

            Console.WriteLine("Введите переменную типа IntPTR)");
            nint nivalue = -2147483648;
            nivalue = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + nivalue);

            Console.WriteLine("Введите переменную типа UIntPTR");
            nuint nuivalue = 0;
            nuivalue = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + nuivalue);

            Console.WriteLine("Введите переменную типа UInt64");
            ulong ulvalue = 0;
            ulvalue = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + ulvalue);

            Console.WriteLine("Введите переменную типа Int64");
            long lvalue = -9223372036854775808;
            lvalue = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + lvalue);

            // Символьные типы 
            Console.WriteLine("Введите переменную типа Char");
            char cvalue = ' ';
            cvalue = Convert.ToChar(Console.ReadLine()); ;
            Console.WriteLine("Ваши введенные данные: " + cvalue);

            Console.WriteLine("Введите переменную типа String");
            string stvalue = "   ";
            stvalue = Console.ReadLine();
            Console.WriteLine("Ваши введенные данные: " + stvalue); // контакенация

            // Числовые типы (с плавающей запятой)

            Console.WriteLine("Введите переменную типа Single");
            float fvalue = -3.40282347E+38F;
            fvalue = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + fvalue);

            Console.WriteLine("Введите переменную типа Double");
            double dvalue = -1.7976931348623157E+308;
            dvalue = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + dvalue);

            Console.WriteLine("Введите переменную типа Decimal");
            decimal devalue = -7;
            devalue = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + devalue);

            Console.WriteLine("Введите переменную типа Boolean");
            bool bovalue = false;
            bovalue = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Ваши введенные данные: " + bovalue);

            // Особые типы
            Console.WriteLine("Введите переменную типа Object");
            object ovalue = 5;
            ovalue = Console.ReadLine();
            Console.WriteLine("Ваши введенные данные: " + fvalue);

            Console.WriteLine("Введите переменную типа Dynamic");
            dynamic dyvalue = 5;
            dyvalue = Console.ReadLine();
            Console.WriteLine("Ваши введенные данные: " + dyvalue);

            // явные преобразования

            int transform = (int)bvalue;
            int transform2 = (int)lvalue;
            short transform3 = (short)bvalue;
            ushort transform4 = (ushort)cvalue;
            byte transform5 = (byte)sbvalue;

            // неявные преобразования

            int implict = cvalue;
            double implict2 = fvalue;
            decimal implict3 = ivalue;
            int implict4 = svalue;
            float implict5 = bvalue;

            // упаковка

            int variable = 255;
            object packing = variable;

            // распаковка

            int unpacking = (int)packing;

            // неявно типизированные переменные

            var imvar = 5;
            var imvar2 = new float[9];
            var imvar3 = "Hello World!!!";
            Console.WriteLine("Введите неявно типизированную переменную(цифру): ");
            var imvar4 = Convert.ToInt16(Console.ReadLine());

            // Nullable переменная

            string str = null;
            object nullablevar = null;
            dynamic nullablevar2 = null;

            Nullable<int> varnot = null;
            int ?varaible = null; // проще
            short? variable2 = null;
            long? variable3 = null;

            bool varboo = varaible.HasValue;
            // varaible.Value; // ошибка

            Console.WriteLine(varaible == null);
            Console.WriteLine(varaible.HasValue);
            Console.WriteLine(varaible.GetValueOrDefault(-1));
            Console.WriteLine(varaible ?? -2);

            int first = 24;
            int? result = first + varaible;
            bool firstboo = varaible > first;
            bool firstboo2 = varaible < first;
            bool firstboo3 = varaible == first;

            // присвоение var другого типа

            // imvar = 5.3;  - ошибка

            // Строки

            Console.WriteLine("\tСтроки:");

            string stro1 = "Line first";
            string stro2 = "Line second";

            // Сравнение строк

            if(stro1.Length > stro2.Length)
            {
                Console.WriteLine("stro1 < stro2");
            }
            else if(stro1.Length < stro2.Length)
            {
                Console.WriteLine("stro2 > stro1");
            }
            else
            {
                Console.WriteLine("stro1 == stro2");
            }

            int comparestr = String.Compare(stro1, stro2); // -1

            // сцепление, копирование, выделение подстроки, разделение строки на слова .....

            string Line1 = "Привет    Мир!!!";
            string Line2 = "Меня зовут Никита Тараканов";
            string Line3 = "Мир";

            string Line00 = Line1 + Line3; // сцепление
            string Line01 = String.Concat(Line1, Line3); // -||-
            string Line02 = String.Join(' ', Line1, Line2, Line3); // -||-

            string Line10 = (string)Line1.Clone(); // копирование
            string Line11 = String.Copy(Line1); // -||- устаревшее
            char[] arr = new char[8]; 
            Line1.CopyTo(0, arr, 0, 7); // -||-

            string Line20 = Line1.Substring(0, 5); // выделение подстроки
           Console.WriteLine(Line1.Contains(Line3)); // -||-

            string []Line30 = Line1.Split(' ', StringSplitOptions.RemoveEmptyEntries); // разделение на слова

            string Line40 = Line2.Insert(0, Line3); // вставка подстроки в заданную позицию

            string Line50 = Line2.Remove(0, 5); // удаление подстроки

            Console.WriteLine($"Вы вводили значения: Decimal - {devalue}"); // интерполирование строк

            // метод String.IsNullOrEmpty

            string Line60 = null;
            string Line61 = "      ";

            Console.WriteLine(String.IsNullOrEmpty(Line60)); // true
            Console.WriteLine(String.IsNullOrEmpty(Line61)); // false
            Console.WriteLine(String.IsNullOrWhiteSpace(Line61)); // true

            // StringBuilder

            var text = new StringBuilder("Hello, World!!! My name's Nikita", 60);
            text.Remove(13, 2);
            text.Insert(0, "Mister, ");
            text.Replace("Nikita", "Никита");
            text.Append(", I am programmer");

            // Массивы

            int[,] matrix = new int[3, 3] { { 0, 1, 2 },
                                            { 3, 4, 5 },
                                            { 6, 7, 8 } };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Массив string

            string[]arrSTR = new string[5] { "Петя", "Nikita", "Katya", "Masha", "Sasha" };
            foreach (string s in arrSTR)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine("Длина массива{0}", arrSTR.Length);
            Console.WriteLine("Выберите элемент, который надо поменять: ");
            int check = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Введите строку: ");
            arrSTR[check] = Console.ReadLine();

            // Ступенчатый(зубчатый) массив

            float[] Arr01 = new float[2];
            float[] Arr02 = new float[3];
            float[] Arr03 = new float[4];
            float[][] Arr00 = new float[3][] { Arr01, Arr02, Arr03 };
            for (int i = 0; i < Arr00.Length; i++)
            {
                for (int j = 0; j < Arr00[i].Length; j++)
                {
                    Console.WriteLine("Y: {0} X: {1}", i, j);
                    Arr00[i][j] = int.Parse(Console.ReadLine());
                }
            }

            // Неявно типизированный массив

            var Arr20 = new[] {1, 2, 3};
            var Arr21 = new[] { "Pasha", "Kasper", "Mitya" };

            // Кортежи

            var kortezh1 = (1, "Masha", 'a', "Petya", (ulong)50);
            var kortezh2 = (1, 2);
            var kortezh3 = (1, 2);
            // (int, string, char, string, ulong) kortezh = (...);
            Console.WriteLine(kortezh1.Item1);
            Console.WriteLine(kortezh1.Item2);
            Console.WriteLine(kortezh1.Item3);
            Console.WriteLine(kortezh1.Item4);
            Console.WriteLine(kortezh1.Item5);

            Console.WriteLine(kortezh1.Item3);
            Console.WriteLine(kortezh1.Item5);

            (var kortezh21, var kortezh31) = ("sss", 25);
            var (kortrzh3, kortezh4) = (1, 5);
            int number0 = kortezh1.Item1;

            Console.WriteLine(kortezh3 == kortezh2);
            Console.WriteLine(kortezh3 != kortezh2);

            Console.WriteLine(_LineStr);

            // Локальная функция

            int[] arr22 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string str99 = "NIKITA";
            (int, int, int, char) func(int[] arr, string line)
            {
                return (arr.Max(), arr.Min(), arr.Sum(), (char)line[0]);
            }
            var result2 = func(arr22, str99);

            // checked/ unchecked

            void func2()
            {
                checked
                {
                    int maxi = Int32.MaxValue;
                    // maxi++;
            }
                return;
            }
            void func3()
            {
                unchecked
                {
                    int maxi = Int32.MaxValue;
                    maxi++;
                }
                return;
            }
            func2();
            func3();

        }
    }
}