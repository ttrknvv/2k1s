using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab09_
{
    internal interface IOrderedDictionary<T, W>
    {
        void BuyDictionary(T key);
        void SellDictionary(W name);
        void BuyPropertiesForDictionary(T key);
        void FindDictionary(W name);
    }
}
