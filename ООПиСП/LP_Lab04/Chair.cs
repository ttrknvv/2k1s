using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab04
{
    internal sealed class Chair : Count, ICount
    {
        private int _count;
        private string _nameOfChair;
        public string NameOfChair
        {
            get
            {
                return _nameOfChair;
            }
            set
            {
                _nameOfChair = value;
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
            return "Здесь указана информация об товаре стул";
        }
        public override void GetInfoOfProduct()
        {
            Console.WriteLine($"Название модели: {_nameOfChair}");
        }
        public override void Refund()
        {
            _count++;
            Console.WriteLine("Возврат успешен!");
            return;
        }
        void ICount.Refund()
        {
            Console.WriteLine("Возврат неуспешен!");
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
