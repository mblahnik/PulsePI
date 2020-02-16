using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PulsePI.Controllers
{
    public class Person
    {
        public Person(string x, int y)
        {
            name = x;
            age = y;
        }


        public string name { get; set; }
        public int age { get; set; }

    }
}
