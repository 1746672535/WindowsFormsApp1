using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    namespace GenericApplication
    {

        // 链表节点
        public class Node<T>
        {
            public Node<T> Next { get; set; }
            public T Data { get; set; }

            public Node(T t)
            {
                Next = null;
                Data = t;
            }
        }

        //泛型链表类
        public class GenericList<T>
        {
            private Node<T> head;
            private Node<T> tail;

            public GenericList()
            {
                tail = head = null;
            }

            public Node<T> Head
            {
                get => head;
            }

            public void Add(T t)
            {
                Node<T> n = new Node<T>(t);
                if (tail == null)
                {
                    head = tail = n;
                }
                else
                {
                    tail.Next = n;
                    tail = n;
                }
            }
            public void Foreach(Action<T> action)
            {
                for (Node<T> x = head; x != null; x = x.Next)
                {
                    action(x.Data);
                }
            }

           
        }

        public class test
        {
            static void Main(string[] args)
            {
                // 整型List
                GenericList<int> intlist = new GenericList<int>();
                for (int x = 0; x < 10; x++)
                {
                    intlist.Add(x);
                }
                int sum = 0;
                int min = int.MaxValue;
                int max = int.MinValue;


                intlist.Foreach(x => Console.WriteLine(x));
                intlist.Foreach(x => sum += x);
                intlist.Foreach(x => min = min > x ? x : min);
                intlist.Foreach(x => max = max > x ? max : x);
                Console.WriteLine(sum);
                Console.WriteLine(min);
                Console.WriteLine(max);




            }
        }

    }
}
