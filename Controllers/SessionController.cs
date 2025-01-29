using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _serviceSession;

        public SessionController(ISessionService serviceSession)
        {
            _serviceSession = serviceSession;
        }

        [HttpGet]
        public async Task<ActionResult<List<Session>>> GetSessions()
        {
            var sessions = await _serviceSession.GetAllAsync();
            return Ok(sessions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> GetSession(int id)
        {
            var session = await _serviceSession.GetByIdAsync(id);
            if (session == null)
            {
                return NotFound($"Sesión con ID {id} no encontrada.");
            }
            return Ok(session);
        }

        [HttpGet("movie/{MovieId}")]
        public async Task<IActionResult> GetSessionesByMovie(int MovieId)
        {
            var sessionsFiltradas = await _serviceSession.GetByMovieAsync(MovieId);
            if (sessionsFiltradas == null || sessionsFiltradas.Count == 0)
            {
                return NotFound($"No se encontraron sesiones para la película con ID {MovieId}.");
            }
            return Ok(sessionsFiltradas);
        }

        [HttpPost]
        public async Task<ActionResult<Session>> CreateSesion(Session session)
        {
            await _serviceSession.AddAsync(session);
            return CreatedAtAction(nameof(GetSession), new { id = session.Id }, session);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSesion(int id, Session updatedSesion)
        {
            var existingSession = await _serviceSession.GetByIdAsync(id);
            if (existingSession == null)
            {
                return NotFound($"Sesión con ID {id} no encontrada.");
            }   

            // Actualizar la sesión existente
            existingSession.Date = updatedSesion.Date;
            existingSession.MovieId = updatedSesion.MovieId;
            existingSession.ScreenId = updatedSesion.ScreenId;

            await _serviceSession.UpdateAsync(existingSession);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSesion(int id)
        {
            var session = await _serviceSession.GetByIdAsync(id);
            if (session == null)
            {
                return NotFound($"Sesión con ID {id} no encontrada.");
            }

            await _serviceSession.DeleteAsync(id);
            return NoContent();
        }
    }
}