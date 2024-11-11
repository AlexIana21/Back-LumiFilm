using Microsoft.AspNetCore.Mvc;
using Models;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TicketController : ControllerBase 
    {
        private static List<Ticket> tickets = new List<Ticket>();

        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> GetTicket()
        {
           return Ok(tickets);
        }

        [HttpGet("{id}")]
        public ActionResult<Ticket> GetTicket(int id)
        {
            var ticket = tickets.FirstOrDefault(p => p.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpPost]
        public ActionResult<Ticket> CreateTicket(Ticket ticket)
        {
           tickets.Add(ticket);
           return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTicket(int id, Ticket updateTicket)
        {
            var ticket = tickets.FirstOrDefault(p => p.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            ticket.Pelicula = updateTicket.Pelicula;
            ticket.Sala = updateTicket.Sala;
            ticket.AsientosReservados = updateTicket.AsientosReservados;
            ticket.entradas = updateTicket.entradas;
            ticket.FechaTicket = updateTicket.FechaTicket;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(int id)
        {
            var ticket = tickets.FirstOrDefault(p => p.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            tickets.Remove(ticket);
            return NoContent();
        }
    }
}