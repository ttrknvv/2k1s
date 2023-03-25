using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Student
    {
        static Student()
        {
            Console.WriteLine("В данной программе хранится информация об студентах!");
            _counter = 0;
        } // static конструктор
        public Student()
        {
            _counter++;
            _lastName = null;
            _firstName = null;
            _midleName = null;
            _birthday = null;
            _address = null;
            _mobileNumber = null;
            _faculty = null;
            _course = null;
            _group = null;
            _numberOfStudent = Counter;
        } // конструктор
        //private Student(string lastName, string firstName, string midleName, DateTime birthday, string address, ulong mobileNumber,string faculty, string course, string group )
        //{
        //    const string _university = "BSTU";
        //    _counter++;
        //    _lastName = lastName;
        //    _firstName = firstName;
        //    _midleName = midleName;
        //    _id = lastName.GetHashCode();
        //    _birthday = birthday;
        //    _address = address;
        //    _mobileNumber = mobileNumber;
        //    _faculty = faculty;
        //    _course = course;
        //    _group = group;
        //}
        /*public Student(string? lastName = null, DateTime? birthday = null, ulong? mobileNumber = null)
        {
            _counter++;
            _lastName = lastName;
            _birthday = birthday;
            _mobileNumber = mobileNumber;
        }*/
        
        ~Student() 
        {
            Console.WriteLine("Спасибо за использавание нашей программы!");
        } // деструктор
        static void GetInformation()
        {
            Console.WriteLine("Информация о студентах БГТУ!");
        }
        public int GetAge(DateTime birthday)
        {
            return DateTime.Now.Year - birthday.Year;
        }
        public void GetInformationOfStudent()
        {
            DateTime birthdayDay = (DateTime)_birthday; 
            Console.WriteLine($"Уникальный номер: {_id}");
            Console.WriteLine($"ФИО: {_lastName} {_firstName} {_midleName}");
            Console.WriteLine($"Факультет: {_faculty} Курс: {_course} Группа: {_group}");
            Console.WriteLine($"Адрес: {_address}");
            Console.WriteLine($"Мобильный телефон: {_mobileNumber}");   
            Console.WriteLine($"Год рождения: " + birthdayDay.ToShortDateString() + " Возраст: " + GetAge((DateTime)_birthday));
        }
        public void GetId(out int id)
        {
            id = (int)_id;
        } // out
        public void GetGroup(ref int group)
        {
            group = (int)_group;
        } // ref

        public string LastName
        {
            get { return _lastName; }
            set 
            {
                _lastName = value; 
            }
        } // get и set
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string MidleName
        {
            get { return _midleName; }
            set { _midleName = value; }
        }
        public int Id
        {
            get { return (int)_id; }
            set { _id = value; }
        }
        public long Birthday
        {
            set
            {
                while (!ValidationOfInformation.CheckBirthday(value))
                {
                    Console.WriteLine("Неправильно введены данные. Попробуйте еще раз.");
                    value = Convert.ToInt64(Console.ReadLine());
                }
                ushort year = (ushort)(value % 10000);
                ushort month = (ushort)((value - (long)year) / 10000 % 100);
                ushort day = (ushort)((value - ((long)month * 10000 + (long)year)) / Math.Pow(10, 6));
                _birthday = new DateTime(year, month, day);
            }
        }
        public DateTime GetBirthday()
        {
            return (DateTime)_birthday;
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public long MobileNumber
        {
            get { return (long)_mobileNumber; }
            set
            {
                while (!ValidationOfInformation.CheckPhoneNumber(value))
                {
                    Console.WriteLine("Неправильно введены данные. Попробуйте еще раз.");
                    value = Convert.ToInt64(Console.ReadLine());
                }
                _mobileNumber = (ulong)value;
            }
        }
        public string Faculty
        {
            get { return _faculty; }
            set { _faculty = value; }
        }
        public long Course
        {
            get { return (long)_course; }
            set
            {
                while(!ValidationOfInformation.CheckCourse(value))
                {
                    Console.WriteLine("Неправильно введены данные. Попробуйте еще раз.");
                    value = Convert.ToInt64(Console.ReadLine());
                }
                _course = (ushort)value;
            }
        }
        public ushort Group
        {
            get { return (ushort)_group; }
            set { _group = value; }
        }
        public static int Counter
        {
            get { return _counter; }
        }


        const int _a = 0;
        private static int _counter;  // static поле
        private string? _lastName; // private поля
        private string? _firstName;
        private string? _midleName;
        private readonly int _numberOfStudent;
        private int? _id;
        private DateTime? _birthday = new DateTime();
        private string? _address;
        private ulong ?_mobileNumber;
        private string ?_faculty;
        private ushort ?_course;
        private ushort ?_group;
    }
}
