using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenController : ControllerBase
    {
        private readonly IScreenService _serviceScreen;

        public ScreenController(IScreenService serviceScreen)
        {
            _serviceScreen = serviceScreen;
        }

        [HttpGet]
        public async Task<ActionResult<List<Screen>>> GetScreen()
        {
            var screens = await _serviceScreen.GetAllAsync();
            return Ok(screens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Screen>> GetScreen(int id)
        {
            var screen = await _serviceScreen.GetByIdAsync(id);
            if (screen == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }
            return Ok(screen);
        }

        [HttpPost]
        public async Task<ActionResult<Screen>> CreateScreen(Screen screen)
        {
            var existingScreen = await _serviceScreen.GetByIdAsync(screen.Id);
            if (existingScreen != null)
            {
                return Conflict($"Ya existe una sala con el ID {screen.Id}.");
            }

            await _serviceScreen.AddAsync(screen);
            return CreatedAtAction(nameof(GetScreen), new { id = screen.Id }, screen);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScreen(int id, Screen updatedScreen)
        {
            var existingScreen = await _serviceScreen.GetByIdAsync(id);
            if (existingScreen == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }

            // Actualizar la sala existente
            existingScreen.Capacity = updatedScreen.Capacity;
          

            await _serviceScreen.UpdateAsync(existingScreen);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreen(int id)
        {
            var screen = await _serviceScreen.GetByIdAsync(id);
            if (screen == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }

            await _serviceScreen.DeleteAsync(id);
            return NoContent();
        }
    }
}
