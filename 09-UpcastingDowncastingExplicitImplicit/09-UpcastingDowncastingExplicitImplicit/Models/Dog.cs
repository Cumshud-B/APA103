using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    internal class Dog : Animals 
    {
        public  string  Breed { get; set; }
        public  string  Name { get; set; }
    }
}
