using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Lab0
{
    static class EditString
    {
        static public void ExampleAction(string a, Action<string> foo)
        {
            foo(a);
        }
        static public bool ExamplePredicate(string a, Predicate<string> foo)
        {
            return foo(a);
        }
        static public string ExampleFunc(string a, Func<string, string>foo)
        {
            return foo(a);
        } 
        public static void ShowString(string a)
        {
            Console.WriteLine(a);
        }
        public static bool FindCyrilicSymbol(string a)
        {
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] >= 'а' && a[i] <= 'я' || a[i] >= 'А' || a[i] <= 'Я')
                {
                    return true;
                }
            }
            return false;
        }
        public static bool FindNumber(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] >= '1' && a[i] <= '9')
                {
                    return true;
                }
            }
            return false;
        }
        public static string ToUpperCase(string a)
        {
            return a.ToUpper();
        }
        static public Func<string, string, string> AddString = (a, b) => a + b;
    }
}
