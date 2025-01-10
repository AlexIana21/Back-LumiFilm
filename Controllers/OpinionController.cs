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

        [HttpGet("{id}")]
        public ActionResult<Opiniones> GetOpinion(int id)
        {
            var opinion = opiniones.FirstOrDefault(o => o.Id == id);
            if (opinion == null)
            {
                return NotFound();
            }
            return Ok(opinion);
        }

        [HttpPost]
        public ActionResult<Opiniones> CreateOpinion(int peliculaId, string texto, string username, int calificacion)
        {
            var pelicula = PeliculaController.GetPeliculasList().FirstOrDefault(p => p.Id == peliculaId);
            if (pelicula == null)
            {
                return BadRequest("Película no encontrada.");
            }

            var nuevaOpinion = new Opiniones(pelicula, texto, username, calificacion);
            opiniones.Add(nuevaOpinion);

            return CreatedAtAction(nameof(GetOpinion), new { id = nuevaOpinion.Id }, nuevaOpinion);
        }

        public static void InicializarDatos()
        {
            var peliculas = PeliculaController.GetPeliculasList();

            var pelicula1 = peliculas.FirstOrDefault(p => p.Id == 1);
            var pelicula2 = peliculas.FirstOrDefault(p => p.Id == 3);

            if (pelicula1 != null && pelicula2 != null)
            {
                opiniones.Add(new Opiniones(pelicula1, "Gran actuación y dirección.", "Usuario1", 5));
                opiniones.Add(new Opiniones(pelicula2, "Suspenso emocionante.", "Usuario2", 4));
            }
        }
    }
}
