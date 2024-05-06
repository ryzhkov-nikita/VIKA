using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab12
{
    public class MyCollection<T> : IEnumerable<T>, IEnumerator<T>, ICollection<T> where T : ICloneable, IComparable<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;
        private Node tail;
        private int count;
        private Node current;
        public MyCollection()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public MyCollection(int capacity)
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
                Add(item);
            }
        }

        public virtual void Add(T item)
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
                tail = newNode;
            }

            count++;
        }

        public virtual void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public virtual bool Remove(T item)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                        {
                            tail = null;
                        }
                    }

                    count--;
                    return true; // Элемент был удален
                }

                previous = current;
                current = current.Next;
            }

            return false; // Элемент не был найден
        }
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            Node current = head;
            Node previous = null;

            for (int i = 0; i < index; i++)
            {
                previous = current;
                current = current.Next;
            }

            if (previous != null)
            {
                previous.Next = current.Next;

                if (current.Next == null)
                {
                    tail = previous;
                }
            }
            else
            {
                head = head.Next;

                if (head == null)
                {
                    tail = null;
                }
            }

            count--;
            return true;
        }
        public int RemoveAll(Predicate<T> match)
        {
            int removedCount = 0;
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (match(current.Data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        head = head.Next;
                    }

                    if (current.Next == null)
                    {
                        tail = previous;
                    }

                    removedCount++;
                    count--;
                }
                else
                {
                    previous = current;
                }

                current = current.Next;
            }

            return removedCount;
        }

        public virtual T Find(Predicate<T> match)
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

        public virtual MyCollection<T> DeepClone()
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

        public MyCollection<T> ShallowCopy()
        {
            MyCollection<T> copy = new MyCollection<T>();

            Node current = head;

            while (current != null)
            {
                copy.Add(current.Data);
                current = current.Next;
            }

            return copy;
        }
        public virtual void FillCollection(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                // Генерация элемента коллекции. Это просто пример, вам нужно будет заменить это на свой код.
                T item = (T)Activator.CreateInstance(typeof(T));
                Add(item);
            }
        }
        public virtual void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public virtual void Sort(Func<T, object> keySelector)
        {
            // Преобразование коллекции в список для возможности использования LINQ
            List<T> list = this.ToList();
            list.Sort((x, y) =>
            {
                object xKey = keySelector(x);
                object yKey = keySelector(y);

                // Приведение к типу T
                if (xKey is T xTyped && yKey is T yTyped)
                {
                    return xTyped.CompareTo(yTyped);
                }
                else
                {
                    // Обработка ситуации, когда преобразование невозможно
                    throw new InvalidOperationException("Cannot compare keys of type object with type T.");
                }
            });

            // Очистка текущей коллекции и добавление отсортированных элементов
            Clear();
            foreach (var item in list)
            {
                Add(item);
            }
        }
        // Реализация интерфейса IEnumerable<T>
        public virtual IEnumerator<T> GetEnumerator()
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
        public virtual bool MoveNext()
        {
            if (current == null)
            {
                current = head;
            }
            else
            {
                current = current.Next;
            }

            return current != null;
        }

        public virtual void Reset()
        {
            current = null;
        }

        public virtual T Current
        {
            get
            {
                if (current == null)
                {
                    throw new InvalidOperationException();
                }

                return current.Data;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            // Нет ресурсов для освобождения
        }

        public virtual int Count
        {
            get { return count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Contains(T item)
        {
            return Find(x => x.Equals(item)) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node current = head;
            int index = arrayIndex;

            while (current != null && index < array.Length)
            {
                array[index++] = current.Data;
                current = current.Next;
            }
        }
    }
}