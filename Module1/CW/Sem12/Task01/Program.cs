using System;
using System.Collections.Generic;
using System.Linq;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Alex", "Boris", "Andrey", "Bob" };
            List<string> selected = new List<string>();
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].ToUpper().StartsWith("A"))
                {
                    selected.Add(names[i]);
                }
            }
            foreach (var item in selected)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            // or
            var selected2 = from name in names
                            where name.ToUpper().StartsWith("A")
                            select name; // запрос
            foreach (var item in selected2)
            {
                Console.Write(item + " ");
            }
            names[1] = "Artem";
            Console.WriteLine();
            foreach (var item in selected2)
            {
                Console.Write(item + " ");
            }
        }
    }
}
