using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.DataContracts;
using PulsePI.Exceptions;
using PulsePI.Models;
using Microsoft.EntityFrameworkCore;
using PulsePI.MessageContracts;
using System.Collections.Generic;

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

    }

        }
    

