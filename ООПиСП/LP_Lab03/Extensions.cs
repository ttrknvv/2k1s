using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab03
{
    static class Extensions
    {
        /*
         * Метод расширения для получения среднего символа
         */
        public static char GetMiddleSymbol(this Passwords Password)
        {
            return Password.Password[Password.Password.Length / 2];
        }
        /*
         * Расширение метода проверки длины для string
         */
        public static bool ValidationOfSize(this string Password)
        {
            if(Password.Length > 12 || Password.Length < 6) { return false; }
            return true;
        }

    }
}
