using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _serviceSala;

        public SalaController(ISalaService serviceSala)
        {
            _serviceSala = serviceSala;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sala>>> GetSalas()
        {
            var salas = await _serviceSala.GetAllAsync();
            return Ok(salas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> GetSala(int id)
        {
            var sala = await _serviceSala.GetByIdAsync(id);
            if (sala == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }
            return Ok(sala);
        }

        [HttpPost]
        public async Task<ActionResult<Sala>> CreateSala(Sala sala)
        {
            var existingSala = await _serviceSala.GetByIdAsync(sala.Id);
            if (existingSala != null)
            {
                return Conflict($"Ya existe una sala con el ID {sala.Id}.");
            }

            await _serviceSala.AddAsync(sala);
            return CreatedAtAction(nameof(GetSala), new { id = sala.Id }, sala);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSala(int id, Sala updatedSala)
        {
            var existingSala = await _serviceSala.GetByIdAsync(id);
            if (existingSala == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }

            // Actualizar la sala existente
            existingSala.Nombre = updatedSala.Nombre;
            existingSala.Capacidad = updatedSala.Capacidad;
            existingSala.Disponible = updatedSala.Disponible;

            await _serviceSala.UpdateAsync(existingSala);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSala(int id)
        {
            var sala = await _serviceSala.GetByIdAsync(id);
            if (sala == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }

            await _serviceSala.DeleteAsync(id);
            return NoContent();
        }
    }
}
