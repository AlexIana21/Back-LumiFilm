using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _serviceTicket;

        public TicketController(ITicketService serviceTicket)
        {
            _serviceTicket = serviceTicket;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> GetTickets()
        {
            var tickets = await _serviceTicket.GetAllAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _serviceTicket.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound($"Ticket con ID {id} no encontrado.");
            }
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> CreateTicket(Ticket ticket)
        {
            try
            {
                var result = await _serviceTicket.CreateTicketAsync(ticket);
                if (result == null)
                {
                    return BadRequest("No se pudo crear el ticket. Verifica los datos.");
                }
                return CreatedAtAction(nameof(GetTicket), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                // Registra el error y responde con un código 500
                return StatusCode(500, new { mensaje = "Hubo un error al crear el ticket.", error = ex.Message });
            }
        }

        [HttpPost("{id}/cancelar")]
        public async Task<IActionResult> CancelarTicket(int id)
        {
            var ticket = await _serviceTicket.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound($"Ticket con ID {id} no encontrado.");
            }

            var result = await _serviceTicket.CancelTicketAsync(id);
            if (!result)
            {
                return BadRequest("No se pudo cancelar el ticket. Verifica los datos.");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, Ticket updatedTicket)
        {
            var existingTicket = await _serviceTicket.GetByIdAsync(id);
            if (existingTicket == null)
            {
                return NotFound($"Ticket con ID {id} no encontrado.");
            }

            await _serviceTicket.UpdateAsync(id, updatedTicket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _serviceTicket.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound($"Ticket con ID {id} no encontrado.");
            }

            await _serviceTicket.DeleteAsync(id);
            return NoContent();
        }
    }
}
