﻿using System;
using System.Threading.Tasks;
using PulsePI.DataContracts;
using PulsePI.Models;

namespace PulsePI.DataAccess.DaoInterfaces
{
    public interface IHeartRateRecordDao
    {
        Task RecordHeartRate(HeartRateRecordData hr);
    }
}
