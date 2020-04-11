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
        public async Task<IActionResult> GetAllHeartRateData([FromBody] GetAllHRData hrd)
        {
            List<GetAllHRDataResponse> list = null;
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
    }
}
