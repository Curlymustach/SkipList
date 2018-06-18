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

        public SkipList(int randomSeed)
        {
            Count = 0;
            head = new Node<T>(1);
        }

        public int ChooseRandomHeight(int maxHeight)
        {
            height = 1;
            while(rand.Next(0, 2) != 0 && height < maxHeight)
            {
                height++;
            }
            return height;
        }

        public void Add(T value)
        {
            Node<T> temp = new Node<T>(value, ChooseRandomHeight(head.Height + 1));
            if(temp.Height > head.Height)
            {
                head.IncreaseHeight();
            }

            Node<T> current = head;
            int level = head.Height - 1;
            while(level >= 0)
            {
                if (current[level].Value.CompareTo(value) > 0)
                {
                    if(temp.Height > level)
                    {
                        temp[level] = current[level];
                        current[level] = temp;
                    }
                    level--;
                }
                else if(current[level].Value.CompareTo(value) < 0)
                {
                    current = current[level];
                }
                else if(current[level].Value.CompareTo(value) == 0)
                {
                    return;
                }
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
            for(int i = Count; i >= 1; i--)
            {
                while(temp[i].Value != null)
                {
                    if(temp[i].Value.CompareTo(value) == 0)
                    {
                        return true;
                    }
                    else if(temp[i].Value.CompareTo(value) < 0)
                    {
                        temp = temp[i];
                    }
                    else if(temp[i].Value.CompareTo(value) > 0)
                    {
                        break;
                    }
                }
            }
            return false;
        }

        public bool Remove(T value)
        {
            return false;
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