using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab10
{
    partial class ValidationOfInformation
    {
        public static bool CheckPhoneNumber(long phoneNumber)
        {
            ushort count = 0;
            long number = phoneNumber;
            while (number != 0)
            {
                number /= 10;
                count++;
            }
            if (count != 12) return false;
            int codeOfBelarus = (int)(phoneNumber / (long)Math.Pow(10, 9));
            int codeOfOperator = (int)(phoneNumber / (long)Math.Pow(10, 7) - codeOfBelarus * 100);

            if (codeOfBelarus == 375 && (codeOfOperator == 33 || codeOfOperator == 29
                || codeOfOperator == 44 || codeOfOperator == 25)) return true;
            return false;
        }
        public static bool CheckBirthday(long date)
        {
            ushort count = 0;
            ushort year = (ushort)(date % 10000);
            ushort month = (ushort)((date - (long)year) / 10000 % 100);
            ushort day = (ushort)((date - ((long)month * 10000 + (long)year)) / Math.Pow(10, 6));
            int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (year % 400 == 0 && year % 100 != 0 || year % 4 == 0) daysInMonth[1] = 29;
            long date2 = date + (long)Math.Pow(10, 7);
            while (date2 != 0)
            {
                date2 /= 10;
                count++;
            }
            if (count != 8) return false;
            if (month > 12 || month < 1 || day < 1 || day > daysInMonth[month - 1]) return false;
            return true;
        }
        public static bool CheckCourse(long course)
        {
            if (course > 4 || course < 1) return false;
            return true;
        }
        public static bool CheckNumberData(string data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] < '0' || data[i] > '9') return false;
            }
            return true;
        }
    }
}
