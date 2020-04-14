using System;
using System.Collections.Generic;

namespace PulsePI.MessageContracts
{
    public class GetExerciseIntensityMsg
    {
        public List<string> Dates { get; set; }
        public List<double> Percentages { get; set; }
    }
}
