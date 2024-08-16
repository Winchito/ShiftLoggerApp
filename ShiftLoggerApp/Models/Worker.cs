﻿using System.ComponentModel.DataAnnotations;

namespace ShiftLoggerApp.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}
