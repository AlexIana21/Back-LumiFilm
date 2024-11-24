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

            var nuevaSala = new Sala();
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

        public static void InicializarDatos()    
        {
            if (salas.Count == 0) 
            {
                for (int i = 1; i <= 9; i++)
                {
                    salas.Add(new Sala());
                    Console.WriteLine($"Sala {i} creada."); 
                }
            }
            else
            {
                Console.WriteLine("Las salas ya estaban inicializadas.");
            }
        }

        public static List<Sala> GetSalasList() 
        {
            return salas;
        }

    }
}

