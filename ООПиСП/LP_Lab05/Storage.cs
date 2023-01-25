using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab04
{
    internal class Storage
    {
        private int _count = 0;
        public Furniture [] furniture;
        public int CountOf
        {
            set
            {
                furniture = new Furniture[value];
            }
        }
        public int CountOfElements
        {
            get
            {
                return _count;
            }
        }
        public Furniture GetElementOnID(int id)
        {
            return furniture[id];
        }
        public void AddElement(Furniture element)
        {
            furniture[_count] = element;
            _count++;
            Sort();
        }
        public void RemoveElement(Furniture element)
        {
            bool mark = false;
            for(int i = 0; i < _count; i++)
            {
                if((mark || furniture[i] == element) && i != _count - 1)
                {
                    Furniture f = furniture[i + 1];
                    furniture[i + 1] = furniture[i];
                    furniture[i] = f;
                    mark = true;
                }
            }
            furniture[_count - 1] = null;
            _count--;
            Sort();
        }
        public void PrintAllStorage()
        {
            Console.WriteLine("На складе: ");
            for(int i = 0; i < _count; i++)
            {
                Console.WriteLine(furniture[i]);
                furniture[i].GetInfoOfProduct();
                Console.WriteLine();
            }
        }
        private void Sort()
        {
            for(int i = 0; i < _count - 1; i++)
            {
                if(furniture[i].Price * ((ICount)furniture[i]).Count < furniture[i + 1].Price * ((ICount)furniture[i + 1]).Count)
                {
                    Furniture a = furniture[i + 1];
                    furniture[i + 1] = furniture[i];
                    furniture[i] = a;
                }
            }
        }

    }
}
