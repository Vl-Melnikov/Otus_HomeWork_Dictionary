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
        public IReadOnlyList<TKey> Keys => _items.Select(i => i.Key).ToList();

        public TValue Get(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var item = _items.SingleOrDefault(i => i.Key.Equals(key)) ??
                throw new ArgumentException($"Словарь не содержит значение с ключом {key}.", nameof(key));

            return item.Value;
        }
        public void Add(Item<TKey, TValue> item)
        {
            var hash = GetHash(item.Key);

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
                    Array.Resize(ref _items, size * 2);
                    Add(item); // ToDo пересчитать хэши для ранее вставленных элементов
                    //Resize(ref _items, size * 2);
                    //throw new Exception("Словарь заполнен");
                }
            }
        }
        private int GetHash(TKey key)
        {
            return key.GetHashCode() % size;
        }

        static void Resize(ref int[] arr, int add)
        {
            int[] tempArray = new int[arr.Length];
            int length;

            for (int i = 0; i < arr.Length; i++)
            {
                tempArray[i] = arr[i];
            }

            length = arr.Length + add;

            if (length >= 0)
                arr = new int[length];
            else
                length = 0;
            arr = new int[length];

            length = tempArray.Length < arr.Length ? length = tempArray.Length : length = arr.Length;

            for (int i = 0; i < length; i++)
            {

                arr[i] = tempArray[i];
            }
        }
    }
}