using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShiftLoggerFront.Models
{
    internal class Worker
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
