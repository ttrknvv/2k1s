using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LP_Lab13
{
    [DataContract]
    [Serializable]
    
    public class Hanger : Furniture, ICount
    {
        [NonSerialized]
        private int _count;
        [DataMember]
        private string _nameOfHanger;
        public string NameOfHanger
        {
            get
            {
                return _nameOfHanger;
            }
            set
            {
                _nameOfHanger = value;
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
            return "Здесь указана информация об товаре вешалка";
        }
        public override void GetInfoOfProduct()
        {
            Console.WriteLine($"Цена вешалки: {_price}/ Страна-производитель: {_nameOfFabricator}/ Дата изготовления: {DateOfManufacture}/ Название модели: {_nameOfHanger}");
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
        [OnSerialized]
        private void PrintMess(StreamingContext xont)
        {
            Console.WriteLine("Сериализация прошла успешно!");
        }
        [OnDeserialized]
        private void PrintMess2(StreamingContext xont)
        {
            Console.WriteLine("Десериализация прошла успешно!");
        }
    }
}
