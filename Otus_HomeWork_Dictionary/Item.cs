using System;

namespace Otus_HomeWork_Dictionary
{
    public class Item<TKye, TValue>
    {
        public TKye Key { get; set; }
        public TValue Value { get; set; }
        public Item() { }

        public Item(TKye key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Key = key;
            Value = value;
        }
    }
}