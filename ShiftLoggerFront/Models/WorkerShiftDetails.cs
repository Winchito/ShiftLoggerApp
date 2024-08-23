using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShiftLoggerFront.Models
{
    internal class WorkerShiftDetails
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        public string workerName { get; set; }
        public string shiftName { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string workerShiftDate { get; set; }
    }
}
