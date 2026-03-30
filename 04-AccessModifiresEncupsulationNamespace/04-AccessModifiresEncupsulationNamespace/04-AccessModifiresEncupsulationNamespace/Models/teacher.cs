using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    public  class Teacher
    {
        public void Test()
        {
            Person person =  new Person(" ");
            person.name = "Test";
        }
    }
}
