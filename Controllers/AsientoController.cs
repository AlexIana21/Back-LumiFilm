using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoController : ControllerBase
    {
        private readonly IAsientoService _serviceAsiento;

        public AsientoController(IAsientoService serviceAsiento)
        {
            _serviceAsiento = serviceAsiento;
        }

        [HttpGet]
        public async Task<ActionResult<List<Asiento>>> GetAsientos()
        {
            var asientos = await _serviceAsiento.GetAllAsync();
            return Ok(asientos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asiento>> GetAsiento(int id)
        {
            var asiento = await _serviceAsiento.GetByIdAsync(id);
            if (asiento == null)
            {
                return NotFound($"Asiento con ID {id} no encontrado.");
            }
            return Ok(asiento);
        }

        [HttpPost]
        public async Task<ActionResult<Asiento>> CreateAsiento(Asiento asiento)
        {
            var existingAsiento = await _serviceAsiento.GetByIdAsync(asiento.Id);
            if (existingAsiento != null)
            {
                return Conflict($"Ya existe un asiento con el ID {asiento.Id}.");
            }

            await _serviceAsiento.AddAsync(asiento);
            return CreatedAtAction(nameof(GetAsiento), new { id = asiento.Id }, asiento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsiento(int id, Asiento updateAsiento)
        {
            var existingAsiento = await _serviceAsiento.GetByIdAsync(id);
            if (existingAsiento == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }

            // Actualizar la sala existente
            existingAsiento.Fila = updateAsiento.Fila;
            existingAsiento.Columna = updateAsiento.Columna;
            existingAsiento.Estado = updateAsiento.Estado;
            existingAsiento.Precio = updateAsiento.Precio;
            existingAsiento.EsVip = updateAsiento.EsVip;
            existingAsiento.SalaId = updateAsiento.SalaId;

            await _serviceAsiento.UpdateAsync(existingAsiento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsiento(int id)
        {
            var asiento = await _serviceAsiento.GetByIdAsync(id);
            if (asiento == null)
            {
                return NotFound($"Asiento con ID {id} no encontrado.");
            }

            await _serviceAsiento.DeleteAsync(id);
            return NoContent();
        }
    }
}
