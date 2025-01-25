using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
    private static List<Comentario> comentarios = new List<Comentario>();

    private readonly IComentarioService _serviceComentario;

    public ComentarioController(IComentarioService serviceComentario)
        {
            _serviceComentario = serviceComentario;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comentario>>> GetComentario()
        {
            var comentarios = await _serviceComentario.GetAllAsync();
            return Ok(comentarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> GetComentario(int id)
        {
            var comentario = await _serviceComentario.GetByIdAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            return Ok(comentario);
        }

        /*[HttpGet("pelicula/{idPelicula}")]
        public async Task<ActionResult<List<Comentario>>> GetComentarioByMovie(int idPelicula)
        {
            var opinionesFiltradas = await _serviceComentario.GetOpinionesByPeliculaAsync(idPelicula);
            if (opinionesFiltradas == null || !opinionesFiltradas.Any())
            {
                return NotFound();
            }
            return Ok(opinionesFiltradas);
        }
        */

        [HttpPost]
        public async Task<ActionResult<Comentario>> CreateComentario(Comentario comentario)
        {
            await _serviceComentario.AddAsync(comentario);
            return CreatedAtAction(nameof(GetComentario), new { id = comentario.Id }, comentario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            var opinion = await _serviceComentario.GetByIdAsync(id);
            if (opinion == null)
            {
                return NotFound();
            }
            await _serviceComentario.DeleteAsync(id);
            return NoContent();
        }
    }
}
