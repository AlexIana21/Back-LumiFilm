using Microsoft.AspNetCore.Mvc;
using Models;
using Utils;

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
            try
            {
                // Busca la sesión por el id
                var sesion = SesionController.GetSesionesList().FirstOrDefault(s => s.Id == ticket.SesionId);
                if (sesion == null)
                {
                    return NotFound($"No se encontró la sesión con ID {ticket.SesionId}.");
                }

                // Reserva el asiento elegido si no está ocupado y si existe
                foreach (var asientoReservado in ticket.AsientosReservados)
                {
                    var asientoSesion = sesion.Asientos.FirstOrDefault(a =>
                        a.Columna == asientoReservado.Columna && a.Fila == asientoReservado.Fila);

                    if (asientoSesion == null)
                    {
                        return BadRequest($"El asiento {asientoReservado.Fila}{asientoReservado.Columna} no existe.");
                    }
                    if (asientoSesion.Ocupado)
                    {
                        return BadRequest($"El asiento {asientoReservado.Fila}{asientoReservado.Columna} ya está ocupado.");
                    }

                    asientoSesion.Ocupado = true;
                }

                tickets.Add(ticket);

                return Ok(ticket);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return StatusCode(500, new { mensaje = "Hubo un error al crear el ticket." });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTicket(int id, Ticket updateTicket)
        {
            var ticket = tickets.FirstOrDefault(p => p.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            ticket.AsientosReservados = updateTicket.AsientosReservados;
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