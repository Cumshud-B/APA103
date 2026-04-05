using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Data
{
    public class Library<T>
    {
        public List<T> Items { get; set; }
        public string Name { get; set; }

        public Library(string name)
        {
            Name = name;
            Items = new List<T>();
        }

        public void Add(T item)
        {
            Items.Add(item);
            Console.WriteLine("Elave edildi");
        }

        public void Remove(T item)
        {
            Items.Remove(item);
            Console.WriteLine("Silindi");
        }

        public List<T> GetAll()
        {
            return Items;
        }

        public int Count()
        {
            return Items.Count;
        }

        public T FindByIndex(int index)
        {
            if (index >= 0 && index < Items.Count)
            {
                return Items[index];
            }

            return default(T);
        }
    }
}