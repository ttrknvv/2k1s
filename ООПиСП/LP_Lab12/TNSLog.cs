using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab12
{
    public static class TNSLog
    {
        private static string _path;
        public static string Path
        {
            set { _path = value; }
            get 
            {
                File.AppendAllText(_path, $"{DateTime.Now}\n");
                return _path; 
            }
        }
    }
}
