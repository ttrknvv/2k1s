using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Lab07
{
    internal class CollectionType<U> : IGeneralized<U> where U : class // ограничение на обобщение
    {
        private U[] _elements;
        private int _count;
        public CollectionType(int count) 
        {
            _elements = new U[count];
        }
        ~CollectionType() { }
        public int Count
        {
            get { return _count; }
        }
        public U GetElement(int index)
        {
            return _elements[index];
        }
        public void Add(U item)
        {
            if(_count >= _elements.Length)
            {
                throw new Exception("Allocated memory exceeded");
            }
            _elements[_count++] = item;
        }
        public void Remove(int numb)
        {
            if(_count == 0 || numb > _count)
            {
                throw new Exception("No element in collection");
            }
            _elements[numb] = default(U);
            _count--;
        }
        public void Show()
        {
            if (_elements[0] is Passwords)
            {
                for (int i = 0; i < _count; i++)
                {
                    Passwords a = _elements[i] as Passwords;
                    Console.WriteLine($"Password: {a.Password}");
                }
            }
            else if(_elements[0] is Bed)
            {
                for (int i = 0; i < _count; i++)
                {
                    Bed a = _elements[i] as Bed;
                    Console.WriteLine($"Name: {a.NameOfBed}");
                    Console.WriteLine($"Count: {a.Count}");
                }
            }
        }
        public Passwords FindOnPredicatPassword(Passwords a)
        {
            if(!(_elements is Passwords))
            {
                throw new Exception("Not equals types");
            }
            for(int i = 0; i < _count; i++)
            {
                Passwords a2 = _elements as Passwords;
                if(a2 == a)
                {
                    return a2;
                }
            }
            return null;
        }
        public void WriteJson(string path)
        {
            for(int i = 0; i < _count; i++)
            {
                string json = JsonConvert.SerializeObject(_elements[i]);
                File.AppendAllText(path, json);
            }
        }
        public void ReadJson(string path)
        {
            string json = File.ReadAllText(path);
            int from = 0;
            for(int i = 0; i < json.Length; i++)
            {
                if (json[i] == '}')
                {
                    string a = json.Substring(from, i - from + 1);
                    Add(JsonConvert.DeserializeObject<U>(a));
                    from = i + 1;
                }

            }
        }
    }
}
