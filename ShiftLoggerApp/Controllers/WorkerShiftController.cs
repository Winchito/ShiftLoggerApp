using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftLoggerApp.Models;
using ShiftLoggerApp.Models.Dtos;
using ShiftLoggerApp.Services;

namespace ShiftLoggerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerShiftController : ControllerBase
    {
        private readonly WorkerShiftService _workerShiftService;
        public WorkerShiftController(WorkerShiftService workerShiftService) 
        {
            _workerShiftService = workerShiftService;
        }

        [HttpGet]
        public IActionResult GetShifts()
        {
            var workerShifts = _workerShiftService.GetWorkerShifts();

            if (workerShifts == null)
            {
                return NoContent();
            }

            return Ok(workerShifts);
        }

        [HttpGet("{WorkerShiftId:int}", Name = "GetWorkerShift")]
        public IActionResult GetWorkerShift(int WorkerShiftId)
        {
            var workerShift = _workerShiftService.GetWorkerShift(WorkerShiftId);

            if (workerShift == null)
            {
                return NoContent();
            }

            return Ok(workerShift);
        }

        [HttpPost]
        public IActionResult PostShifts([FromForm] PostWorkerShiftDto postWorkerDto) 
        {
            try
            {
                var workerShift = _workerShiftService.PostWorkerShift(postWorkerDto);
                return CreatedAtRoute("GetWorkerShift", new { WorkerShiftId = workerShift.Id }, workerShift);
            }
            catch
            {
                return StatusCode(500, "There was an error posting the Worker Shift!");
            }   

        }

        [HttpGet("GetWorkerShiftsDetails")]
        public IActionResult GetWorkerShiftsDetails()
        {
            var workerShifts = _workerShiftService.GetWorkerShiftsDetails();

            if (workerShifts == null)
            {
                return NoContent();
            }

            return Ok(workerShifts);
        }


        [HttpGet("GetWorkerShiftDetails/{id:int}")]
        public IActionResult GetWorkerShiftDetails(int id)
        {
            var workerShift = _workerShiftService.GetWorkerShiftDetails(id);

            if (workerShift == null)
            {
                return NoContent();
            }

            return Ok(workerShift);
        }

    }
}
