using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipList
{
    public class SkipList<T> : ICollection<T>, IEnumerable<T> where T : IComparable<T>
    {
        public int Count { get; private set; }
        public bool IsReadOnly { get; }

        Node<T> head;

        int height;

        Random rand = new Random();

        public SkipList()
        {
            Count = 0;
            head = new Node<T>(1);
        }

        public int ChooseRandomHeight(int maxHeight)
        {
            height = 1;
            while (rand.Next(0, 2) != 0 && height < maxHeight)
            {
                height++;
            }
            return height;
        }

        public void Add(T value)
        {
            //create node to insert w/ random height
            Node<T> temp = new Node<T>(value, ChooseRandomHeight(head.Height + 1));
            if (temp.Height > head.Height)
            {
                head.IncreaseHeight();
            }

            Node<T> current = head;
            int level = head.Height - 1;
            while (level > 0)
            {
                //next value is GREATER then the new value: move down (treat null as infinity)
                if (current[level] == null || current[level].Value.CompareTo(value) > 0)
                {
                    //move down
                    level--;
                    //link in new node
                    if (level < temp.Height)
                    {
                        temp[level] = current[level];
                        current[level] = temp;


                    }
                }
                else
                {
                    //move right
                    current = current[level];
                }

                //if greater: move down
                //if less: move right
                //if EQUAL: move down and link THROUGH (current[level] = current[level][level];)

            }

            Count++;
        }

        public void Clear()
        {
            head = new Node<T>(1);
        }

        public void CopyTo(T[] array, int index)
        {

        }

        public bool Contains(T value)
        {
            Node<T> temp = head;
            for (int i = Count; i >= 1; i--)
            {
                while (temp[i].Value != null)
                {
                    if (temp[i].Value.CompareTo(value) == 0)
                    {
                        return true;
                    }
                    else if (temp[i].Value.CompareTo(value) < 0)
                    {
                        temp = temp[i];
                    }
                    else if (temp[i].Value.CompareTo(value) > 0)
                    {
                        break;
                    }
                }
            }
            return false;
        }

        public bool Remove(T value)
        {
            Node<T> current = head;
            int level = head.Height - 1;
            while(level > 0)
            {
                if (current[level] == null || current[level].Value.CompareTo(value) > 0)
                {
                    level--;
                }
                // < =
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}