using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.Models;


namespace PulsePI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDao _accountDao;

        public AccountController(IAccountDao dao)
        {
            _accountDao = dao;
        }

        /// <summary>
        /// This isn't Actually used. We should really avoid bringing back account objects since they have passwords with them.
        /// I think some dev tools might be able to read it. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return _accountDao.GetAllAccounts();
        }

    }
}