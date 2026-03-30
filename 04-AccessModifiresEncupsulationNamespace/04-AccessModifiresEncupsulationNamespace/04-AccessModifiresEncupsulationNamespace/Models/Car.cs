using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    internal class Car
    {
        public string _model;
        private string _horsepower;

        public int horsepower {
            get
            {
                if (horsepower<100)
                {
                    Console.WriteLine("can't drive");
                }


                Console.WriteLine("can drive");
                return horsepower;
            }
            set
            {
                if (value<100)
                {
                    Console.WriteLine("pleas enter value number");
                }

                horsepower = value;
                Console.WriteLine(_horsepower);
                
            }
        }
    }
}
