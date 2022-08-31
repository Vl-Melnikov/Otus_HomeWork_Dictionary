using System;
using System.Collections.Generic;
using System.Linq;

namespace Otus_HomeWork_Dictionary
{
    public class OtusDictionary<TKey, TValue>
    {
        private int size = 5;
        private Item<TKey, TValue>[] _items;

        public OtusDictionary()
        {
            _items = new Item<TKey, TValue>[size];
        }
        public IReadOnlyList<TKey> Keys => _items.Select(item => item.Key).ToList(); //?? 
        //throw new NullReferenceException($"Словарь не содержит значение с ключом");
        //public IReadOnlyList<TKey> Keys
        //{
        //    get
        //    {
        //        if (_items.Select(item => item.Key).ToList() != null)
        //            return _items.Select(i => i.Key).ToList();
        //        else
        //        {
        //            return null;
        //        }
        //    }

        //}

        public TValue Get(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var item = _items.SingleOrDefault(item => item.Key.Equals(key)) ??
                throw new ArgumentException($"Словарь не содержит значение с ключом {key}.", nameof(key));

            return item.Value;
        }
        public void Add(Item<TKey, TValue> item)
        {
            var hash = GetHash(item.Key, size);

            if (_items[hash] == null)
            {
                _items[hash] = item;
            }
            else
            {
                var placed = false;
                for(var i = hash; i < size; i++)
                {
                    if (_items[i] == null)
                    {
                        _items[i] = item;
                        placed = true;
                        break;
                    }

                    if (_items[i].Key.Equals(item.Key))
                    {
                        return;
                    }
                }
                if (!placed)
                {
                    for (var i = 0; i < hash; i++)
                    {
                        if (_items[i] == null)
                        {
                            _items[i] = item;
                            placed = true;
                            break;
                        }
                        if (_items[i].Key.Equals(item.Key))
                        {
                            return;
                        }
                    }
                }
                if (!placed)
                {
                    var newSize = size * 2;
                    var newItems = new Item<TKey, TValue>[newSize];
                    Array.Resize(ref _items, newSize);

                    for (int i = 0; i < size; i++)
                    {
                        var newHash = NewHash(_items[i].Key, newItems.Length);
                        if (newItems[newHash] == null)
                        {
                            newItems[newHash] = _items[i];
                        }
                    }
                    _items = newItems;
                    size = newSize;

                    Add(item);
                }
            }
        }
        private int GetHash(TKey key, int size)
        {
            return key.GetHashCode() % size;
        }

        private int NewHash(TKey key, int newSize)
        {
            var hash = GetHash(key, newSize);

            return hash;
        }
    }
}