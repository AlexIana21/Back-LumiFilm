using Microsoft.AspNetCore.Mvc;
using Models;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoController : ControllerBase
    {
        private static List<Sala> salas = SalaController.GetSalasList();

        [HttpGet("{salaId}")]
        public ActionResult<IEnumerable<Asiento>> GetAsientos(int salaId)
        {
            var sala = salas.FirstOrDefault(s => s.Id == salaId);
            if (sala == null)
            {
                return NotFound($"Sala con ID {salaId} no encontrada.");
            }

            return Ok(sala.Asientos);
        }

        [HttpPut("{salaId}/{fila}/{columna}/reservar")]
        public IActionResult ReservarAsiento(int salaId, string fila, int columna)
        {
            var sala = salas.FirstOrDefault(s => s.Id == salaId);
            if (sala == null)
            {
                return NotFound($"Sala con ID {salaId} no encontrada.");
            }

            var asiento = sala.Asientos.FirstOrDefault(a => a.Fila == fila && a.Columna == columna);
            if (asiento == null)
            {
                return NotFound($"Asiento en la fila {fila} y columna {columna} no encontrado en la sala {salaId}.");
            }

            
            if (asiento.Ocupado)
            {
                return Conflict($"El asiento en la fila {fila} y columna {columna} ya está reservado.");
            }

            // Reservar 
            asiento.Ocupado = true;
            return Ok($"Asiento en la fila {fila} y columna {columna} reservado exitosamente.");
        }
    }
}
