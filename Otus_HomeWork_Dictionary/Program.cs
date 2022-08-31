using System;

namespace Otus_HomeWork_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new OtusDictionary<int, string>();
            dict.Add(new Item<int, string>(1, "Один"));
            dict.Add(new Item<int, string>(1, "Один"));
            dict.Add(new Item<int, string>(2, "Два"));
            dict.Add(new Item<int, string>(3, "Три"));
            dict.Add(new Item<int, string>(4, "Четыре"));
            dict.Add(new Item<int, string>(5, "Пять"));
            //dict.Add(new Item<int, string>(6, "Шесть"));
            //dict.Add(new Item<int, string>(7, "Семь"));
            //dict.Add(new Item<int, string>(9, "Девять"));

            ShowDict(dict, "OtusDictionary");
            Console.WriteLine(dict.Get(8));
            Console.ReadLine();
        }

        private static void ShowDict(OtusDictionary<int, string> dict, string title)
        {
            Console.WriteLine($"{title}: ");
            foreach (var key in dict.Keys)
            {
                var value = dict.Get(key);
                Console.WriteLine($"{key} - {value}");
            }
            Console.WriteLine();
        }
    }
}