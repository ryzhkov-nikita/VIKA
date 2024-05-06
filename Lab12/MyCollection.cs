using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab12
{
    public class MyCollection<T> : ICollection<T> where T : ICloneable, IComparable<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
                Previous = null;
            }
        }

        private Node head;
        private Node tail;
        private int count;

        public MyCollection()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public MyCollection(MyCollection<T> c)
        {
            head = null;
            tail = null;
            count = 0;

            foreach (var item in c)
            {
                
                T clonedItem = (T)item.Clone();
                Add(clonedItem);
            }
        }
        public MyCollection(int capacity)
        {

            head = null;
            tail = null;
            count = 0;
        }
        public void Add(T item)
        {
            Node newNode = new Node(item);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }

            count++;
        }



        public bool Remove(T item)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        tail = current.Previous;
                    }

                    count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            Node current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
            else
            {
                head = current.Next;
            }

            if (current.Next != null)
            {
                current.Next.Previous = current.Previous;
            }
            else
            {
                tail = current.Previous;
            }

            count--;
            return true;
        }

        public int RemoveAll(Predicate<T> match)
        {
            int removedCount = 0;
            Node current = head;

            while (current != null)
            {
                Node nextNode = current.Next;

                if (match(current.Data))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        tail = current.Previous;
                    }

                    removedCount++;
                    count--;
                }

                current = nextNode;
            }

            return removedCount;
        }

        public T Find(Predicate<T> match)
        {
            Node current = head;

            while (current != null)
            {
                if (match(current.Data))
                {
                    return current.Data;
                }

                current = current.Next;
            }

            return default(T);
        }

        public MyCollection<T> ShallowCopy()
        {
            return (MyCollection<T>)this.MemberwiseClone();
        }

        public MyCollection<T> DeepClone()
        {
            MyCollection<T> clone = new MyCollection<T>();

            Node current = head;

            while (current != null)
            {
                clone.Add((T)current.Data.Clone());
                current = current.Next;
            }

            return clone;
        }

       public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public int Count => count;

        public bool IsReadOnly => false;

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            return Find(data => data.Equals(item)) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node current = head;
            while (current != null && arrayIndex < array.Length)
            {
                array[arrayIndex++] = current.Data;
                current = current.Next;
            }
        }
    }
}