using System.Collections.Generic;
using System.Threading.Tasks;
using PulsePI.DataContracts;
using PulsePI.MessageContracts;

namespace PulsePI.Service.ServiceInterfaces
{
    public interface IHeartRateRecordService
    {
        Task RecordHeartRate(HeartRateRecordData hr);
        Task<List<GetAllHRDataMessage>> GetAllHeartRateData(GetHRData hr);
        Task<List<GetRestingHeartRateMsg>> GetRestingHeartRateHistory(GetHRData hr);
        Task<List<GetExerciseHeartRateMsg>> GetExerciseHeartRateHistory(GetHRData hr);
    }
}
