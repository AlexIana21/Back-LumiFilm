using Microsoft.AspNetCore.Mvc;
using Models;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionController : ControllerBase
    {
        private static List<Opiniones> opiniones = new List<Opiniones>();

        [HttpGet]
        public ActionResult<IEnumerable<Opiniones>> GetOpiniones()
        {
            return Ok(opiniones);
        }

          [HttpGet("pelicula/{idPelicula}")]
        public IActionResult GetComentariosByMovie(int idPelicula)
        {
            var opinionesFiltradas = opiniones
                .Where(s => s.PeliculaID == idPelicula) 
                .ToList(); 

            if (opinionesFiltradas.Count == 0)
            {
                return NotFound();
            }

        return Ok(opinionesFiltradas);
        }

        [HttpPost]
        public ActionResult<Opiniones> CreateOpinion(Opiniones opinion)
        {
            var pelicula = PeliculaController.GetPeliculasList().FirstOrDefault(p => p.Id == opinion.PeliculaID);
            if (pelicula == null)
            {
                return BadRequest("Película no encontrada.");
            }

            opiniones.Add(opinion);

            return Ok(opiniones); 
        }
    }
}
