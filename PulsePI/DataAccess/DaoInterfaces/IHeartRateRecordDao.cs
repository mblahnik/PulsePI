using System.Threading.Tasks;
using PulsePI.Models;

namespace PulsePI.DataAccess.DaoInterfaces
{
    public interface IHeartRateRecordDao
    {
        Task RecordHeartRate(HeartRateRecord hr, string u);
    }
}
