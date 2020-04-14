using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PulsePI.DataContracts;
using PulsePI.MessageContracts;
using PulsePI.Service.ServiceInterfaces;

namespace PulsePI.Controllers
{
       [Route("api/biometric")]
    public class BiometricDataController : ControllerBase
    {
         IBiometricService _BiometricService;

        public BiometricController(IBiometricService bio)
        {
            _biometricService = bio;
        }
        [HttpPost("createBiometric")]
        
    }
}
