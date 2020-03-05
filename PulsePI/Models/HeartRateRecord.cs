using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PulsePI.Models
{
    public class HeartRateRecord
    {
        public int Id { get; set; }
        public Account account { get; set; }
        [ForeignKey("Account")]
        public int accountId { get; set; }
        [StringLength(25)]
        public string type { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public double bpmLow { get; set; }
        public double bpmHigh { get; set; }
        public double bpmAvg { get; set; }
    }
}
