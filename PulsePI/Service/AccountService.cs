using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.DataContracts;
using PulsePI.MessageContracts;
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

        public async Task<LoginMessage> Login(LoginData ld)
        {
            return new LoginMessage()
            {
                username = ld.username
            };
        }


    }
}
