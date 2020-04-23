using System;
namespace PulsePI.MessageContracts
{
    public class GetRangesMsg
    {
        public double fiftyPerc { get; set; }
        public double sixtyPerc { get; set; }
        public double seventyPerc { get; set; }
        public double eightyPerc { get; set; }
        public double ninetyPerc { get; set; }
        public double hundPerc { get; set; }
    }
}
