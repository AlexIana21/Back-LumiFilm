using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private readonly ISesionService _serviceSesion;

        public SesionController(ISesionService serviceSesion)
        {
            _serviceSesion = serviceSesion;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sesion>>> GetSesiones()
        {
            var sesiones = await _serviceSesion.GetAllAsync();
            return Ok(sesiones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sesion>> GetSesion(int id)
        {
            var sesion = await _serviceSesion.GetByIdAsync(id);
            if (sesion == null)
            {
                return NotFound($"Sesión con ID {id} no encontrada.");
            }
            return Ok(sesion);
        }

        [HttpGet("pelicula/{idPelicula}")]
        public async Task<IActionResult> GetSesionesByMovie(int idPelicula)
        {
            var sesionesFiltradas = await _serviceSesion.GetByMovieAsync(idPelicula);
            if (sesionesFiltradas == null || sesionesFiltradas.Count == 0)
            {
                return NotFound($"No se encontraron sesiones para la película con ID {idPelicula}.");
            }
            return Ok(sesionesFiltradas);
        }

        [HttpPost]
        public async Task<ActionResult<Sesion>> CreateSesion(Sesion sesion)
        {
            await _serviceSesion.AddAsync(sesion);
            return CreatedAtAction(nameof(GetSesion), new { id = sesion.Id }, sesion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSesion(int id, Sesion updatedSesion)
        {
            var existingSesion = await _serviceSesion.GetByIdAsync(id);
            if (existingSesion == null)
            {
                return NotFound($"Sesión con ID {id} no encontrada.");
            }   

            // Actualizar la sesión existente
            existingSesion.Dia = updatedSesion.Dia;
            existingSesion.Hora = updatedSesion.Hora;
            existingSesion.PeliculaId = updatedSesion.PeliculaId;
            existingSesion.SalaId = updatedSesion.SalaId;

            await _serviceSesion.UpdateAsync(existingSesion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSesion(int id)
        {
            var sesion = await _serviceSesion.GetByIdAsync(id);
            if (sesion == null)
            {
                return NotFound($"Sesión con ID {id} no encontrada.");
            }

            await _serviceSesion.DeleteAsync(id);
            return NoContent();
        }
    }
}