using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PulsePI.Controllers
{
    public class TestControler : Controller
    {
        [HttpGet("api/whatever")]
        public IEnumerable<Person> getWhatever()
        {
            return new List<Person> { new Person("Bob",5) , new Person("Steve", 4)};
        }

    }
}
