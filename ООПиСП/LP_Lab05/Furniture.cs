using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab04
{
    internal class Furniture : Product
    {
        protected static int _personalID;
        protected string _nameOfFabricator;
        public Furniture() : base(1000) { }
        ~Furniture() { }
        public int PersonalID
        {
            get { return _personalID; }
        }
        public enum Furnit
        {
            Bed = 1,
            Chair = 2,
            Curbstone = 3,
            Hanger = 4,
            SildingWadrobe = 5,
            Sofa = 6,
            Wardrobe = 7
        }
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
        public void GetCountOfSingleFurniture(Furnit a)
        {
            switch(a)
            {
                case Furnit.Bed: Console.WriteLine("Количество кроватей: 234");
                                 break;
                case Furnit.Chair: Console.WriteLine("Количество стульев: 232");
                                   break;
                case Furnit.Curbstone: Console.WriteLine("Количество тумб: 14");
                                        break;
                case Furnit.Sofa: Console.WriteLine("Количество кресел: 101");
                                  break;
                case Furnit.SildingWadrobe: Console.WriteLine("Количество шкафов- купе: 143");
                                                    break;
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
