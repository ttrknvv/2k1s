﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab06
{
    internal class CyrillicException : ArgumentException
    {
        public CyrillicException(string message) : base(message)
        {

        }
    }
}
