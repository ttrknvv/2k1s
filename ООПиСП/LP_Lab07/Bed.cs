using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Lab07
{
    internal class Bed
    {
        private int _count;
        private string _nameOfBed;
        public string NameOfBed
        {
            get
            {
                return _nameOfBed;
            }
            set
            {
                _nameOfBed = value;
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
        public override bool Equals(object obj)
        {
            
            if(obj is Bed) { return true; }
            return false;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            Random random = new Random();
            for(int i = 0; i < _nameOfBed.Length; i++)
            {
                hash += _nameOfBed[i];
            }
            hash *= random.Next();
            return Math.Abs(hash);
        }
        public override string ToString()
        {
            return "Здесь указана информация об товаре кровать";
        }
        public void Refund()
        {
            _count++;
            Console.WriteLine("Возврат успешен!");
            return;
        }
        public void Buy()
        {
            if(_count != 0)
            {
                _count--;
                Console.WriteLine("Покупка успешна!");
                return;
            }
            Console.WriteLine("Нет товарос для продажи!");

        }
    }
}
