using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab03
{
    static class StatisticOperation
    {
        /*
         * Метод суммы
         */
        public static int SummOfCodes(Passwords Password)
        {
            int summ = 0;
            for(int i = 0; i < Password.Password.Length; i++)
            {
                summ += Password.Password[i];
            }
            return summ;
        } 
        /*
         * Метод нахождения разницы между минимальным и максимальным
         */
        public static (int, int)DifferenceBetweenLandS(Passwords Password)
        {
            int max = 0;
            int min = 0;
            max = 12 - Password.Password.Length;
            min = Password.Password.Length - 6;
            return (max, min);
        }
        /*
         * Метод подсчета количества элементов
         */
        public static int CountOfElements(Passwords Password)
        {
            return Password.Password.Length;
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
