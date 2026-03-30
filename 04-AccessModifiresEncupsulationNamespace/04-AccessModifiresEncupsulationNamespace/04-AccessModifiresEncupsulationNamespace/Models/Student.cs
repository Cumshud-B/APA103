using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    internal class Student:Person
    {
        public bool isSdudent;
        public Student(string name):base(name)
        {
            Console.WriteLine(this.name);
        }
    }
    
}
