using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab03
{
    internal class Passwords
    {
        /*
         * Конструктор
         */
        public Passwords() { _password = ""; }
        /*
         * Перегруженный онструктор
         */
        public Passwords(string Password)
        {
            if(Password.ValidationOfSize()) { _password = Password; }
            else { Console.WriteLine("Incorrect password size"); }
        }
        /*
         * Деструктор
         */
        ~Passwords() { }
        /*
         * Перегруженный оператор -
         */
        public static string operator - (Passwords Password, char Symbol)
        {
            string str;
            str = Password.Password.Remove(Password.Password.Length - 1);
            str += Symbol;
            return str;
        }
        /*
         * Перегруженный оператор >
         */
        public static bool operator > (Passwords Password1, Passwords Password2)
        {
            if (Password1.Password.Length > Password2.Password.Length) { return true; }
            return false;
        }
        /*
         * Перегруженный оператор <
         */
        public static bool operator < (Passwords Password1, Passwords Password2)
        {
            if (Password1.Password.Length < Password2.Password.Length) { return true; }
            return false;
        }
        /*
         * Перегруженный оператор != 
         */
        public static bool operator != (Passwords Password1, Passwords Password2)
        {
            return !(Password1.Password.Length == Password2.Password.Length);
        }
        /*
         * Перегруженный оператор == 
         */
        public static bool operator == (Passwords Password1, Passwords Password2)
        {
            return Password1.Password.Length == Password2.Password.Length;
        }
        /*
         * Перегруженный оператор ++
         */
        public static Passwords operator ++ (Passwords Password)
        {
            Password.Password = "00000000";
            return Password;
        }
        /*
         * Перегрузка оператора true
         */
        public static bool operator true (Passwords Password)
        {
            int number = 0;
            int letter = 0;
            for (int i = 0; i < Password.Password.Length; i++)
            {
                if (Password.Password[i] >= '0' && Password.Password[i] <= '9') 
                { 
                    number++;
                    continue;
                }
                letter++;
            }
            if (number < 4 || letter < 4) { return false; }
            return true;
        }
        /*
         * Перегрузка оператора false
         */
        public static bool operator false (Passwords Password)
        {
            int number = 0;
            int letter = 0;
            for (int i = 0; i < Password.Password.Length; i++)
            {
                if (Password.Password[i] >= '0' && Password.Password[i] <= '9')
                {
                    number++;
                    continue;
                }
                letter++;
            }
            if (number > 4 || letter > 4) { return true; }
            return false;
        }
        public void PrintPassword()
        {
            Console.WriteLine($"Пароль: {_password}");
        }
        /*
         * Свойства для поля _password
         */
        public string Password
        {
            get { return _password; }
            set 
            { 
                if(value.ValidationOfSize()) { _password = value; }
                else { Console.WriteLine("Incorrect password size"); }
            }
        }
        private string _password;
        Production Product = new Production(199, "БЕЛАЗ"); // вложенный объект
        /*
         * Вложенный класс
         */
        class Production
        {
            public Production(int id, string nameOfOrganization)
            {
                _id = id;
                _nameOfOrganization = nameOfOrganization;
            }
            public int Id
            {
                get
                {
                    return _id;
                }
                set
                {
                    _id = value;
                }
            }
            public string NameOfOrganization
            {
                get
                {
                    return _nameOfOrganization;
                }
                set
                {
                    _nameOfOrganization = value;
                }
            }
            private int _id;
            private string _nameOfOrganization;
        }
        /*
         *  Вложенный класс Developer
         */
        public class Developer
        {
            public Developer(int id, string name, string division, int size)
            {

                _id = id;
                _nameOfDeveloper = name;
                _division = division;
                Password = new Passwords[size];
                _size = size;
            }

            /*
             * Индексатор
             */
            public Passwords this[int i]
            {
                get
                {
                    if(i >= 0 &&  i < _size) { return Password[i]; }
                    else 
                    { 
                        Console.WriteLine("Error!");
                        return null;
                    }
                }
                set
                {
                    if (i >= 0 && i < _size) { Password[i] = value; };
                }
            }
            public string NameOfDeveloper
            {
                get
                {
                    return _nameOfDeveloper;
                }
                set
                {
                    _nameOfDeveloper = value;
                }
            }
            public string Division
            {
                get
                {
                    return _division;
                }
                set
                {
                    _division = value;
                }
            }
            public int Id
            {
                get
                {
                    return _id;
                }
                set
                {
                    _id = value;
                }
            }
            private Passwords []Password;
            private int _size;
            private string _nameOfDeveloper;
            private int _id;
            string _division;
        }
    }
}
