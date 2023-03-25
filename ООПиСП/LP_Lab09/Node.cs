using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_Lab09_
{
    internal class Node<T>
    {
        public T data;
        public Node<T> Next;
        public Node(T data)
        {
            this.data = data;
        }
            
    }
}
