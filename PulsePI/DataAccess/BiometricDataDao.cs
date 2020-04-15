using System;
using System.Linq;
using System.Threading.Tasks;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.DataContracts;
using PulsePI.Exceptions;
using PulsePI.Models;
using Microsoft.EntityFrameworkCore;

namespace PulsePI.DataAccess
{
    public class BiometricDataDao : IBiometricDataDao
    {
        private PulsePiDBContext _context;

        public BiometricDataDao(PulsePiDBContext context)
        {
            _context = context;
        }

        public async Task CreateBiometricData(Biometric b)
        {
            Biometric bio = await _context.biometrics.Where(x => x.Id == b.Id).FirstOrDefaultAsync();
            if (bio != null) throw new CustomException("Biometric already exists");

            try
            {
                _context.biometrics.Add(b);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CustomException("Error creating biometric", ex);
            }
        }

        public async Task<Biometric> GetMostRecentRecord(UsernameData data)
        {
            Account acc = await _context.accounts.Where(x => x.username == data.username).FirstOrDefaultAsync();
            if (acc == null) throw new CustomException("Account doesn't exist");

            Biometric b = null;
            try
            {
                //get most recent biometric data record 
            }
            catch(Exception ex)
            {
                throw new CustomException("Error getting biometric record", ex);
            }
            return b;
        }

    }

}


