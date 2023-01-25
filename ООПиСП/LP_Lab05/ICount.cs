using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab04
{
    internal interface ICount
    {
        int Count { get; set; }
        void Refund();
        void Buy();
    }
}
