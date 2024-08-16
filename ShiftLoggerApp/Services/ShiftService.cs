using Microsoft.EntityFrameworkCore;
using ShiftLoggerApp.Data;
using ShiftLoggerApp.Models;
using ShiftLoggerApp.Models.Dtos;

namespace ShiftLoggerApp.Services
{
    public class ShiftService
    {
        private readonly WorkerShiftContext _context;
        public ShiftService(WorkerShiftContext dbContext)
        {
            _context = dbContext;
        }


        public List<GetShiftDto> GetShifts()
        {
            var shifts = _context.Shifts.ToList();

            return shifts.Select(s => new GetShiftDto {
                Id = s.Id,
                ShiftName = s.ShiftName,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                Duration = s.Duration,
            }).ToList();
        }

        public GetShiftDto GetShift(int id)
        {
            var shift = _context.Shifts.Find(id);

            return new GetShiftDto
            {
                Id = shift.Id,
                ShiftName = shift.ShiftName,
                StartTime = shift.StartTime,
                EndTime = shift.EndTime,
                Duration = shift.Duration,
            };
        }

        public GetShiftDto CreateShift(PostShiftDto postShiftDto)
        {

            var StartTimeDate = CreateDate(postShiftDto.StartTime);
            var EndTimeDate = CreateDate(postShiftDto.EndTime);

           
            var Duration = EndTimeDate - StartTimeDate;


            Shift shift = new Shift
            {
                ShiftName = postShiftDto.ShiftName,
                //StartTime = $"{StartTimeDate.Hour}:{StartTimeDate.Minute}",
                StartTime = StartTimeDate.ToString("hh:mm tt"),
                EndTime = EndTimeDate.ToString("hh:mm tt"),
                Duration = $"{Duration.Hours}:{Duration.Minutes}"

            };

            _context.Shifts.Add(shift);
            _context.SaveChanges();

            return new GetShiftDto
            {
                Id = shift.Id,
                ShiftName = shift.ShiftName,
                StartTime = shift.StartTime,
                EndTime = shift.EndTime,
                Duration = $"{Duration.Hours}:{Duration.Minutes}"
            };

        }

        private DateTime CreateDate(string hourString) => DateTime.ParseExact(hourString, "H:mm", null, System.Globalization.DateTimeStyles.None);

        public Shift? ShiftExists(int id) => _context.Shifts.Find(id);


        public bool ModifyShift(PutShiftDto putShiftDto)
        {
            try
            {
                        
                var NewStartTime = CreateDate(putShiftDto.StartTime);
                var NewEndTime = CreateDate(putShiftDto.EndTime);
                var newDuration = NewEndTime - NewStartTime;

                var shift = _context.Shifts.FirstOrDefault(s => s.Id == putShiftDto.Id);

                shift.ShiftName = putShiftDto.ShiftName;
                shift.StartTime = NewStartTime.ToString("hh:mm tt");
                shift.EndTime = NewEndTime.ToString("hh:mm tt");
                shift.Duration = $"{newDuration.Hours}:{newDuration.Minutes}";

                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteShift(int id)
        {
            try
            {
                var shift = _context.Shifts.FirstOrDefault(s => s.Id == id);

                _context.Remove(shift);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool ShiftNameExist(string shiftName) => _context.Shifts.Any(c => c.ShiftName.ToLower().Trim() == shiftName.ToLower().Trim());

    }
}
