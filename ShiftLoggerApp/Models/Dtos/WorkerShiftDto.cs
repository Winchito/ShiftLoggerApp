namespace ShiftLoggerApp.Models.Dtos
{
    public class GetWorkerShiftDto
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ShiftId { get; set; }
        public string WorkerShiftDate { get; set; }

    }

    public class PostWorkerShiftDto
    {
        public int WorkerId { get; set; }
        public int ShiftId { get; set; }
    }

    public class PutWorkerShiftDto
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ShiftId { get; set; }
    }

    public class  WorkerShiftDetailsDto
    {
        public int Id { get; set; }
        public string WorkerName { get; set; }
        public string ShiftName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string WorkerShiftDate { get; set; }

    }
}
