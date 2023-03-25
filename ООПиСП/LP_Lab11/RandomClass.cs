using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab11
{
    public class RandomClass : MyInterface
    {
        private int _myFieldPrivate;
        public int _myFieldPublic;
        private int MyPropertyPrivate
        {
            get { return _myFieldPrivate; }
        }
        public int MyPropertyPublic
        {
            get { return _myFieldPublic; }
        }
        private RandomClass(int a) { }
        public RandomClass() { }
        public RandomClass(string a) { }
        public void myPublicMethod()
        {
            Console.WriteLine("Я public метод!");
        }
        private void myPrivateMethod()
        {
            Console.WriteLine("Я private метод!");
        }
        public void MethodInterface()
        {
            Console.WriteLine("Метод от интерфейса!");
        }
        public void ExampleDouble(double a, double b, int c)
        {
            Console.WriteLine("Метод с параметров double");
            Console.WriteLine($"Сумма всех элементов: {a + b + c}");
        }
    }
}
