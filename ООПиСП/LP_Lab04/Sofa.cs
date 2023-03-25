using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab04
{
    internal class Sofa : Furniture, ICount
    {
        private int _count;
        private string _nameOfSofa;
        public string NameOfBed
        {
            get
            {
                return _nameOfSofa;
            }
            set
            {
                _nameOfSofa = value;
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
        public override string ToString()
        {
            return "Здесь указана информация об товаре диван";
        }
        public override void GetInfoOfProduct()
        {
            Console.WriteLine($"Цена дивана: {_price}/ Страна-производитель: {_nameOfFabricator}/ Дата изготовления: {DateOfManufacture}/ Название модели: {_nameOfSofa}");
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
