using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PulsePI.DataContracts;
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
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok("Good job");
        }

        [HttpPost("getAllData")]
        public async Task<IActionResult> GetAllHeartRateData([FromBody] UsernameData hrd)
        {
            List<GetAllHRDataMessage> list = null;
            try
            {
                list = await _heartRateRecordService.GetAllHeartRateData(hrd);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(list);
        }

        [HttpPost("restingHistory")]
        public async Task<IActionResult> GetRestingHeartRateHistory([FromBody] UsernameData hrd)
        {
            List<GetRestingHeartRateMsg> list = null;
            try
            {
                list = await _heartRateRecordService.GetRestingHeartRateHistory(hrd);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(list);
        }

        [HttpPost("exerciseHistory")]
        public async Task<IActionResult> GetExerciseHeartRateHistory([FromBody] UsernameData hr)
        {
            List<GetExerciseHeartRateMsg> list = null;
            try
            {
                list = await _heartRateRecordService.GetExerciseHeartRateHistory(hr);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(list);
        }

        [HttpPost("restingRates")]
        public async Task<IActionResult> GetRestingRates([FromBody] UsernameData d)
        {
            GetRestingRatesMsg msg = null;
            try
            {
                msg = await _heartRateRecordService.GetRestingRates(d);
            }
            catch(Exception)
            {
                return BadRequest();
            }
            return Ok(msg);
        }
    }
}
