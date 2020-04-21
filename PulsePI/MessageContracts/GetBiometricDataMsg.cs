using System;
namespace PulsePI.MessageContracts
{
    public class GetBiometricDataMsg
    {
        public string height { get; set; }
        public string weight { get; set; }
        public string sex { get; set; }
        public string dob { get; set; }
    }
}
