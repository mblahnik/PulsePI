using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.DataContracts;
using PulsePI.Exceptions;
using PulsePI.Models;
using Microsoft.EntityFrameworkCore;

namespace PulsePI.DataAccess
{
    public class HeartRateRecordDao : IHeartRateRecordDao
    {
        private readonly IConfiguration _config;
        private readonly PulsePiDBContext _context;

        public HeartRateRecordDao(IConfiguration conf, PulsePiDBContext context)
        {
            _config = conf;
            _context = context;
        }

        public async Task RecordHeartRate(HeartRateRecord hrr)
        {
            try
            {
                //Find the account that this HR data is for 
                Account acc = await _context.accounts.Where(x => x.username == hr.username).FirstOrDefaultAsync();
                if (acc == null) throw new InvalidOperationException("There is no account matching the username");

                hrr.accountId = acc.Id;
                hrr.account = acc;

                //Add the record to the DB and save 
                _context.heartRateRecords.Add(hrr);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new CustomException("Database error while trying to create heart rate record " + e);
            }    
        }
    }
}
