using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PulsePI.DataContracts;
using PulsePI.MessageContracts;

namespace PulsePI.Service.ServiceInterfaces
{
    public interface IBiometricService
    {
        Task CreateBiometric(BiometricData b);
        Task<GetExerciseIntensityMsg> GetIntensities(UsernameData data);
        Task<GetBiometricDataMsg> GetBiometricData(UsernameData data);
    }
}
