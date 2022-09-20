namespace Otus_HomeWork_Dictionary
{
    internal partial class OtusDictionary
    {
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
}