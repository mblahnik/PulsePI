using System;
namespace PulsePI.MessageContracts
{
    public class GetExerciseHeartRateMsg
    {
        public string type { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public double bpmLow { get; set; }
        public double bpmHigh { get; set; }
        public double bpmAvg { get; set; }
    }
}
