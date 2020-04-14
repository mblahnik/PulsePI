using System.Collections.Generic;
using System.Threading.Tasks;
using PulsePI.DataContracts;
using PulsePI.MessageContracts;
using PulsePI.Models;

namespace PulsePI.DataAccess.DaoInterfaces
{
    public interface IHeartRateRecordDao
    {
        Task RecordHeartRate(HeartRateRecord hr, string u);
        Task<List<GetAllHRDataMessage>> GetAllHeartRateData(GetHRData hrd);
        Task<List<GetRestingHeartRateMsg>> GetRestingHeartRateHistory(GetHRData hr);
        Task<List<GetExerciseHeartRateMsg>> GetExerciseHeartRateHistory(GetHRData hr);
    }
}
