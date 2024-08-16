using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShiftLoggerApp.Models
{
    public class WorkerShift
    {
        [Key]
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ShiftId { get; set; }
        public string WorkerShiftDate { get; set; }

        [ForeignKey("WorkerId")]
        public Worker Worker { get; set; }
        [ForeignKey("ShiftId")]
        public Shift Shift { get; set; }

    }
}
