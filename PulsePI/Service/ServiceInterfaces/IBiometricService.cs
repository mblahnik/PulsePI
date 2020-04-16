using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PulsePI.DataContracts;
using PulsePI.MessageContracts;

namespace PulsePI.Service.ServiceInterfaces
{
    public interface IBiometricService
    {
        Task CreateBiometric(BiometricData b, string u);
        Task<GetExerciseIntensityMsg> GetIntensities(UsernameData data);
    }
}
