using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    internal abstract  class Animals
    {
        public   int  AvgLifeTime { get; set; }
        public   string Gender  { get; set; }

        public virtual void Eat()
        {
            Console.WriteLine( "Qidalanir:");
        }
    }
}
