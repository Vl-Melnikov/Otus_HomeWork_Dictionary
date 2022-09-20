using System;

namespace Otus_HomeWork_Dictionary
{
    internal partial class OtusDictionary
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
            var i = node.Key.GetHashCode() % data.Length;

            while (data[i] != null)
            {
                Resize();
            }
            data[i] = node;
        }

        private void Resize()
        {
            dataResize = new Node[data.Length * 2];
            foreach (var item in data)
            {
                if (item != null)
                {
                    var i = item.GetHashCode() % dataResize.Length;
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
}