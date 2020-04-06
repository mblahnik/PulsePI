using Microsoft.EntityFrameworkCore;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.Exceptions;
using PulsePI.MessageContracts;
using PulsePI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PulsePI.DataAccess
{
    public class AccountDao : IAccountDao
    {
        private PulsePiDBContext _context;

        public AccountDao(PulsePiDBContext context)
        {
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

        public async Task CreateAccount(Account a)
        {      
            Account acc = await _context.accounts.Where(x => x.username == a.username).FirstOrDefaultAsync();
            if (acc != null) throw new CustomException("Account already exists");

            try
            {
                _context.accounts.Add(a);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CustomException("Error creating account", ex);
            }
        }
    }
}


