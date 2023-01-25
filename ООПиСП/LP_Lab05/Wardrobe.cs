using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab04
{
    internal class Wardrobe : Furniture, ICount
    {
        new private static int _personalID = 1;
        private int _count;
        private string _nameOfWardrobe;
        public Wardrobe() { Furniture._personalID = 1; }
        static public int PersonalID
        {
            get { return Wardrobe._personalID; }
        }
        public string NameOfWardrobe
        {
            get
            {
                return _nameOfWardrobe;
            }
            set
            {
                _nameOfWardrobe = value;
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
            return "Здесь указана информация об товаре шкаф";
        }
        public override void GetInfoOfProduct()
        {
            Console.WriteLine($"Цена шкафа: {_price}/ Страна-производитель: {_nameOfFabricator}/ Дата изготовления: {DateOfManufacture}/ Название модели: {_nameOfWardrobe}");
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
