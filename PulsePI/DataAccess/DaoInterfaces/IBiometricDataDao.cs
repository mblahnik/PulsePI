using Microsoft.AspNetCore.Mvc;
using PulsePI.DataContracts;
using PulsePI.MessageContracts;
using PulsePI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PulsePI.DataAccess.DaoInterfaces
{
    public interface IBiometricDataDao
    {
        Task CreateBiometricData(Biometric b, string u);
        Task<Biometric> GetMostRecentRecord(UsernameData data);
    }
}
