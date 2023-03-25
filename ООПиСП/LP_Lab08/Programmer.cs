using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Lab0
{
    internal class Programmer
    {
        private string _programmerName;
        public delegate ProgrammerLanguage GetOlder(ProgrammerLanguage a1, ProgrammerLanguage a2);
        public event EventHandler Rename;
        public event EventHandler NewProperty;
        public Programmer() { }
        ~Programmer() { }
        public void ChangeVersion()
        {
            Console.WriteLine("Меняем версию...");
            if (NewProperty != null)
            {
                NewProperty(this, null);
            }
        }
        public void RenameLanguage()
        {
            Console.WriteLine("Меняем название...");
            if (Rename != null)
            {
                Rename(this, null);
            }
        }
        public GetOlder GetOldLanguage = (a1, a2) => a1.AgeOfCreateLanguage > a2.AgeOfCreateLanguage ? a2 : a1;
    }
}
