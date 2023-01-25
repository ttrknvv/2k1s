using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab04
{
    internal class Product
    {
        protected int _price;
        protected int _dateOfManufacture;
        public Product(int Price) 
        {
            _price = Price;
        }
        ~Product() { }
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public int DateOfManufacture
        {
            get
            {
                return _dateOfManufacture;
            }
            set
            {
                _dateOfManufacture = value;
            }
        }
        public override string ToString()
        {
            return "Здесь указана информация о товарах.";
        }
        public virtual void GetInfoOfProduct()
        {
            Console.WriteLine($"Дата изготовления товаров: {_dateOfManufacture}/ Общая прибыль при продаже товаров: {_price}");
        }
    }
}
