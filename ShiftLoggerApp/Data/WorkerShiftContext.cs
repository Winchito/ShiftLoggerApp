using Microsoft.EntityFrameworkCore;
using ShiftLoggerApp.Models;

namespace ShiftLoggerApp.Data
{
    public class WorkerShiftContext: DbContext
    {
        public WorkerShiftContext(DbContextOptions<WorkerShiftContext> options): base(options)
        {

        }

        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerShift> WorkerShifts { get; set; }
    }
}
