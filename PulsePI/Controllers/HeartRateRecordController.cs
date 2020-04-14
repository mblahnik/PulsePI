using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PulsePI.DataContracts;
using PulsePI.Exceptions;
using PulsePI.Service.ServiceInterfaces;
using PulsePI.MessageContracts;
using System.Collections.Generic;

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
        public async Task<IActionResult> RecordHeartRate([FromBody] HeartRateRecordData hr)
        { 
            try
            {
                await _heartRateRecordService.RecordHeartRate(hr);
            }
            catch (Exception e)
            {
                throw new CustomException("Error at record heart rate in controller" + e);
            }
            return Ok("Good job");
        }

        [HttpPost("getAllData")]
        public async Task<IActionResult> GetAllHeartRateData([FromBody] GetHRData hrd)
        {
            List<GetAllHRDataMessage> list = null;
            try
            {
                list = await _heartRateRecordService.GetAllHeartRateData(hrd);
            }
            catch (Exception e)
            {
                throw new CustomException("Error at get all heart rate data in controller " + e);
            }
            return Ok(list);
        }

        [HttpPost("restingHistory")]
        public async Task<IActionResult> GetRestingHeartRateHistory([FromBody] GetHRData hrd)
        {
            List<GetRestingHeartRateMsg> list = null;
            try
            {
                list = await _heartRateRecordService.GetRestingHeartRateHistory(hrd);
            }
            catch (Exception e)
            {
                throw new CustomException("Error at get all resting heart rate data in controller " + e);
            }
            return Ok(list);
        }

        [HttpPost("exerciseHistory")]
        public async Task<IActionResult> GetExerciseHeartRateHistory([FromBody] GetHRData hr)
        {
            List<GetExerciseHeartRateMsg> list = null;
            try
            {
                list = await _heartRateRecordService.GetExerciseHeartRateHistory(hr);
            }
            catch (Exception e)
            {
                throw new CustomException("Error at get all resting heart rate data in controller " + e);
            }
            return Ok(list);
        }
    }
}
