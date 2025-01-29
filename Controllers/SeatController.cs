using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _serviceSeat;

        public SeatController(ISeatService serviceSeat)
        {
            _serviceSeat = serviceSeat;
        }

        [HttpGet]
        public async Task<ActionResult<List<Seat>>> GetSeat()
        {
            var seats = await _serviceSeat.GetAllAsync();
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetSeat(int id)
        {
            var seat = await _serviceSeat.GetByIdAsync(id);
            if (seat == null)
            {
                return NotFound($"Asiento con ID {id} no encontrado.");
            }
            return Ok(seat);
        }

        [HttpPost]
        public async Task<ActionResult<Seat>> CreateSeat(Seat seat)
        {
            var existingseat = await _serviceSeat.GetByIdAsync(seat.Id);
            if (existingseat != null)
            {
                return Conflict($"Ya existe un asiento con el ID {seat.Id}.");
            }

            await _serviceSeat.AddAsync(seat);
            return CreatedAtAction(nameof(GetSeat), new { id = seat.Id }, seat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeat(int id, Seat updateSeat)
        {
            var existingSeat = await _serviceSeat.GetByIdAsync(id);
            if (existingSeat == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }

            // Actualizar la sala existente
            existingSeat.Status = updateSeat.Status;
            existingSeat.Price = updateSeat.Price;
            existingSeat.Type = updateSeat.Type;
            existingSeat.ScreenId = updateSeat.ScreenId;

            await _serviceSeat.UpdateAsync(existingSeat);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            var seat = await _serviceSeat.GetByIdAsync(id);
            if (seat == null)
            {
                return NotFound($"Asiento con ID {id} no encontrado.");
            }

            await _serviceSeat.DeleteAsync(id);
            return NoContent();
        }
    }
}
