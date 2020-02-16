using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PulsePI.DataAccess
{
    public class AccountDao : IAccountDao
    {

        public IList<Account> GetAllAccounts()
        {
            using (var context = new PulsePiDBContext())
            {
                var account = context.accounts;

                return account.ToList();
            }
        }

    }
}
