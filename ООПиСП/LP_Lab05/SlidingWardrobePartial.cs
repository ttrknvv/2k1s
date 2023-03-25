using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab04
{
    partial class SlidingWardrobe : Furniture, ICount
    {
        public override partial string ToString()
        {
            return "Здесь указана информация об товаре шкаф- купе";
        }
        public override partial void GetInfoOfProduct()
        {
            Console.WriteLine($"Цена шкафа- купе: {_price}/ Страна-производитель: {_nameOfFabricator}/ Дата изготовления: {DateOfManufacture}/ Название модели: {_nameOfSlidingWardrobe}");
        }
        public partial void Refund()
        {
            _count++;
            Console.WriteLine("Возврат успешен!");
            return;
        }
        public partial void Buy()
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
