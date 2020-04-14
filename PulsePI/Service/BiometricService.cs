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
        IHeartRateRecordDao _heart;

        public BiometricService(IBiometricDataDao b, IHeartRateRecordDao h)
        {
            _bio = b;
            _heart = h;
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
            catch (Exception e)
            {
                throw new CustomException("Error at creating biometric service" + e);
            }

        }

        public async Task<GetExerciseIntensityMsg> GetIntensities(UsernameData data)
        {
            List<GetAllHRDataMessage> records = null;
            Biometric bio = null;

            try
            {
                records = await _heart.GetAllHeartRateData(data);
                bio = await _bio.GetMostRecentRecord(data);
            }
            catch(Exception e)
            {
                throw new CustomException("Error getting HR data in service" + e);
            }

            return CalculateIntensities(records, bio); 
        }

        private GetExerciseIntensityMsg CalculateIntensities(List<GetAllHRDataMessage> list, Biometric bio)
        {
            //TODO 
            return null; 
        }

        private DateTime ConvertToDateTime(long unixDate)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddMilliseconds(unixDate).ToLocalTime();
        }
    }
}