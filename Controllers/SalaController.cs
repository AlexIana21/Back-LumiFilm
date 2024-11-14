using Microsoft.AspNetCore.Mvc;
using Models;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private static List<Sala> salas = new List<Sala>();

        [HttpGet]
        public ActionResult<IEnumerable<Sala>> GetSalas()
        {
            return Ok(salas);
        }

        [HttpGet("{id}")]
        public ActionResult<Sala> GetSala(int id)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }
            return Ok(sala);
        }

       [HttpPost]
        public ActionResult<Sala> CreateSala([FromBody] Sala sala)
        {
            if (salas.Any(s => s.Id == sala.Id))
            {
                return Conflict($"Ya existe una sala con el ID {sala.Id}.");
            }

            var nuevaSala = new Sala(sala.Id, sala.Capacidad);
            salas.Add(nuevaSala);

            return CreatedAtAction(nameof(GetSala), new { id = nuevaSala.Id }, nuevaSala);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSala(int id)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }

            salas.Remove(sala);
            return NoContent();
        }


           public static void InicializarDatos(List<Pelicula> peliculas)
        {
            var sesionesSala1 = new List<Sesion>
            {
                new Sesion(1, "Lunes", new DateTime(2024, 11, 14, 14, 30, 0), peliculas[0]),
                new Sesion(2, "Martes", new DateTime(2024, 11, 14, 16, 30, 0), peliculas[0]),
                new Sesion(3, "Viernes", new DateTime(2024, 11, 14, 20, 30, 0), peliculas[0])
            };

            salas.Add(new Sala(1, 9) 
            {
                Sesion = sesionesSala1
            });
        }

        public static List<Sala> GetSalasList() // esto es para los asientos
        {
            return salas;
        }

    }
}

