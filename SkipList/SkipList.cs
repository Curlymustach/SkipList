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
            
        }

        public int ChooseRandomHeight()
        {
            height = 1;
            while(rand.Next(0, 2) != 0 && height < head.Height + 1)
            {
                height++;
            }
            return height;
        }

        public void Add(T value)
        {

        }

        public void Clear()
        {

        }

        public void CopyTo(T[] array, int index)
        {

        }

        public bool Contains(T value)
        {
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