using Humanizer;
using ShiftLoggerApp.Data;
using ShiftLoggerApp.Models;
using ShiftLoggerApp.Models.Dtos;

namespace ShiftLoggerApp.Services
{
    public class WorkerShiftService
    {
        private readonly WorkerShiftContext _context;
        public WorkerShiftService(WorkerShiftContext context) 
        {
            _context = context;
        }

        public List<GetWorkerShiftDto> GetWorkerShifts()
        {
            var workerShift = _context.WorkerShifts.ToList();

            return workerShift.Select(x => new GetWorkerShiftDto
            {
                Id = x.Id,
                WorkerId = x.WorkerId,
                ShiftId = x.ShiftId,
                WorkerShiftDate = x.WorkerShiftDate
            }).ToList();
        }

        public GetWorkerShiftDto GetWorkerShift(int id)
        {
            var workerShift = _context.WorkerShifts.FirstOrDefault(x => x.Id == id);

            return new GetWorkerShiftDto
            {
                Id = workerShift.Id,
                WorkerId = workerShift.WorkerId,
                ShiftId = workerShift.ShiftId,
                WorkerShiftDate = workerShift.WorkerShiftDate
            };
        }

        public List<WorkerShiftDetailsDto> GetWorkerShiftsDetails()
        {
            var workerShift = _context.WorkerShifts.Select(ws => new WorkerShiftDetailsDto
            {
                Id = ws.Id,
                WorkerName = $"{ws.Worker.FirstName} {ws.Worker.LastName}",
                ShiftName = ws.Shift.ShiftName,
                StartTime = ws.Shift.StartTime,
                EndTime = ws.Shift.EndTime,
                WorkerShiftDate = ws.WorkerShiftDate
            }).ToList();

            return workerShift;
        }


        public List<WorkerShiftDetailsDto> GetWorkerShiftDetails(int id)
        {
            var workerShift = _context.WorkerShifts.Where(ws => ws.Id == id).Select(ws => new WorkerShiftDetailsDto
            {
                Id = ws.Id,
                WorkerName = $"{ws.Worker.FirstName} {ws.Worker.LastName}",
                ShiftName = ws.Shift.ShiftName,
                StartTime = ws.Shift.StartTime,
                EndTime = ws.Shift.EndTime,
                WorkerShiftDate = ws.WorkerShiftDate

            }).ToList();

            return workerShift;
        }

        public GetWorkerShiftDto PostWorkerShift(PostWorkerShiftDto postWorkerShiftDto)
        {
            WorkerShift workerShift = new WorkerShift
            {
                WorkerId = postWorkerShiftDto.WorkerId,
                ShiftId = postWorkerShiftDto.ShiftId,
                WorkerShiftDate = DateTime.Now.ToString("dd/MM/yyyy")
            };

                _context.WorkerShifts.Add(workerShift);
                _context.SaveChanges();

            return new GetWorkerShiftDto
            {
                Id = workerShift.Id,
                WorkerId = workerShift.WorkerId,
                ShiftId = workerShift.ShiftId,
                WorkerShiftDate = workerShift.WorkerShiftDate
            };
 
        }

        //TODO Update and Delete Methods

    }
}
