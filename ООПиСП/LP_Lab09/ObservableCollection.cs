using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LP_Lab09_
{
    internal class ObservableCollection<T> where T : Services
    {
        public delegate void Change(string message); // делегат
        public event Change CollectionChange; // событие
        Queue<T> queue = new Queue<T>();
        public void AddElement(T a)
        {
            queue.InputQueue(a);
            if(CollectionChange != null)
            {
                CollectionChange.Invoke("Элемент добавлен");
            }
        }
        public void DeleteElement()
        {
            queue.DelQueue();
            if (CollectionChange != null)
            {
                CollectionChange.Invoke("Элемент удален");
            }
        }
        public void Print()
        {
            queue.PrintQueue();
        }

    }
}
