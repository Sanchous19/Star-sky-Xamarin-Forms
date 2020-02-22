using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Project
{
    [Serializable]
    public class Collection<T> : IEnumerable<T>, INotifyCollectionChanged
    {
        private List<T> _items = new List<T>();

        private class CollectionIEnumerator : IEnumerator<T>
        {
            private readonly List<T> _data = new List<T>();
            private int _position = -1;

            public CollectionIEnumerator(List<T> data)
            {
                _data.AddRange(data);
                _data.Sort(delegate (T obj1, T obj2) { return string.Compare(obj1.ToString(), obj2.ToString()); });
            }

            public T Current
            {
                get
                {
                    return _data[_position];
                }
            }
            object IEnumerator.Current
            {
                get
                {
                    return _data[_position];
                }
            }

            public bool MoveNext()
            {
                if (_position < _data.Count - 1)
                {
                    _position++;
                    return true;
                }
                else
                    return false;
            }
            public void Reset() => _position = -1;
            public void Dispose() { }
        }

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }
        public T this[int index]
        {
            get
            {
                return _items[index];
            }
        }
        public void Add(T item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
                _items.Sort(delegate (T obj1, T obj2) { return string.Compare(obj1.ToString(), obj2.ToString()); });
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            }
        }
        public void Remove(T item)
        {
            _items.Remove(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
        }
        public void RemoveAt(int index)
        {
            T obj = this[index];
            _items.RemoveAt(index);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, obj));
        }
        public void Clear()
        {
            _items.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public int FindIndex(T item) => _items.IndexOf(item);
        public T Search(T item)
        {
            for (int i = 0; i < Count; i++) 
                if (item.ToString() == _items[i].ToString())
                    return _items[i];
            throw new Exception();
        }

        public IEnumerator<T> GetEnumerator() => new CollectionIEnumerator(_items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        [field:NonSerialized]
        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
