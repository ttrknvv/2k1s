using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Lab07
{
    internal interface IGeneralized<T>
    {
        void Add(T item);
        void Remove(int numb);
        void Show();
    }
}
