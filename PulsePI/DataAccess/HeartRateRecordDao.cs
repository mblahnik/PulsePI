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
    public class HeartRateRecordDao : IHeartRateRecordDao
    {
        private readonly IConfiguration _config;
        private readonly PulsePiDBContext _context;

        public HeartRateRecordDao(IConfiguration conf, PulsePiDBContext context)
        {
            _config = conf;
            _context = context;
        }

        public async Task RecordHeartRate(HeartRateRecord hrr, string username)
        {
            try
            {
                //Find the account that this HR data is for 
                Account acc = await _context.accounts.Where(x => x.username == username).FirstOrDefaultAsync();
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

        public async Task<List<GetAllHRDataMessage>> GetAllHeartRateData(UsernameData hrd)
        {
            List<GetAllHRDataMessage> something = null;
            try
            {
                Account acc = await _context.accounts.Where(x => x.username == hrd.username).FirstOrDefaultAsync();
                if (acc == null) throw new InvalidOperationException("There is no account matching the username");

                something = await _context.heartRateRecords.Where(x => x.accountId == acc.Id)
                    .Select(x => new GetAllHRDataMessage()
                    {
                        type = x.type,
                        startTime = x.startTime.ToString(),
                        endTime = x.endTime.ToString(),
                        bpmLow = x.bpmLow,
                        bpmHigh = x.bpmHigh,
                        bpmAvg = Math.Round(x.bpmAvg, 0)
                    }).ToListAsync();
            }
            catch (Exception e)
            {
                throw new CustomException("Database error while trying to get all hr data " + e);
            }
            return something;
        }

        public async Task<List<GetRestingHeartRateMsg>> GetRestingHeartRateHistory(UsernameData hr)
        {
            List<GetRestingHeartRateMsg> something = null;
            try
            {
                Account acc = await _context.accounts.Where(x => x.username == hr.username).FirstOrDefaultAsync();
                if (acc == null) throw new InvalidOperationException("There is no account matching the username");

                something = await _context.heartRateRecords.Where(x => x.accountId == acc.Id && x.type == "Sleeping")
                    .Select(x => new GetRestingHeartRateMsg()
                    {
                        type = x.type,
                        startTime = x.startTime.ToString(),
                        endTime = x.endTime.ToString(),
                        bpmLow = x.bpmLow,
                        bpmHigh = x.bpmHigh,
                        bpmAvg = Math.Round(x.bpmAvg, 0)
                    }).ToListAsync();
            }
            catch (Exception e)
            {
                throw new CustomException("Database error while trying to get resting hr data " + e);
            }
            return something;
        }

        public async Task<List<GetExerciseHeartRateMsg>> GetExerciseHeartRateHistory(UsernameData hr)
        {
            List<GetExerciseHeartRateMsg> something = null;
            try
            {
                Account acc = await _context.accounts.Where(x => x.username == hr.username).FirstOrDefaultAsync();
                if (acc == null) throw new InvalidOperationException("There is no account matching the username");

                something = await _context.heartRateRecords.Where(x => x.accountId == acc.Id && x.type != "Sleeping")
                    .Select(x => new GetExerciseHeartRateMsg()
                    {
                        type = x.type,
                        startTime = x.startTime.ToString(),
                        endTime = x.endTime.ToString(),
                        bpmLow = x.bpmLow,
                        bpmHigh = x.bpmHigh,
                        bpmAvg = Math.Round(x.bpmAvg, 0)
                    }).ToListAsync();
            }
            catch (Exception e)
            {
                throw new CustomException("Database error while trying to get exercise hr data " + e);
            }
            return something;
        }
    }
}
