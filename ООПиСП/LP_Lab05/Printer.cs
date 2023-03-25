using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab04
{
    static class Printer
    {
        public static void IAmPrinting(ICount obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }
}
