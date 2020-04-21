using System;
namespace PulsePI.MessageContracts
{
    public class GetHRBoundsMsg
    {
        public double maxHR { get; set; }
        public double heartRateReserve { get; set; }
        public double targetHR { get; set; }
    }
}
