using Microsoft.AspNetCore.Mvc;
using Models;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SesionController : ControllerBase 
    {
        private static List<Sesion> sesiones = new List<Sesion>();

        [HttpGet]
        public ActionResult<IEnumerable<Sesion>> GetSesion()
        {
           return Ok(sesiones);
        }

        [HttpGet("{id}")]
        public ActionResult<Sesion> GetSesion(int id)
        {
            var sesion = sesiones.FirstOrDefault(p => p.Id == id);
            if (sesion == null)
            {
                return NotFound();
            }
            return Ok(sesion);
        }

        [HttpPost]
        public ActionResult<Sesion> CreateSesion(Sesion sesion)
        {
           sesiones.Add(sesion);
           return CreatedAtAction(nameof(GetSesion), new { id = sesion.Id }, sesion);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSesion(int id, Sesion updateSesion)
        {
            var sesion = sesiones.FirstOrDefault(p => p.Id == id);
            if (sesion == null)
            {
                return NotFound();
            }
            sesion.Dia = updateSesion.Dia;
            sesion.Hora = updateSesion.Hora;
            sesion.Pelicula = updateSesion.Pelicula;
            sesion.Asientos = updateSesion.Asientos;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSesion(int id)
        {
            var sesion = sesiones.FirstOrDefault(p => p.Id == id);
            if (sesion == null)
            {
                return NotFound();
            }
            sesiones.Remove(sesion);
            return NoContent();
        }

        public static void InicializarDatos()
        {
            var peliculas = PeliculaController.GetPeliculasList();

            //Sesiones para Speak No Evil
            var pelicula1 = peliculas.FirstOrDefault(p => p.Titulo == "Speak No Evil");
            if (pelicula1 != null)
            {
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(16, 30), pelicula1, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(18, 30), pelicula1, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(20, 30), pelicula1, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(16, 30), pelicula1, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(18, 30), pelicula1, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(20, 30), pelicula1, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(16, 30), pelicula1, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(18, 30), pelicula1, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(20, 30), pelicula1, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(16, 30), pelicula1, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(18, 30), pelicula1, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(20, 30), pelicula1, 10));
            }
            else
            {
                Console.WriteLine("La película 'Speak No Evil' no ha sido encontrada");
            }

            //Sesiones para Buffalo Kids
            var pelicula2 = peliculas.FirstOrDefault(p => p.Titulo == "Buffalo Kids");
            if (pelicula2 != null)
            {
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(16, 15), pelicula2, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(18, 15), pelicula2, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(20, 15), pelicula2, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(16, 15), pelicula2, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(18, 15), pelicula2, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(20, 15), pelicula2, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(16, 15), pelicula2, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(18, 15), pelicula2, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(20, 15), pelicula2, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(16, 15), pelicula2, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(18, 15), pelicula2, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(20, 15), pelicula2, 10));
            }
            else
            {
                Console.WriteLine("La película 'Buffalo Kids' no ha sido encontrada");
            }

            //Sesiones para Elevation
            var pelicula3 = peliculas.FirstOrDefault(p => p.Titulo == "Elevation");
            if (pelicula3 != null)
            {
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(15, 30), pelicula3, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(17, 30), pelicula3, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(19, 30), pelicula3, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(15, 30), pelicula3, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(17, 30), pelicula3, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(19, 30), pelicula3, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(15, 30), pelicula3, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(17, 30), pelicula3, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(19, 30), pelicula3, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(15, 30), pelicula3, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(17, 30), pelicula3, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(19, 30), pelicula3, 10));
            }
            else
            {
                Console.WriteLine("La película 'Elevation' no ha sido encontrada");
            }

            //Sesiones para El Cuervo
            var pelicula4 = peliculas.FirstOrDefault(p => p.Titulo == "El Cuervo");
            if (pelicula4 != null)
            {   
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(16, 30), pelicula4, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(18, 30), pelicula4, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(20, 30), pelicula4, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(14, 30), pelicula4, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(16, 30), pelicula4, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(18, 30), pelicula4, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(16, 30), pelicula4, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(18, 30), pelicula4, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(20, 30), pelicula4, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(16, 30), pelicula4, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(18, 30), pelicula4, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(20, 30), pelicula4, 10));
            }
            else
            {
                Console.WriteLine("La película 'El Cuervo' no ha sido encontrada");
            }

            //Sesiones para Alien: Romulus
            var pelicula5 = peliculas.FirstOrDefault(p => p.Titulo == "Alien: Romulus");
            if (pelicula5 != null)
            {   

                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(16, 00), pelicula5, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(18, 00), pelicula5, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(20, 00), pelicula5, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(16, 00), pelicula5, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(18, 00), pelicula5, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(20, 00), pelicula5, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(16, 00), pelicula5, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(18, 00), pelicula5, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(20, 00), pelicula5, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(16, 00), pelicula5, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(18, 00), pelicula5, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(20, 00), pelicula5, 10));
            }
            else
            {
                Console.WriteLine("La película 'Alien: Romulus' no ha sido encontrada");
            }

            //Sesiones para Dune: Part II
            var pelicula6 = peliculas.FirstOrDefault(p => p.Titulo == "Dune: Part II");
            if (pelicula6 != null)
            {   
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(18, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(20, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(22, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(18, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(20, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(22, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(18, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(20, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(22, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(18, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(20, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(22, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(18, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(20, 00), pelicula6, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(22, 00), pelicula6, 10));
            }
            else
            {
                Console.WriteLine("La película 'Dune: Part II' no ha sido encontrada");
            }

            //Sesiones para Emilia Pérez
            var pelicula7 = peliculas.FirstOrDefault(p => p.Titulo == "Emilia Pérez");
            if (pelicula7 != null)
            {   
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(17, 00), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(19, 30), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(22, 00), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(17, 00), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(19, 30), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(22, 00), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(17, 00), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(19, 30), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(22, 00), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(17, 00), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(19, 30), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(22, 00), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(17, 00), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(19, 30), pelicula7, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(22, 00), pelicula7, 10));
            }
            else
            {
                Console.WriteLine("La película 'Emilia Pérez' no ha sido encontrada");
            }

            //Sesiones para Robot Salvaje
            var pelicula8 = peliculas.FirstOrDefault(p => p.Titulo == "Robot Salvaje");
            if (pelicula8 != null)
            {
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(16, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(18, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(20, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(16, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(18, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(20, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(16, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(18, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(20, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(16, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(18, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(20, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(16, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(18, 00), pelicula8, 10));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(20, 00), pelicula8, 10));
            }
            else
            {
                Console.WriteLine("La película 'Robot Salvaje' no ha sido encontrada");
            }
        }

        public static List<Sesion> GetSesionesList()
        {
        return sesiones;
        }
    }
}