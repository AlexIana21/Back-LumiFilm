using Microsoft.AspNetCore.Mvc;
using Models;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoController : ControllerBase
    {
        private static List<Sesion> sesiones = SesionController.GetSesionesList();

        // Obtener asientos por id de la sesión
        [HttpGet("sesion/{sesionId}")]
        public ActionResult<IEnumerable<Asiento>> GetAsientos(int sesionId)
        {
            var sesion = sesiones.FirstOrDefault(s => s.Id == sesionId);
            if (sesion == null)
            {
                return NotFound($"Sesión con ID {sesionId} no encontrada.");
            }

            var asientos = sesion.Asientos; //Accede a la propiedad Asientos de la sesión encontrada.
            if (!asientos.Any())
            {
                return NotFound($"No hay asientos disponibles para la sesión con ID {sesionId}.");
            }

            return Ok(asientos);
        }
        
    }   

}
