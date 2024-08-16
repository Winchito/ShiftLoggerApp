using System.ComponentModel.DataAnnotations;

namespace ShiftLoggerApp.Models
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ShiftName { get; set; }
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
        public string Duration { get; set; }

    }
}
