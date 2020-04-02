using System;
using System.Threading.Tasks;
using PulsePI.DataContracts;

namespace PulsePI.Service.ServiceInterfaces
{
    public interface IHeartRateRecordService
    {
        Task RecordHeartRate(HeartRateRecordData hr);
    }
}
