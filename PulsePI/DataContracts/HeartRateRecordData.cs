using System;

namespace PulsePI.DataContracts
{
    public class HeartRateRecordData
    {
        public string username { get; set; }
        public string type { get; set; }
        public long startTime { get; set; }
        public long endTime { get; set; }
        public double bpmLow { get; set; }
        public double bpmHigh { get; set; }
        public double bpmAvg { get; set; }
    }
}
