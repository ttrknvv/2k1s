using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab13
{
    [DataContract]
    [Serializable]
    public class Furniture : Product
    {
        [DataMember]
        protected string _nameOfFabricator;
        public Furniture() : base(1000) { }
        ~Furniture() { }
        public string NameOfFabricator
        {
            get
            {
                return _nameOfFabricator;
            }
            set
            {
                _nameOfFabricator = value;
            }
        }
        public override void GetInfoOfProduct()
        {
            Console.WriteLine($"Общая цена мебели: {_price}/ Страна-производитель: {_nameOfFabricator}/ Дата изготовления: {DateOfManufacture}");
        }
        public override string ToString()
        {
            return "Здесь указана информация о мебели";
        }

    }
}
