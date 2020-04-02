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
        public async Task RecordHeartRate(HeartRateRecordData hr)
        {
            using(var context = new PulsePiDBContext())
            { 
                try
                {
                    //Find the account that this HR data is for 
                    Account acc = await context.accounts.Where(x => x.username == hr.username).FirstOrDefaultAsync();
                    if (acc == null) throw new InvalidOperationException("There is no account matching the username");

                    //Create a record 
                    var heartRateRecord = new HeartRateRecord()
                    {
                        accountId = acc.Id,
                        account = acc,
                        type = hr.type,
                        startTime = hr.startTime,
                        endTime = hr.endTime,
                        bpmLow = hr.bpmLow,
                        bpmHigh = hr.bpmHigh,
                        bpmAvg = hr.bpmAvg
                    };

                    //Add the record to the DB and save 
                    context.heartRateRecords.Add(heartRateRecord);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new CustomException("Database error while trying to create heart rate record " + e);
                }
            }     
        }
    }
}
