using System.ComponentModel.DataAnnotations;

namespace ShiftLoggerApp.Models.Dtos
{
    public class PostShiftDto
    {
        [Required]
        [MinLength(3)]
        public string ShiftName { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        [DisplayFormat(DataFormatString = "{HH:mm}")]
        public string StartTime { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        [DisplayFormat(DataFormatString = "{HH:mm}")]
        public string EndTime { get; set; }
    }

    public class GetShiftDto
    {
        public int Id { get; set; }
        public string ShiftName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Duration { get; set; }
    }

    public class PutShiftDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string ShiftName { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        [DisplayFormat(DataFormatString = "{HH:mm}")]
        public string StartTime { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        [DisplayFormat(DataFormatString = "{HH:mm}")]
        public string EndTime { get; set; }
    }
}
