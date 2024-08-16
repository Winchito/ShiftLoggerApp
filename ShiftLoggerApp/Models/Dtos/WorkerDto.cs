using System.ComponentModel.DataAnnotations;

namespace ShiftLoggerApp.Models.Dtos
{
    public class PostWorkerDto
    {
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
    }

    public class GetWorkerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }


    public class PutWorkerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }



}
