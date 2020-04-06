using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.Exceptions;
using PulsePI.MessageContracts;
using PulsePI.Models;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PulsePI.DataAccess
{
    public class AccountDao : IAccountDao
    {
        private readonly IConfiguration _config;
        private PulsePiDBContext _context;

        public AccountDao(IConfiguration config, PulsePiDBContext context)
        {
            _config = config;
            _context = context;
        }

        public async Task<LoginMessage> Login(string username, string password)
        {
            Account acc;
            try
            {
                acc = await _context.accounts.Where(x => (x.username == username) &&
                (x.password == password)).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new CustomException("Database error at login", e);
            }

            if (acc == null) throw new CustomException("Account not found");

            return new LoginMessage(acc.username, acc.firstName, acc.lastName,
                acc.middleName, acc.birthDate, acc.avatarUrl, acc.email);
        }

        public async Task CreateAccount(string u, string p, string f, string l, string e)
        {
            string defaultUrl = _config["DefaultAvatarUrl"] ?? throw new Exception("No Default avatar url in appsettings");

            Account acc = await _context.accounts.Where(x => x.username == u).FirstOrDefaultAsync();
            if (acc != null) throw new CustomException("Account already exists");

            acc = new Account()
            {
                username = u,
                password = p,
                firstName = f,
                lastName = l,
                email = e,
                avatarUrl = defaultUrl
            };

            try
            {
                _context.accounts.Add(acc);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CustomException("Error creating account", ex);
            }
        }
    }
}


