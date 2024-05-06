using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab12
{
    public class MyNewCollection<T> : MyCollection<T> where T : ICloneable, IComparable<T>
    {
        public string CollectionName { get; set; }

        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public MyNewCollection(string collectionName)
        {
            CollectionName = collectionName;
        }

        public bool Remove(int j)
        {
            if (j >= 0 && j < Count)
            {
                T removedItem = this[j];
                bool result = RemoveAt(j);
                OnCollectionCountChanged(new CollectionHandlerEventArgs(CollectionName, $"Element removed from {CollectionName}", removedItem));
                return result;
            }
            return false;
        }

        public T this[int index]
        {
            get
            {
                return this.ElementAt(index);
            }
            set
            {
                T oldValue = this[index];
                RemoveAt(index);
                Add(value);
                OnCollectionReferenceChanged(new CollectionHandlerEventArgs(CollectionName, $"Element replaced in {CollectionName}", value));
            }
        }

        protected virtual void OnCollectionCountChanged(CollectionHandlerEventArgs e)
        {
            CollectionHandler handler = CollectionCountChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnCollectionReferenceChanged(CollectionHandlerEventArgs e)
        {
            CollectionHandler handler = CollectionReferenceChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

    public class CollectionHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public object ChangedObject { get; set; }

        public CollectionHandlerEventArgs(string collectionName, string changeType, object changedObject)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ChangedObject = changedObject;
        }

        public override string ToString()
        {
            return $"Collection: {CollectionName}, Change Type: {ChangeType}, Changed Object: {ChangedObject}";
        }
    }
}