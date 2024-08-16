using ShiftLoggerApp.Data;
using ShiftLoggerApp.Models;
using ShiftLoggerApp.Models.Dtos;

namespace ShiftLoggerApp.Services
{
    public class WorkerService
    {
        private readonly WorkerShiftContext _context;

        public WorkerService(WorkerShiftContext context)
        {
            _context = context;
        }

        public List<GetWorkerDto> GetWorkers()
        {
             var worker = _context.Workers.ToList();

            return worker.Select(w => new GetWorkerDto
            {
                Id = w.Id,
                FirstName = w.FirstName,
                LastName = w.LastName,
            }).ToList();
        }

        public GetWorkerDto GetWorker(int WorkerId)
        {
            var worker = _context.Workers.Find(WorkerId);

            return new GetWorkerDto
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
            };
        }


        public GetWorkerDto CreateWorker(PostWorkerDto workerDto)
        {
            Worker worker = new Worker()
            {
                FirstName = workerDto.FirstName,
                LastName = workerDto.LastName,
            };

                _context.Workers.Add(worker);
                _context.SaveChanges();
                return new GetWorkerDto
                {
                    Id = worker.Id,
                    FirstName = worker.FirstName,
                    LastName= worker.LastName,
                };
        }

        public Worker? WorkerExists(int id) => _context.Workers.Find(id);
        

        public bool UpdateWorker(PutWorkerDto postWorkerDto)
        {
            try
            {
                var worker = _context.Workers.FirstOrDefault(w => w.Id == postWorkerDto.Id);

                worker.FirstName = postWorkerDto.FirstName;
                worker.LastName = postWorkerDto.LastName;

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteWorker(int id)
        {
            try
            {
                var worker = _context.Workers.FirstOrDefault(w => w.Id == id);

                _context.Remove(worker);

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool WorkerNameExist(string workerFirstName, string workerLastName) 
        {

            if (_context.Workers.Any(c => c.FirstName.ToLower().Trim() == workerFirstName.ToLower().Trim()) && _context.Workers.Any(c => c.LastName.ToLower().Trim() == workerLastName.ToLower().Trim()))
            {
                return true;
            }

            return false;
        }

    }
}
