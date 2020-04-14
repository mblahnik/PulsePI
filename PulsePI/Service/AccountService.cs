using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.DataContracts;
using PulsePI.Exceptions;
using PulsePI.MessageContracts;
using PulsePI.Models;
using PulsePI.Service.ServiceInterfaces;

namespace PulsePI.Service
{
    public class AccountService : IAccountService
    {
        IAccountDao _accountDao;
        IConfiguration _config;

        public AccountService(IAccountDao a, IConfiguration conf)
        {
            _accountDao = a;
            _config = conf;
        }

        public async Task<LoginMessage> Login(LoginData ld)
        {
            LoginMessage msg;
            try
            {
                msg = await _accountDao.Login(ld.username, ld.password);
            }
            catch(Exception e)
            {
                throw new CustomException(e.Message, e);
            }

            return msg;
        }

        public async Task CreateAccount(CreateAccountData cad)
        {
            string defaultUrl = _config["DefaultAvatarUrl"] ?? throw new Exception("No Default avatar url in appsettings");
            var account = new Account()
            {
                username = cad.username,
                password = cad.password,
                firstName = cad.firstName,
                lastName = cad.lastName,
                email = cad.email,
                avatarUrl = defaultUrl
            };

            try
            {
                await _accountDao.CreateAccount(account);
            }
            catch(Exception e)
            {
                throw new CustomException(e.Message, e);
            }
        }

        public async Task UpdateAccount(UpdateAccountData data)
        {
            try
            {
                await _accountDao.UpdateAccount(data);
            }
            catch(Exception e)
            {
                throw new CustomException("Error at update account in service", e);
            }
        }
    }
}
