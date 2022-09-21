using System;

namespace Otus_HomeWork_Dictionary
{
    internal class OtusDictionary
    {
        private Node[] data;
        private Node[] dataResize;

        public OtusDictionary()
        {
            data = new Node[32];
        }

        public Node this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        public int Size()
        {
            return data.Length;
        }

        public int ElemetCount()
        {
            int count = 0;
            foreach (var item in data)
            {
                if (item != null)
                {
                    count++;
                }
            }
            return count;
        }

        public void Add(int key, string value)
        {
            var node = new Node(key, value);
            var i = Math.Abs(node.Key.GetHashCode() % data.Length);

            while (data[i] != null)
            {
                Resize();
            }
            data[i] = node;
        }

        public Node Get(int key)
        {
            var (flag, index) = Contains(key);

            if (!flag)
            {
                throw new Exception("Ключ не найден");
            }

            return data[index];
        }

        private (bool flag, int index) Contains(int key)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != null)
                {
                    if (data[i].Key.Equals(key))
                    {
                        return (true, i);
                    }
                }
            }
            return (false, 0);
        }

        private void Resize()
        {
            dataResize = new Node[data.Length * 2];
            foreach (var item in data)
            {
                if (item != null)
                {
                    var i = Math.Abs(item.GetHashCode() % dataResize.Length);
                    if (dataResize[i] != null)
                    {
                        Resize();
                    }
                    dataResize[i] = item;
                }
            }
            data = dataResize;
            dataResize = null;
        }
    }

    public class Node
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public Node(int key, string value)
        {
            Key = key;
            Value = value;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            return $"Ключ: {Key} - Значение: {Value}";
        }
    }
}