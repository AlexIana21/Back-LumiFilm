using Microsoft.AspNetCore.Mvc;
using Models;
using Utils;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EntradaController : ControllerBase 
    {
        private static List<Entrada> entradas = new List<Entrada>();

        [HttpGet]
        public ActionResult<IEnumerable<Entrada>> GetEntrada()
        {
           return Ok(entradas);
        }

        [HttpGet("{id}")]
        public ActionResult<Entrada> GetEntrada(int id)
        {
            var entrada = entradas.FirstOrDefault(p => p.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }
            return Ok(entrada);
        }

        [HttpPost]
        public ActionResult<Entrada> CreateEntrada(Entrada entradaRequest)
        {
            try
            {
                if (entradaRequest.Precio < 0)
                {
                    
                    Logger.LogError(new ArgumentException("Error: El precio no puede ser negativo"));

                    return BadRequest(new { mensaje = "Error: El precio no puede ser negativo" });
                }

                entradas.Add(entradaRequest);
                return CreatedAtAction(nameof(GetEntrada), new { id = entradaRequest.Id }, entradaRequest);
            }
            catch (Exception ex)
            {
                //para otro error
                Logger.LogError(ex);
                return StatusCode(500, new { mensaje = "Se produjo un error inesperado" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEntrada(int id, Entrada updateEntrada)
        {
            var entrada = entradas.FirstOrDefault(p => p.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }
            entrada.Tipo = updateEntrada.Tipo;
            entrada.Precio = updateEntrada.Precio;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEntrada(int id)
        {
            var entrada = entradas.FirstOrDefault(p => p.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }
            entradas.Remove(entrada);
            return NoContent();
        }

        public static void InicializarDatos()
        {
            entradas.Add(new Entrada("Normal", 7.60));
            entradas.Add(new Entrada("Carnet Joven", 6.50));
            entradas.Add(new Entrada("Menores 13", 6.50));
            entradas.Add(new Entrada("Mayores 65", 6.20));
            entradas.Add(new Entrada("Familia Numerosa", 6.50));
        }
    }
}