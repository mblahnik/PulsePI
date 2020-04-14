using System.Collections.Generic;
using System.Threading.Tasks;
using PulsePI.DataContracts;
using PulsePI.MessageContracts;

namespace PulsePI.Service.ServiceInterfaces
{
    public interface IHeartRateRecordService
    {
        Task RecordHeartRate(HeartRateRecordData hr);
        Task<List<GetAllHRDataMessage>> GetAllHeartRateData(UsernameData hr);
        Task<List<GetRestingHeartRateMsg>> GetRestingHeartRateHistory(UsernameData hr);
        Task<List<GetExerciseHeartRateMsg>> GetExerciseHeartRateHistory(UsernameData hr);
    }
}
