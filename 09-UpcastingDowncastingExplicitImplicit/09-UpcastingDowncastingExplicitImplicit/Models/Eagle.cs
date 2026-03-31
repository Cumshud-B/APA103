using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    internal class Eagle : Animals 
    {
        public  int  FlySpeed { get; set; }
        public void Fly()
        {
            Console.WriteLine( "uzaqlara ucdu");
        }
    }
}
