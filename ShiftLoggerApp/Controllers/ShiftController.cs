using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftLoggerApp.Models.Dtos;
using ShiftLoggerApp.Services;

namespace ShiftLoggerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly ShiftService _shiftService;
        public ShiftController(ShiftService shiftService) 
        {
            _shiftService = shiftService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetShifts()
        {
            var shifts = _shiftService.GetShifts();

            if (shifts == null)
            {
                return NoContent();
            }

            return Ok(shifts);
        }

        [HttpGet("{ShiftId:int}", Name = "GetShift")]
        public IActionResult GetShift(int ShiftId)
        {
            try
            {
                var shift = _shiftService.GetShift(ShiftId);

                if (shift == null)
                {
                    return NoContent();
                }

                return Ok(shift);
            }
            catch (Exception ex)
            {
                return NoContent();
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostShift([FromForm] PostShiftDto postShiftDto)
        {
            try
            {
                if (_shiftService.ShiftNameExist(postShiftDto.ShiftName))
                {
                    return StatusCode(400, "Shift already exists!");
                }
                var shift = _shiftService.CreateShift(postShiftDto);

                return CreatedAtRoute("GetShift", new {ShiftId = shift.Id}, shift);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was an error! Make sure of the format of StartTime and EndTime {HH:mm}");
            }
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PutWorker([FromForm] PutShiftDto putShiftDto)
        {
            var shift = _shiftService.ShiftExists(putShiftDto.Id);

            if(shift == null)
            {
                return NoContent();
            }

            bool operation = _shiftService.ModifyShift(putShiftDto);

            if (operation)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{ShiftId:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteShift(int ShiftId)
        {
            var shift = _shiftService.ShiftExists(ShiftId);

            if (shift == null)
            {
                return NoContent();
            }

            bool operation = _shiftService.DeleteShift(ShiftId);

            if (operation)
            {
                return Ok();
            }

            return BadRequest();

        }


    }
}
