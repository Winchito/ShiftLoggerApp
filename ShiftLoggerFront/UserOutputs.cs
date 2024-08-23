using ConsoleTables;
using ShiftLoggerFront.Models;


namespace ShiftLoggerFront
{
    internal class ShiftUserOutputs
    {
        public static void ShowShifts(List<Shift> shifts)
        {

            var table = new ConsoleTable("ID", "Shift Name", "Start Time", "End Time", "Shift Duration");

            foreach (var shift in shifts)
            {
                table.AddRow(shift.Id, shift.shiftName, shift.startTime, shift.endTime, shift.Duration);
            }

            table.Write();
        }

        public static void ShowShift(Shift shift)
        {

            var table = new ConsoleTable("ID", "Shift Name", "Start Time", "End Time", "Shift Duration");

            table.AddRow(shift.Id, shift.shiftName, shift.startTime, shift.endTime, shift.Duration);
            
            table.Write();
        }
    }

    internal class WorkerUserOutputs
    {
        public static void ShowWorkers(List<Worker> workers)
        {

            var table = new ConsoleTable("ID", "First Name", "Last Name");

            foreach (var worker in workers)
            {
                table.AddRow(worker.Id, worker.firstName, worker.lastName);
            }

            table.Write();
        }

        public static void ShowWorker(Worker worker)
        {

            var table = new ConsoleTable("ID", "First Name", "Last Name");

            table.AddRow(worker.Id, worker.firstName, worker.lastName);

            table.Write();
        }
    }

    internal class WorkerShiftUserOutputs
    {
        public static void ShowWorkerShifts(List<WorkerShift> workerShifts)
        {

            var table = new ConsoleTable("ID", "Worker ID", "Shift ID", "Worker Shift Date");

            foreach (var workerShift in workerShifts)
            {
                table.AddRow(workerShift.Id, workerShift.workerId, workerShift.shiftId, workerShift.workerShiftDate);
            }

            table.Write();
        }

        public static void ShowWorkerShift(WorkerShift workerShift)
        {

            var table = new ConsoleTable("ID", "Worker ID", "Shift ID", "Worker Shift Date");

            table.AddRow(workerShift.Id, workerShift.workerId, workerShift.shiftId, workerShift.workerShiftDate);

            table.Write();
        }

        public static void ShowWorkersDetailsShifts(List<WorkerShiftDetails> workerShiftsDetails)
        {

            var table = new ConsoleTable("ID", "Worker Name", "Shift Name", "Start Time", "End Time", "Worker Shift Date");

            foreach (var workerShift in workerShiftsDetails)
            {
                table.AddRow(workerShift.Id, workerShift.workerName, workerShift.shiftName, workerShift.startTime, workerShift.endTime, workerShift.workerShiftDate);
            }

            table.Write();
        }
    }
}
