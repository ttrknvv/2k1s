using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SE_Lab07
{
    static class StatisticOperation
    {
        /*
         * Метод суммы
         */
        public static int SummOfCodes<U>(U Password) where U : Passwords
        {
            int summ = 0;
            Passwords a = Password as Passwords;
            for (int i = 0; i < a.Password.Length; i++)
            {
                summ += a.Password[i];
            }
            return summ;
        } 
        /*
         * Метод нахождения разницы между минимальным и максимальным
         */
        public static (int, int)DifferenceBetweenLandS<U>(U[] Password) where U : Passwords
        {
            Passwords a = Password as Passwords;
            int max = 0;
            int min = 0;
            max = 12 - a.Password.Length;
            min = a.Password.Length - 6;
            return (max, min);
        }
        /*
         * Метод подсчета количества элементов
         */
        public static int CountOfElements<U>(U Password) where U : Passwords
        {
            Passwords a = Password as Passwords;
            return a.Password.Length;
        }
        /*
         * Метод расщирения для типа string
         */
        public static string[] ToArrayString(this string str)
        {
            string[] str2 = str.Split(' ');
            return str2;
        }
        /*
         * Метод расширения для класса Passwords
         */
        public static string Encryption(this Passwords Password)
        {
            string stars = new string('*', Password.Password.Length);
            return stars;
        }

    }
}
