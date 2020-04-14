using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.DataContracts;
using PulsePI.Exceptions;
using PulsePI.MessageContracts;
using PulsePI.Models;
using PulsePI.Service.ServiceInterfaces;

namespace PulsePI.Service
{
    public class BiometricService : IBiometricService
    {
        IBiometricDataDao _bio;

        public BiometricService(IBiometricDataDao b)
        {
         _bio = b;
        }
        public async Task CreateBiometric(BiometricData cbd)
        {
        var biometric = new Biometric()
        {
            height = cbd.height,
                weight = cbd.weight,
                Date = ConvertToDateTime(cbd.Date),
                sex = cbd.sex,
        };
          try
            {
                await _bio.CreateBiometricData(biometric);
            }
            catch(Exception e)
            {
                throw new CustomException("Error at creating biometric service" + e);
            }
    
}
 private DateTime ConvertToDateTime(long unixDate)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddMilliseconds(unixDate).ToLocalTime();
        }
}
}