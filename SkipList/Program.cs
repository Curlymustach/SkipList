﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipList
{
    class Program
    {
        static void Main(string[] args)
        {
            SkipList<int> list = new SkipList<int>();
            for (int i = 1; i <= 5; i++)
            {
                list.Add(i);
            }
            list.Remove(4);

            Console.ReadKey();

        }
    }
}
