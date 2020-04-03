using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PulsePI.DataContracts;
using PulsePI.Exceptions;
using PulsePI.Service.ServiceInterfaces;

namespace PulsePI.Controllers
{
    [Route("api/heartRate")]
    public class HeartRateRecordController : Controller 
    {
        IHeartRateRecordService _heartRateRecordService;

        public HeartRateRecordController(IHeartRateRecordService hrrs)
        {
            _heartRateRecordService = hrrs;
        }

        [HttpPost("record")]
        public async Task RecordHeartRate([FromBody] HeartRateRecordData hr)
        { 
            try
            {
                await _heartRateRecordService.RecordHeartRate(hr);
            }
            catch (Exception e)
            {
                throw new CustomException("Error at record heart rate in controller" + e);
            }
        }
    }
}
