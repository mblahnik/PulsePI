using System;
using System.Collections.Generic;

namespace PulsePI.MessageContracts
{
    public class GetRestingRatesMsg
    {
        public List<string> Dates { get; set; }
        public List<double> Rates { get; set; }
    }
}
