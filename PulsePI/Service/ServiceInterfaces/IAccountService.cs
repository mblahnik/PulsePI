using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PulsePI.DataContracts;
using PulsePI.MessageContracts;

namespace PulsePI.Service.ServiceInterfaces
{
    public interface IAccountService
    {
        public Task<LoginMessage> Login(LoginData ld);
        public Task CreateAccount(CreateAccountData d);
        public Task UpdateAccount(UpdateAccountData d);
    }
}
