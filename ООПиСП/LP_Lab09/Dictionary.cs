using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab09_
{
    internal class Dictionary<T, W>
    {
        private T key; // ключ
        private W variable; // значение
        private Dictionary<T, W> next;
        private Dictionary<T, W> head;
        private Dictionary<T, W> tail;
        public Dictionary(T key, W value)
        {
            this.key = key;
            this.variable = value;
        }
        public Dictionary() { }
        private int size;
        public void AddElement(T key, W value) // добавление элемента
        {
            Dictionary<T, W> dict = new Dictionary<T, W>(key, value);
            Dictionary<T, W> temp = tail;
            tail = dict;
            if(size == 0)
            {
                head = tail;
            }
            else
            {
                temp.next = tail;
            }
            size++;
        }
        public void PrintDictionary()
        {
            Dictionary<T, W> temp = head;
            for(int i = 0; i < size; i++)
            {
                Console.WriteLine($"Ключ: {temp.key} Значение: {temp.variable}");
                temp = temp.next;
            }
        } // вывести элементы
        public void DeleteElement() // удалить элемент
        {
            if(size == 0)
            {
                throw new Exception("No elements.");
            }
            head = head.next;
            size--;
        }
        public void PrintElement(T key)
        {
            if (size == 0)
            {
                throw new Exception("No elements.");
            }
            Dictionary<T, W> dixt = head;
            for(int i = 0; i < size; i++)
            {
                int? key_ = dixt.key as int?;
                int? key2 = key as int?;
                if(key_ == key2)
                {
                    Console.WriteLine($"Найденный элемент по ключу: {dixt.variable}");
                    return;
                }
                dixt = dixt.next;
            }
            Console.WriteLine("Элемент не найден.");
        }
    }
}
