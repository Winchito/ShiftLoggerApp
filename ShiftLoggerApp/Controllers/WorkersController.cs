using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftLoggerApp.Models.Dtos;
using ShiftLoggerApp.Services;

namespace ShiftLoggerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
 
        private readonly WorkerService _workerService;
        public WorkersController(WorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public IActionResult GetWorkers()
        {
            var workers = _workerService.GetWorkers();

            return Ok(workers);
        }

        [HttpGet("{WorkerId:int}", Name = "GetWorker")]
        public IActionResult GetWorker(int WorkerId)
        {
            var worker = _workerService.GetWorker(WorkerId);

            if (worker == null)
            {
                return BadRequest();
            }
            return Ok(worker);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateWorker([FromForm] PostWorkerDto workerDto)
        {

            if (_workerService.WorkerNameExist(workerDto.FirstName, workerDto.LastName))
            {
                return StatusCode(400, "Worker already exists!");
            }
            var worker = _workerService.CreateWorker(workerDto);

            return CreatedAtRoute("GetWorker", new { WorkerId = worker.Id }, worker);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ModifyWorker([FromForm] PutWorkerDto postWorkerDto)
        {
            var worker = _workerService.WorkerExists(postWorkerDto.Id);

            if(worker == null)
            {
                return NotFound();
            }

            bool operation = _workerService.UpdateWorker(postWorkerDto);

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
            var worker = _workerService.WorkerExists(id);

            if (worker == null)
            {
                return NotFound();
            }

            bool operation = _workerService.DeleteWorker(id);

            if (operation)
            {
                return Ok();
            }

            return BadRequest();

        }




    }
}
