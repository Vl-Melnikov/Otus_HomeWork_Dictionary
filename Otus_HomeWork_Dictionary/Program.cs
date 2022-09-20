using System;

namespace Otus_HomeWork_Dictionary
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dict = new OtusDictionary();
            var size = dict.Size();
            Console.WriteLine($"Элементов в словаре: {dict.ElemetCount()} \nРазмер словаря: {size}");

            dict.Add(123, "test1");
            dict.Add(234, "test2");
            dict.Add(456, "test3");
            dict.Add(678, "test4");

            size = dict.Size();
            Console.WriteLine($"Элементов в словаре: {dict.ElemetCount()} \nРазмер словаря: {size}");

            for (int i = 0; i < size; i++)
            {
                if (dict[i] != null)
                {
                    Console.WriteLine(dict[i].ToString());
                }
            }
        }
    }
}