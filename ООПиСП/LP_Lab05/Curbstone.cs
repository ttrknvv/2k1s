using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab04
{
    internal class Curbstone : Furniture, ICount
    {
        struct Details
        {
            public string KindOfTree;
            public int BestBeforeDate;
        }
        private int _count;
        private string _nameOfCurbstone;
        private Details _details;
        public Curbstone()
        {
            _details = new Details();
        }
        public string NameOfCurbstone
        {
            get
            {
                return _nameOfCurbstone;
            }
            set
            {
                _nameOfCurbstone = value;
            }
        }
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }
        public string KindOfThree
        {
            set
            {
                _details.KindOfTree = value;
            }
        }
        public int BestBeforeDate
        {
            set
            {
                _details.BestBeforeDate = value;
            }
        }
        public void GetInfoOfDetails()
        {
            Console.WriteLine("Вид дерева: " + _details.KindOfTree + " Срок годности: " + _details.BestBeforeDate + " лет"); 
        }
        public override string ToString()
        {
            return "Здесь указана информация об товаре тумба";
        }
        public override void GetInfoOfProduct()
        {
            Console.WriteLine($"Цена тумбы: {_price}/ Страна-производитель: {_nameOfFabricator}/ Дата изготовления: {DateOfManufacture}/ Название модели: {_nameOfCurbstone}/ ");
            GetInfoOfDetails();
        }
        public void Refund()
        {
            _count++;
            Console.WriteLine("Возврат успешен!");
            return;
        }
        public void Buy()
        {
            if (_count != 0)
            {
                _count--;
                Console.WriteLine("Покупка успешна!");
                return;
            }
            Console.WriteLine("Нет товарос для продажи!");

        }
    }
}
