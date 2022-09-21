using System;

namespace Otus_HomeWork_Dictionary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var dict = new OtusDictionary();

            var size = dict.Size();
            Console.WriteLine($"Элементов в словаре: {dict.ElemetCount()} \nРазмер словаря: {size}");

            Node(dict);

            size = dict.Size();
            Console.WriteLine($"Элементов в словаре: {dict.ElemetCount()} \nРазмер словаря: {size}");

            for (int i = 0; i < size; i++)
            {
                if (dict[i] != null)
                {
                    Console.WriteLine(dict[i].ToString());
                }
            }

            Console.WriteLine(dict.Get(123).ToString());
        }

        private static void Node(OtusDictionary dict)
        {
            var random = new Random();
            for (int i = 0; i < 60; i++)
            {
                var key = random.Next(1, 10000);

                string value = "";
                for (int j = 0; j < 5; j++)
                {
                    char a = (char)random.Next(33, 126);
                    value += a;
                }

                dict.Add(key, value);
            }
        }
    }
}