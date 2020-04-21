using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PulsePI.DataContracts;
using PulsePI.MessageContracts;
using PulsePI.Service.ServiceInterfaces;

namespace PulsePI.Controllers
{
    [Route("api/biometric")]
    public class BiometricDataController : Controller
    {
         IBiometricService _BiometricService;

        public BiometricDataController(IBiometricService bio)
        {
            _BiometricService = bio;
        }

        [HttpPost("createBiometric")]
        public async Task<IActionResult> CreateBiometric([FromBody] BiometricData bioData)
        {
            try
            {
                await _BiometricService.CreateBiometric(bioData);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPost("getIntensities")]
        public async Task<IActionResult> GetIntensities([FromBody] UsernameData data)
        {
            GetExerciseIntensityMsg intensity = null;
            try
            {
                intensity = await _BiometricService.GetIntensities(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(intensity);
        }


        [HttpPost("getBiometrics")]
        public async Task<IActionResult> GetBiometricData([FromBody] UsernameData data)
        {
            GetBiometricDataMsg bio = null;
            try
            {
                bio = await _BiometricService.GetBiometricData(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(bio);
        }

        [HttpPost("getTargetHR")]
        public async Task<IActionResult> GetTargetHeartRate([FromBody] UsernameData data)
        {
            GetTargetHrMsg msg = null;
            try
            {
                msg = await _BiometricService.GetTargetHeartRate(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(msg);
        }
    }
    
}
