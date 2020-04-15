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
        Task<List<GetAllHRDataMessage>> GetAllHeartRateData(UsernameData hrd);
        Task<List<GetRestingHeartRateMsg>> GetRestingHeartRateHistory(UsernameData hr);
        Task<List<GetExerciseHeartRateMsg>> GetExerciseHeartRateHistory(UsernameData hr);
    }
}
