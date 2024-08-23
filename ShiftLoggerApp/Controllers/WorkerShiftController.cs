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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ModifyWorkerShift([FromForm] PutWorkerShiftDto postWorkerShiftDto)
        {
            var worker = _workerShiftService.WorkerExists(postWorkerShiftDto.Id);

            if (worker == null)
            {
                return NotFound();
            }

            bool operation = _workerShiftService.UpdateWorkerShift(postWorkerShiftDto);

            if (operation)
            {
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteWorker(int id)
        {
            var worker = _workerShiftService.WorkerExists(id);

            if (worker == null)
            {
                return NotFound();
            }

            bool operation = _workerShiftService.DeleteWorkerShift(id);

            if (operation)
            {
                return Ok();
            }

            return BadRequest();

        }


    }
}
