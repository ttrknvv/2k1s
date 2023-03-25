using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab04
{
    internal class SlidingWardrobe : Furniture, ICount
    {
        private int _count;
        private string _nameOfSlidingWardrobe;
        public string NameOfBed
        {
            get
            {
                return _nameOfSlidingWardrobe;
            }
            set
            {
                _nameOfSlidingWardrobe = value;
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
            return "Здесь указана информация об товаре шкаф- купе";
        }
        public override void GetInfoOfProduct()
        {
            Console.WriteLine($"Цена шкафа- купе: {_price}/ Страна-производитель: {_nameOfFabricator}/ Дата изготовления: {DateOfManufacture}/ Название модели: {_nameOfSlidingWardrobe}");
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
