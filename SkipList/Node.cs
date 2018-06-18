using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipList
{
    public class Node<T> where T : IComparable<T>;
    {
        public T Value;
        public Node<T>[] Nodes;
        public int Height;

        public Node<T> this [int index]
        {
            get
            {
                return Nodes[index];
            }
            set
            {
                Nodes[index] = value;
            }
        }

        public Node(T value, int height)
        {
            this.Value = value;
            Nodes = new Node<T>[height];
            Height = Nodes.Length;
        }
        public Node(int height)
        {
            Nodes = new Node<T>[height];
            Height = Nodes.Length;
        }

        public void IncreaseHeight()
        {
            Node<T>[] temp = new Node<T>[Height + 1];
            for(int i = 0; i < Nodes.Length; i++)
            {
                temp[i] = Nodes[i];
            }
            Nodes = temp;
        }
    }

}
