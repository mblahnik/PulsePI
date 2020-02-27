using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.Models;
using PulsePI.Service.ServiceInterfaces;

namespace PulsePI.Service
{
    public class AccountService : IAccountService
    {
        IAccountDao _accountDao;

        public AccountService(IAccountDao a)
        {
            _accountDao = a;
        }

        public JsonResult Login()
        {
            return new JsonResult("string");
        }


    }
}
