using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LP_Lab09_
{
    internal class Services : IOrderedDictionary<int, string>//  класс услуги
    {
        private string _firstNameClient; // имя владельца услуги
        private string _lastNameClient; // фамилия
        private string _middleNameClient; // отчество
        private static int _countClients = 0; // количество владельцев услуг
        private int _countServices = 0; // количество сервисов у клиента
        private static string[] _dictionaries = new string[3] { "Словарь русского языка",
            "Словарь английского языка", "Словарь китайского языка" }; // наличие словарей
        private static string[] _dictionariesProperties= new string[3]{"Обложка", "Закладка", 
                                                "Картонная обложка"}; // наличие аксесуаров
        private string _boughtDictionary;
        private string _boughtProperties;
        private CompanyServices[] _services = new CompanyServices[5]; // массив сервисов
        
        public Services() { }
        public Services(string firstNameOwner, string lastNameOwner, string middleNameOwner)
        {
            _firstNameClient = firstNameOwner;
            _lastNameClient = lastNameOwner;
            _middleNameClient = middleNameOwner;
        }
        ~Services() { }
        public string FirstNameClient
        {
            get { return _firstNameClient; }
            set { _firstNameClient = value; }
        } // свойства: фамилия, имя, отчество, количество владельцев
        public string LastNameClient
        {
            get { return _lastNameClient; }
            set { _lastNameClient = value; }
        }
        public string MiddleNameClient
        {
            get { return _middleNameClient; }
            set { _middleNameClient = value; }
        }
        public int CountClients
        {
            get { return _countClients; }
        }
        public int CountServices
        {
            get { return _countServices; }
        }
        public string BoughtDictionary
        {
            get
            {
                if(_boughtDictionary == null )
                {
                    Console.Write("Не приобрел словарь!");
                    return null;
                }
                else
                {
                    return _boughtDictionary;
                }
            }
        } // купленный словарь
        public string BoughtProperties
        {
            get
            {
                if (_boughtDictionary == null)
                {
                    Console.Write("Не приобрел аксесуар!");
                    return null;
                }
                else
                {
                    return _boughtProperties;
                }
            }
        } // купленный аксесуар
        public void GetServices()
        {
            Console.WriteLine("Выберите услугу из списка: ");
            Console.Write($"1) Купить словарь\n 2) Продать словарь\n 3) Найти подходящий словарь\n 4) Купить акссесуары к словарю");
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());
            switch ((CompanyServices)choice)
            {
                case CompanyServices.BuyDictionary: _services[_countServices++] = CompanyServices.BuyDictionary;
                                                    PrintDictionaries();
                                                    Console.WriteLine("Выберите словарь для покупки: ");
                                                    BuyDictionary(Convert.ToInt32(Console.ReadLine()));
                                                    break;
                case CompanyServices.SellDictionary: _services[_countServices++] = CompanyServices.SellDictionary;
                                                     Console.WriteLine("Введите имя словаря, чтобы его продать:");
                                                     SellDictionary(Console.ReadLine());
                                                     break;
                case CompanyServices.FindDictionary: _services[_countServices++] = CompanyServices.FindDictionary;
                                                     Console.WriteLine("Введите название словаря: ");
                                                     FindDictionary(Console.ReadLine());
                                                     break;
                case CompanyServices.BuyPropertyForDictionary: _services[_countServices++] = CompanyServices.BuyPropertyForDictionary;
                                                               PrintProperties();
                                                               BuyPropertiesForDictionary(Convert.ToInt32(Console.ReadLine()));
                                                               break;
                default: throw new Exception("Invalid choise"); 
                         break;
            }
            return;
        } // метод выводящий допустимые сервисы
        private void PrintDictionaries()
        {
            Console.WriteLine("Доступные словари:");
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1}) {_dictionaries[i]}");
            }
        } // вывести список словарей
        public void BuyDictionary(int key)
        {
            if(key < 1 || key > 3)
            {
                throw new Exception("Invalid choise");
                return;
            }
            Console.WriteLine($"Словарь {_dictionaries[key - 1]} куплен.");
            _boughtDictionary = _dictionaries[key - 1];
        } // купить словарь
        public void SellDictionary(string name)
        {
            if(_boughtDictionary == null)
            {
                throw new Exception("No dictionaries");
                return;
            }
            for(int i = 0; i < 3; i++)
            {
                if (_dictionaries[i] == name)
                {
                    Console.WriteLine($"Словарь {_boughtDictionary} успешно продан");
                    return;
                }
            }
            Console.WriteLine("У вас нет такого словаря!");
            return;
        } // продать словарь
        private void PrintProperties()
        {
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1}) {_dictionariesProperties[i]}");
            }
        } // вывести аксесуары
        public void BuyPropertiesForDictionary(int key)
        {
            if (key < 1 || key > 3)
            {
                throw new Exception("Invalid choise");
                return;
            }
            Console.WriteLine($"Аксесуар {_dictionariesProperties[key - 1]} куплен.");
            _boughtProperties = _dictionariesProperties[key - 1];
        } // купить аксесуар
        public void FindDictionary(string name)
        {
            for(int i = 0; i < 3; i++)
            {
                if (_dictionaries[i] == name)
                {
                    Console.WriteLine($"Словарь {name} найден!");
                    return;
                }
            }
            throw new Exception("No dictionary");
        } // найти словарь
        public void ForEvent(object o1, EventArgs e) // обработчик
        {
            //queue.InputQueue(element);
            Console.WriteLine("Элемент успешно добавлен!");
        }
        public override string ToString()
        {
            return "Сервисы доступные пользователю.";
        }
        private enum CompanyServices{BuyDictionary = 1, SellDictionary = 2, FindDictionary = 3, BuyPropertyForDictionary = 4 };
    }
}
