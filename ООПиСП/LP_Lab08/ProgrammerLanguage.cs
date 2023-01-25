using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Lab0
{
    internal class ProgrammerLanguage
    {
        private string _nameLanguage;
        private int _ageCreatelanguage;
        private string _languageVersion;
        private string _tehnologiesLanguage;
        public ProgrammerLanguage() { }
        public ProgrammerLanguage(string Name, int Age, string Version, string Tehnologies)
        {
            _nameLanguage = Name;
            _ageCreatelanguage = Age;
            _languageVersion = Version;
            _tehnologiesLanguage = Tehnologies;
        }
        ~ProgrammerLanguage() { }
        public string NameLanguage
        {
            get { return _nameLanguage; }
            set { _nameLanguage = value; }
        }
        public int AgeOfCreateLanguage
        {
            get { return _ageCreatelanguage; }
            set { _ageCreatelanguage = value; }
        }
        public string VersionLanguage
        {
            get { return _languageVersion; }
            set
            { _languageVersion = value; }
        }
        public string TehnologiesLanguage
        {
            get { return _tehnologiesLanguage; }
            set
            { _tehnologiesLanguage = value; }
        }
        public void OnNewProperties(object sender, EventArgs e)
        {
            string choise;
            Console.WriteLine($"Я изучил текущую версию {_languageVersion} языка {_nameLanguage}, к какой переходим сейчас?");
            choise = Console.ReadLine();
            _languageVersion = choise;
        }
        public void OnRename(object sender, EventArgs e)
        {
            string choise;
            Console.WriteLine($"Я узнал, что язык {_nameLanguage} поменял свое название, на какое же?");
            choise = Console.ReadLine();
            _nameLanguage = choise;
        }
    }
}
