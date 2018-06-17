using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipList
{
    public class Node<T>
    {
        public T Value;
        public Node<T>[] Nodes;
        public int Height;

        public Node(T value, int height)
        {
            this.Value = value;
            this.Height = height;
        }
    }
}
