﻿using System;
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
                bpmLow = Math.Round(hr.bpmLow, 0),
                bpmHigh = Math.Round(hr.bpmHigh, 0),
                bpmAvg = Math.Round(hr.bpmAvg, 0)
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

        public async Task<List<GetAllHRDataMessage>> GetAllHeartRateData (UsernameData hr)
        {
            List<GetAllHRDataMessage> list = null;  
            try
            {
                list = await _heartRateRecordDao.GetAllHeartRateData(hr);
            }
            catch(Exception e)
            {
                throw new CustomException("Error at get all heart rate data in service " + e);
            }
            return list; 
        }

        public async Task<List<GetRestingHeartRateMsg>> GetRestingHeartRateHistory(UsernameData hr)
        {
            List<GetRestingHeartRateMsg> list = null;
            try
            {
                list = await _heartRateRecordDao.GetRestingHeartRateHistory(hr);
            }
            catch (Exception e)
            {
                throw new CustomException("Error at get all resting heart rate data in service " + e);
            }
            return list;
        }

        public async Task<List<GetExerciseHeartRateMsg>> GetExerciseHeartRateHistory(UsernameData hr)
        {
            List<GetExerciseHeartRateMsg> list = null;
            try
            {
                list = await _heartRateRecordDao.GetExerciseHeartRateHistory(hr);
            }
            catch (Exception e)
            {
                throw new CustomException("Error at get all resting heart rate data in service " + e);
            }
            return list;
        }

        public async Task<GetRestingRatesMsg> GetRestingRates(UsernameData d)
        {
            List<GetRestingHeartRateMsg> list = null;
            try
            {
                list = await _heartRateRecordDao.GetRestingHeartRateHistory(d);
            }
            catch (Exception e)
            {
                throw new CustomException("Error at get all resting heart rate data in service " + e);
            }
            return FormRestingRatesMessage(list);
        }

        private GetRestingRatesMsg FormRestingRatesMessage(List<GetRestingHeartRateMsg> list)
        {
            GetRestingRatesMsg message = new GetRestingRatesMsg();
            message.Dates = new List<string>();
            message.Rates = new List<double>();

            foreach (GetRestingHeartRateMsg msg in list)
            {
                message.Dates.Add(msg.startTime);
                message.Rates.Add(msg.bpmAvg);
            }
            return message;
        }

        private DateTime ConvertToDateTime(long unixDate)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddMilliseconds(unixDate).ToLocalTime();
        }
    }
}
