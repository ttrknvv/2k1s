using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab09_
{
    internal class Queue<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count = 0;
        public void InputQueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = tail;
            tail = node;
            if (count == 0)
            {
                head = tail;
            }
            else
            {
                tempNode.Next = tail;
            }
            count++;
        } // добавить элемент в очередь
        public T DelQueue()
        {
            if(count == 0)
            {
                throw new Exception("No elements");
            }

            if(head.data is Services)
            {
                Services head2 = head.data as Services;
                Console.WriteLine();
                Console.WriteLine($"Клиент: {head2.FirstNameClient} {head2.LastNameClient} обслужен.");
                Console.WriteLine();
                T output = head.data;
                head = head.Next;
                count--;
                return output;
            }
            else
            {
                T output = head.data;
                head = head.Next;
                count--;
                return output;
            }
            
        } // удаить элемент очереди
        public void PrintQueue()
        {
            if(count == 0)
            {
                throw new Exception("No elements");
            }
            
            int count_ = count;
            Node<T> data2 = head;
            if (head.data is Services)
            {
                Services data = data2.data as Services;
                while (count_ != 0)
                {
                    Console.WriteLine($"Клиент: {data.FirstNameClient} {data.LastNameClient}");
                    Console.Write($"Купил словарь: ");
                    Console.WriteLine(data.BoughtDictionary);
                    Console.Write($"Купил аксесуар: ");
                    Console.WriteLine(data.BoughtProperties);
                    Console.WriteLine();
                    data2 = data2.Next;
                    count_--;
                }
            }
            else
            {
                while (count_ != 0)
                {
                    Console.WriteLine(data2.data);
                    data2 = data2.Next;
                    count_--;
                }  
            }
        } // вывести клиентов очереди
        public void FindElement(T data)
        {
            if (count == 0)
            {
                throw new Exception("No elements");
            }
            Node<T> element = head;
            int count_ = count;
            if(head.data is Services)
            { 
                while (count_ != 0)
                {
                    Services element2 = element.data as Services;
                    Services compElement = data as Services;
                    if (element2 == compElement)
                    {
                        Console.WriteLine("Элемент найден!");
                        return;
                    }
                    element = element.Next;
                    count_--;
                }
            }
            else if(head.data is int)
            {
                while (count_ != 0)
                {
                    int? element2 = element.data as int?;
                    int? compElement = data as int?;
                    if (element2 == compElement)
                    {
                        Console.WriteLine("Элемент найден!");
                        return;
                    }
                    element = element.Next;
                    count_--;
                }
            }
            Console.WriteLine("Элемент не найден!");
        } // найти элемент в очереди
    }
}
