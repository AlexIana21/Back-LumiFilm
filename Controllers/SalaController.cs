using Microsoft.AspNetCore.Mvc;
using Models;

namespace CineAPI.Controllers
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

        [HttpPut("{id}")]
        public IActionResult UpdateSala(int id, Sala updatedSala)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }

            sala.Capacidad = updatedSala.Capacidad;
            sala.Dia = updatedSala.Dia ?? new List<Dia>();
            sala.Horarios = updatedSala.Horarios ?? new List<Horario>();
            sala.Asientos = updatedSala.Asientos ?? new List<Asiento>();
            return NoContent();
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

        // Métodos horarios y días asociados a una sala

        [HttpGet("{id}/horarios")]
        public ActionResult<IEnumerable<Horario>> GetHorarios(int id)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }

            return Ok(sala.Horarios);
        }

        [HttpPost("{id}/horarios")]
        public IActionResult AddHorario(int id, Horario horario)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }

            sala.Horarios.Add(horario);
            return CreatedAtAction(nameof(GetHorarios), new { id = sala.Id }, horario);
        }

        [HttpGet("{id}/dias")]
        public ActionResult<IEnumerable<Dia>> GetDias(int id)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }

            return Ok(sala.Dia);
        }

        [HttpPost("{id}/dias")]
        public IActionResult AddDia(int id, Dia dia)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
            {
                return NotFound($"Sala con ID {id} no encontrada.");
            }

            sala.Dia.Add(dia);
            return CreatedAtAction(nameof(GetDias), new { id = sala.Id }, dia);
        }
    }
}
