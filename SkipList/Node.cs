using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipList
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value;
        public Node<T>[] Neigbors;
        public int Height;

        public Node<T> this [int level]
        {
            get
            {
                return Neigbors[level];
            }
            set
            {
                Neigbors[level] = value;
            }
        }

        public Node(T value, int height)
        {
            this.Value = value;
            Neigbors = new Node<T>[height];
            Height = Neigbors.Length;
        }
        public Node(int height)
        {
            Neigbors = new Node<T>[height];
            Height = Neigbors.Length;
        }

        public void IncreaseHeight()
        {
            Node<T>[] temp = new Node<T>[Height + 1];
            for(int i = 0; i < Neigbors.Length; i++)
            {
                temp[i] = Neigbors[i];
            }
            Neigbors = temp;
            Height = Neigbors.Length;
        }
    }

}
