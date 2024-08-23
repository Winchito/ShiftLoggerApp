using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShiftLoggerFront.Models
{
    internal class WorkerShift
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        public int workerId { get; set; }
        public int shiftId { get; set; }
        public string workerShiftDate { get; set; }

    }
}
