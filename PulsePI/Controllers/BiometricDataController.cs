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
       [Route("api/biometric")]
    public class BiometricDataController : ControllerBase
    {
         IBiometricService _BiometricService;

        public BiometricDataController(IBiometricService bio)
        {
            _BiometricService = bio;
        }

        [HttpPost("createBiometric")]
        public async Task<IActionResult> createBiometric([FromBody] BiometricData bioData)
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
    }
}
