using System.ComponentModel;

namespace Students
{
    class Redefine : Object
    {
        private readonly string lastName;
        public Redefine(string lastName)
        {
            this.lastName = lastName;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            Random rand = new Random();
            for(int i = 0; i < lastName.Length; i++)
            {
                hash += lastName[i];
            }
            hash *= rand.Next(1000, 999999); 
            return (int)Math.Abs(hash * lastName.Length);
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return lastName;
        }
    }
    
    partial class ValidationOfInformation // partial класс
    {
        public static bool CheckPhoneNumber(long phoneNumber)
        {
            ushort count = 0;
            long number = phoneNumber;
            while(number != 0)
            {
                number /= 10;
                count++;
            }
            if (count != 12) return false;
            int codeOfBelarus = (int)(phoneNumber / (long)Math.Pow(10,9));
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
            int []daysInMonth = new int[] {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
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
            for(int i = 0; i < data.Length; i++)
            {
                if (data[i] < '0' || data[i] > '9') return false;
            }
            return true;
        }

    }
    class Program
    {
        static void Main(string []argC)
        {
            int choise = 1;
            int counter = 1;
            Student[] students = new Student[10];
            Redefine[] func = new Redefine[10];
            for(int i = 0; i < 10; i++)
            {
                students[i] = new Student();
            }
            var firstStudent = new { name = "Никита", lastName = "Тараканов", midleName = "Сергеевич", 
                                    course = 1, group = 4, faculty = "ФИТ", phoneNumber = 375257411803, 
                                    address = "Левкова 19", birthday = 07022004};
            students[0].FirstName = firstStudent.name; 
            students[0].LastName = firstStudent.lastName;
            func[0] = new Redefine(students[0].LastName);
            students[0].Id = func[0].GetHashCode();
            students[0].MidleName = firstStudent.midleName;
            students[0].MobileNumber = firstStudent.phoneNumber;
            students[0].Address  = firstStudent.address;
            students[0].Birthday = firstStudent.birthday;
            students[0].Faculty = firstStudent.faculty;
            students[0].Course = firstStudent.course;
            students[0].Group = (ushort)firstStudent.group;    
            AddStudent(students[1], ("Пупкин", "Вася", "Витальевич", 375445678949, "Ленина 23", "ФИТ", 1, 4, 08122005));
            AddStudent(students[2], ("Коноплянко", "Петя", "Витальевич", 375446778999, "Ленина 29", "ФИТ", 4, 1, 08082006));
            AddStudent(students[3], ("Герасимов", "Виталий", "Сергеевич", 375255898930, "Пушкина 99", "ФИТ", 4, 3, 17062002));
            AddStudent(students[4], ("Травинка", "Катя", "Ананасовна", 375295494960, "Ноутбукова 17", "ТОВ", 2, 10, 11112008));
            AddStudent(students[5], ("Речка", "Мария", "Земляновна", 375255559949, "Туалетова 11", "ХТИТ", 4, 2, 29052003));
            AddStudent(students[6], ("Камень", "Никита", "Адольфович", 375295696959, "Тракторная 45", "ФИТ", 1, 4, 30122002));
            AddStudent(students[7], ("Кофта", "Вафля", "Шоколадовна", 375294837059, "Каменная 333", "ПИТ", 2, 22, 14032009));
            AddStudent(students[8], ("Трусель", "Викентий", "Кофтович", 375296306295, "Трактир 67", "ФИТ", 1, 4, 31102003));
            AddStudent(students[9], ("Сметанова", "Мария", "Викторовна", 375251053974, "Белорусская 25", "ТОВ", 3, 9, 29062003));
            for (int i = 0; i < 10; i++)
            {
                func[i] = new Redefine(students[i].LastName);
            }
            while (choise != 0)
            {
                Console.WriteLine("1) Вывести список всех студентов");
                Console.WriteLine("2) Вывести список студентов факультета ФИТ");
                Console.WriteLine("3) Вывести список студентов 4 группы факультета ФИТ 1-го курса");
                Console.WriteLine("0) Выход из прогрыммы");
                Console.Write("Выбор: ");
                choise = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch(choise)
                {
                    case 1: outputAllStudents();
                            break;
                    case 2: outputFaculty();
                            break;
                    case 3: outputGroup();
                            break;
                    case 0: return;
                    default: Console.WriteLine("Неправильно введен выбор. Попробуйте еще раз!");
                             break;
                }
            }

            void outputGroup()
            {
                for(int i = 0; i < Student.Counter; i++)
                {
                    if (students[i].Group == 4 && students[i].Faculty == "ФИТ" && students[i].Course == 1)
                    {
                        students[i].GetInformationOfStudent();
                        Console.WriteLine();
                        Console.WriteLine(new String('-', 45));
                        Console.WriteLine();
                    }
                }
            }
            void outputAllStudents()
            {
                for(int i = 0; i < Student.Counter; i++)
                {
                    students[i].GetInformationOfStudent();
                    Console.WriteLine();
                    Console.WriteLine(new String('-', 45));
                    Console.WriteLine();
                }
            }
            void outputFaculty()
            {
                for (int i = 0; i < Student.Counter; i++)
                {
                    switch (students[i].Faculty)
                    {
                        case "ФИТ": students[i].GetInformationOfStudent();
                                    Console.WriteLine();
                                    Console.WriteLine(new String('-', 45));
                                    Console.WriteLine();
                                    break;
                        default: continue;
                    }
                }
            }
            void AddStudent(Student student, (string, string, string, long, string, string, int, ushort, long) studentInfo)
            {
                func[counter] = new Redefine(studentInfo.Item2);
                student.Id = func[counter].GetHashCode();
                counter++;
                student.FirstName = studentInfo.Item2;
                student.LastName = studentInfo.Item1;
                student.MidleName = studentInfo.Item3;
                student.MobileNumber = studentInfo.Item4;
                student.Address = studentInfo.Item5;
                student.Faculty = studentInfo.Item6;
                student.Course = studentInfo.Item7;
                student.Group = studentInfo.Item8;
                student.Birthday = studentInfo.Item9;
            }
        }
    }
}