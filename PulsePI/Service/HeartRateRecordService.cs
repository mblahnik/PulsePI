using System;
using System.Threading.Tasks;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.DataContracts;
using PulsePI.Exceptions;
using PulsePI.Models;
using PulsePI.Service.ServiceInterfaces;

namespace PulsePI.Service
{
    public class HeartRateRecordService : IHeartRateRecordService
    {
        IHeartRateRecordDao _heartRateRecordDao;

        public HeartRateRecordService(IHeartRateRecordDao hrrd)
        {
            _heartRateRecordDao = hrrd;
        }

        public async Task RecordHeartRate(HeartRateRecordData hr)
        {
            //Create a record 
            var heartRateRecord = new HeartRateRecord()
            {
                type = hr.type,
                startTime = ConvertToDateTime(hr.startTime),
                endTime = ConvertToDateTime(hr.endTime),
                bpmLow = hr.bpmLow,
                bpmHigh = hr.bpmHigh,
                bpmAvg = hr.bpmAvg
            };

            try
            {
                await _heartRateRecordDao.RecordHeartRate(heartRateRecord, hr.username);
            }
            catch(Exception e)
            {
                throw new CustomException("Error at record heart rate service" + e);
            }
        }

        private DateTime ConvertToDateTime(long unixDate)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddMilliseconds(unixDate).ToLocalTime();
        }
    }
}
