using Microsoft.AspNetCore.Mvc;
using Models;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoController : ControllerBase
    {
        private static List<Sesion> sesiones = SesionController.GetSesionesList();

        // Obtener asientos por sesión
        [HttpGet("sesion/{sesionId}")]
        public ActionResult<IEnumerable<Asiento>> GetAsientos(int sesionId)
        {
            var sesion = sesiones.FirstOrDefault(s => s.Id == sesionId);
            if (sesion == null)
            {
                return NotFound($"Sesión con ID {sesionId} no encontrada.");
            }

            var asientos = sesion.Asientos;
            if (!asientos.Any())
            {
                return NotFound($"No hay asientos disponibles para la sesión con ID {sesionId}.");
            }

            return Ok(asientos);
        }

        // Reservar asiento en una sesión específica
        [HttpPut("sesion/{sesionId}/{fila}/{columna}/reservar")]
        public IActionResult ReservarAsiento(int sesionId, char fila, int columna)
        {
            var sesion = sesiones.FirstOrDefault(s => s.Id == sesionId);
            if (sesion == null)
            {
                return NotFound($"Sesión con ID {sesionId} no encontrada.");
            }

            var asiento = sesion.Asientos.FirstOrDefault(a => a.Fila == fila && a.Columna == columna);
            if (asiento == null)
            {
                return NotFound($"Asiento en la fila {fila} y columna {columna} no encontrado en la sesión {sesionId}.");
            }

            if (asiento.Ocupado)
            {
                return Conflict($"El asiento en la fila {fila} y columna {columna} ya está reservado.");
            }

            asiento.Ocupado = true; // Reservar el asiento
            return Ok($"Asiento en la fila {fila} y columna {columna} reservado exitosamente en la sesión {sesionId}.");
        }
    }
}
