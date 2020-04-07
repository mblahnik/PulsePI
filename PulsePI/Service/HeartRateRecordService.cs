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
                startTime = hr.startTime,
                endTime = hr.endTime,
                bpmLow = hr.bpmLow,
                bpmHigh = hr.bpmHigh,
                bpmAvg = hr.bpmAvg
            };

            try
            {
                await _heartRateRecordDao.RecordHeartRate(heartRateRecord);
            }
            catch(Exception e)
            {
                throw new CustomException("Error at record heart rate service" + e);
            }
        }
    }
}
