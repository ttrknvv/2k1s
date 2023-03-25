using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab06
{
    internal class AgeException : Exception
    {
        private int _value;
        public int Value
        {
            get { return _value; }
        }
        public AgeException(string message, int value) : base(message)
        {
            _value = value;
        }
    }
}
