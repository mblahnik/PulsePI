using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.Models;

namespace PulsePI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        readonly IAccountDao accountDao;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IAccountDao dao)
        {
            _logger = logger;
            accountDao = dao;
        }

        [HttpGet]
        public IEnumerable<Account> Get()
        { 
            return accountDao.GetAllAccounts();
        }
    }
}
