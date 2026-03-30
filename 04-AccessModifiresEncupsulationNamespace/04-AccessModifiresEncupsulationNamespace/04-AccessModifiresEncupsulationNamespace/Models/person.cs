using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    public class Person
    {
        protected internal string name;
        public string surname;
        public Person(string name)
        {
            this.name = name;
        }
        //public void GetInfo()
        //{
        //    Console.WriteLine($"{this.name}");
        //}
    }


}
