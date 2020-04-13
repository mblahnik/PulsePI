
namespace PulsePI.MessageContracts
{
    public class GetAllHRDataMessage
    {
        public string type { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public double bpmLow { get; set; }
        public double bpmHigh { get; set; }
        public double bpmAvg { get; set; }
    }
}
