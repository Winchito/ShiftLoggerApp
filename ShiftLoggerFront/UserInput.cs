using System.Globalization;
using System.Text.RegularExpressions;
using ShiftLoggerFront.Models;


namespace ShiftLoggerFront
{
    internal class UserInput
    {
        public static int GetId()
        {
            int option;
            bool valid;
            Console.Write("Select an ID: ");
            do
            {
                string input = Console.ReadLine();
                valid = int.TryParse(input, out option);
                if (!valid || option == 0) Console.Write("Insert a valid option: ");
            } while (!valid || option == 0);

            return option;
        }

    }

    internal class UserShiftInput
    {
        public static Shift CreateShift()
        {
            DateTime initialTime, finalTime;
            string shiftName, startTime, endTime;
            Console.WriteLine("Insert shift name or type 0 to exit: ");
            shiftName = Console.ReadLine();
            if (shiftName == "0") UserMenus.ShowUserOptions();

            while (shiftName == null || shiftName.Count() < 3)
            {
                Console.WriteLine("Invalid format! Try again!");
                shiftName = Console.ReadLine();
            }
            Console.WriteLine("Insert shift start time in {HH:mm} format: ");
            startTime = Console.ReadLine();

            while (!DateTime.TryParseExact(startTime, "HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out initialTime))
            {
                Console.WriteLine("Not a valid format!: ");
                startTime = Console.ReadLine();
            }

            startTime = initialTime.ToString("HH:mm");

            Console.WriteLine("Insert shift end time in {HH:mm} format: ");
            endTime = Console.ReadLine();

            while (!DateTime.TryParseExact(endTime, "HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out finalTime))
            {
                Console.WriteLine("Not a valid format!: ");
                endTime = Console.ReadLine();
            }

            endTime = finalTime.ToString("HH:mm");

            Shift shift = new Shift
            {
                shiftName = shiftName,
                startTime = startTime,
                endTime = endTime
            };

            return shift;
            //await ShiftService.PostShift(shift);
        }
    }

    internal class UserWorkerInput()
    {
        public static Worker CreateWorker()
        {
            string firstName, lastName;
            Console.WriteLine("Insert the first name of the Worker or type 0 to exit: ");
            firstName = Console.ReadLine();

            if (firstName == "0") UserMenus.ShowUserOptions();

            while (firstName == null || firstName.Count() < 3)
            {
                Console.WriteLine("Invalid format! Try again!");
                firstName = Console.ReadLine();
            }

            Console.WriteLine("Insert the first name of the Worker or type 0 to exit: ");
            lastName = Console.ReadLine();

            if (lastName == "0") UserMenus.ShowUserOptions();

            while (lastName == null || lastName.Count() < 2)
            {
                Console.WriteLine("Invalid format! Try again!");
                lastName = Console.ReadLine();
            }

            return new Worker
            {
                firstName = firstName,
                lastName = lastName
            };
        }
    }

    internal class WorkerShiftUserInputs
    {
        public static string SelectWorkerId()
        {
            string workerId;
            Console.WriteLine("Insert the worker ID");
            workerId = Console.ReadLine();
            while(workerId == null || !Regex.Match(workerId, @"^[0-9]").Success)
            {
                Console.WriteLine("Invalid format! select a valid Worker");
                workerId = Console.ReadLine();
            }
            return workerId;
        }

        public static string SelectShiftId()
        {
            string shiftId;
            Console.WriteLine("Insert the shift ID");
            shiftId = Console.ReadLine();
            while (shiftId == null || !Regex.Match(shiftId, @"^[0-9]").Success)
            {
                Console.WriteLine("Invalid format! select a valid Worker");
                shiftId = Console.ReadLine();
            }
            return shiftId;
        }

        public static WorkerShift CreateWorkerShift(string workerId, string shiftId)
        {
            return new WorkerShift
            {
                workerId = Convert.ToInt32(workerId),
                shiftId = Int32.Parse(shiftId)
            };
        }
    }

}

