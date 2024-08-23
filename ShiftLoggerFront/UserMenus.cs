using ShiftLoggerFront.Models;
using ShiftLoggerFront.Services;

namespace ShiftLoggerFront
{
    internal class UserMenus
    {
        public static async Task ShowUserOptions()
        {
            bool exit = false;
            int option = 5;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("--------SHIFT LOGGER APP--------");
                    Console.Write("1. Shift Menu\n2. Worker Menu\n3. Worker Shift Menu\n0. Exit App\nSelect an Option: ");
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
                switch (option)
                {
                    case 0: exit = true; break;
                    case 1:
                        Console.Clear();
                        await ShiftMenu();
                        break;
                    case 2:
                        Console.Clear();
                        await WorkerMenu();
                        break;
                    case 3:
                        Console.Clear();
                        await WorkerShiftMenu();
                        break;
                    default:
                        Console.WriteLine("Select a valid option!");
                        break;
                }
            }

        }

        private static async Task ShiftMenu()
        {
            int id;
            bool exit = false;
            int option = 5;
            Shift shift = null;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("--------SHIFT MENU--------");
                    Console.Write("1. Get Shifts\n2. Get Shift by ID\n3. Create Shift\n4. Modify Shift\n5. Delete Shift\n0. Return to Main Menu\nSelect an option: ");
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }

                switch (option)
                {
                    case 0:
                        Console.Clear();
                        exit = true;
                        break;
                    case 1:
                        Console.Clear();
                        await ShiftService.GetShifts();
                        break;
                    case 2:
                        Console.Clear();
                        id = UserInput.GetId();
                        await ShiftService.GetShiftById(id);
                        break;
                    case 3:
                        Console.Clear();
                        shift = UserShiftInput.CreateShift();
                        await ShiftService.PostShift(shift);
                        break;
                    case 4:
                        Console.Clear();
                        await ShiftService.GetShifts();
                        id = UserInput.GetId();
                        shift = UserShiftInput.CreateShift();
                        await ShiftService.PutShift(id, shift);
                        break;
                    case 5:
                        Console.Clear();
                        await ShiftService.GetShifts();
                        id = UserInput.GetId();
                        await ShiftService.DeleteShift(id);
                        break;
                    default:
                        Console.WriteLine("Select a valid option!");
                        break;
                }
            }
        }

        private static async Task WorkerMenu()
        {
            int id;
            bool exit = false;
            int option = 5;
            Worker worker = null;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("--------WORKER MENU--------");
                    Console.Write("1. Get Workers\n2. Get Worker by ID\n3. Add Worker\n4. Modify Worker\n5. Delete Worker\n0. Return to Main Menu\nSelect an option: ");
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
                switch (option)
                {
                    case 0:
                        Console.Clear();
                        exit = true;
                        break;
                    case 1:
                        Console.Clear();
                        await WorkerService.GetWorkers();
                        break;
                    case 2:
                        Console.Clear();
                        id = UserInput.GetId();
                        await WorkerService.GetWorkerById(id);
                        break;
                    case 3:
                        Console.Clear();
                        worker = UserWorkerInput.CreateWorker();
                        await WorkerService.PostWorker(worker);
                        break;
                    case 4:
                        Console.Clear();
                        await WorkerService.GetWorkers();
                        id = UserInput.GetId();
                        worker = UserWorkerInput.CreateWorker();
                        await WorkerService.PutWorker(id, worker);
                        break;
                    case 5:
                        Console.Clear();
                        await WorkerService.GetWorkers();
                        id = UserInput.GetId();
                        await WorkerService.DeleteWorker(id);
                        break;
                    default:
                        Console.WriteLine("Select a valid option!");
                        break;
                }
            }

        }

        private static async Task WorkerShiftMenu()
        {
            bool exit = false;
            int option = 5;
            int id;
            string workerId, shiftId;
            WorkerShift workerShift = null;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("--------WORKER SHIFT MENU--------");
                    Console.Write("1. Get Worker Shifts\n2. Get Worker Shift by ID\n3. Create Worker Shift\n4. Modify Worker Shift\n5. Delete Worker Shift\n6. Get Worker Shift Details\n7. Get Worker Shift Details By ID \n0. Return to Main Menu\nSelect an option: ");
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }

                switch (option)
                {
                    case 0:
                        Console.Clear();
                        exit = true;
                        break;
                    case 1:
                        Console.Clear();
                        await WorkerShiftService.GetWorkerShifts();
                        break;
                    case 2:
                        Console.Clear();
                        id = UserInput.GetId();
                        await WorkerShiftService.GetWorkerShiftById(id);
                        break;
                    case 3:
                        Console.Clear();
                        await WorkerService.GetWorkers();
                        workerId = WorkerShiftUserInputs.SelectWorkerId();
                        await ShiftService.GetShifts();
                        shiftId = WorkerShiftUserInputs.SelectShiftId();
                        workerShift = WorkerShiftUserInputs.CreateWorkerShift(workerId, shiftId);
                        await WorkerShiftService.PostWorkerShift(workerShift);
                        break;
                    case 4:
                        Console.Clear();
                        await WorkerShiftService.GetWorkerShifts();
                        id = UserInput.GetId();
                        await WorkerService.GetWorkers();
                        workerId = WorkerShiftUserInputs.SelectWorkerId();
                        await ShiftService.GetShifts();
                        shiftId = WorkerShiftUserInputs.SelectShiftId();
                        workerShift = WorkerShiftUserInputs.CreateWorkerShift(workerId, shiftId);
                        await WorkerShiftService.PutWorkerShift(id, workerShift);
                        break;
                    case 5:
                        Console.Clear();
                        await WorkerShiftService.GetWorkerShifts();
                        id = UserInput.GetId();
                        await WorkerShiftService.DeleteWorkerShift(id);
                        break;
                    case 6:
                        Console.Clear();
                        await WorkerShiftService.GetWorkersShiftsDetails();
                        break;
                    case 7:
                        Console.Clear();
                        id = UserInput.GetId();
                        await WorkerShiftService.GetWorkerShiftDetailsById(id);
                        break;
                    default:
                        Console.WriteLine("Select a valid option!");
                        break;
                }
            }

        }
    }
}
