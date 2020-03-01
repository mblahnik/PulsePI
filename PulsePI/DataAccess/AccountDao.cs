using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.DataContracts;
using PulsePI.MessageContracts;
using PulsePI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PulsePI.DataAccess
{
    public class AccountDao : IAccountDao
    {

        public async Task<LoginMessage> Login(LoginData ld)
        {
            using(var context = new PulsePiDBContext())
            {
                var acc = context.accounts.Where(x => (x.username == ld.username) &&
                    (x.password == ld.password)).FirstOrDefault();

                return new LoginMessage(acc.username, acc.firstName, acc.lastName, acc.middleName, acc.birthDate, acc.avatarUrl, acc.email);
            }
            
            
        }

    }
}
