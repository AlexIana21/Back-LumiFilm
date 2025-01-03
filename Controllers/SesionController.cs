using Microsoft.AspNetCore.Mvc;
using Models;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SesionController : ControllerBase 
    {   
        //Almacenamos objetos de tipo Sesiones
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

      [HttpGet("pelicula/{idPelicula}")]
        public IActionResult GetSesionByMovie(int idPelicula)
        {
            var sesionesFiltradas = sesiones
                .Where(s => s.Pelicula.Id == idPelicula) //Filtra la Pelicula.Id si coincide con el idPelicula recibido
                .Select(s => new { //Proyecta los datos de las sesiones filtradas en un nuevo formato
                    Id = s.Id, 
                    Dia = s.Dia.ToString("yyyy-MM-dd"), 
                    Hora = s.Hora.ToString("HH:mm:ss"), 
                    Pelicula = s.Pelicula.Titulo,
                    Sala = s.Sala.Id,
                })
                .ToList(); //Convierte el resultado del filtrado y transformación en una lista

            if (sesionesFiltradas.Count == 0)
            {
                return NotFound();
            }

        return Ok(sesionesFiltradas);
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
            var salas = SalaController.GetSalasList();

            //Sesiones para Speak No Evil
            var pelicula1 = peliculas.FirstOrDefault(p => p.Titulo == "Speak No Evil");
            var sala1 = salas.FirstOrDefault(p => p.Id == 1);

            if (pelicula1 != null && sala1 != null) 
            {
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(16, 30), pelicula1, sala1, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(18, 30), pelicula1, sala1, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(20, 30), pelicula1, sala1, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(16, 30), pelicula1, sala1, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(18, 30), pelicula1, sala1, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(20, 30), pelicula1, sala1, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(16, 30), pelicula1, sala1, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(18, 30), pelicula1, sala1, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(20, 30), pelicula1, sala1, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(16, 30), pelicula1, sala1, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(18, 30), pelicula1, sala1, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(20, 30), pelicula1, sala1, 80));
            }
            else
            {
                Console.WriteLine("La película 'Speak No Evil' no ha sido encontrada");
            }

            //Sesiones para Buffalo Kids
            var pelicula2 = peliculas.FirstOrDefault(p => p.Titulo == "Buffalo Kids");
            var sala2 = salas.FirstOrDefault(p => p.Id == 2);
            if (pelicula2 != null && sala2 != null)
            {
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(16, 15), pelicula2, sala2, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(18, 15), pelicula2, sala2, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(20, 15), pelicula2, sala2, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(16, 15), pelicula2, sala2, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(18, 15), pelicula2, sala2, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(20, 15), pelicula2, sala2, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(16, 15), pelicula2, sala2, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(18, 15), pelicula2, sala2, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(20, 15), pelicula2, sala2, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(16, 15), pelicula2, sala2, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(18, 15), pelicula2, sala2, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(20, 15), pelicula2, sala2, 90));
            }
            else
            {
                Console.WriteLine("La película 'Buffalo Kids' no ha sido encontrada");
            }

            //Sesiones para Elevation
            var pelicula3 = peliculas.FirstOrDefault(p => p.Titulo == "Elevation");
            var sala3 = salas.FirstOrDefault(p => p.Id == 3);
            if (pelicula3 != null && sala3 != null)
            {
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(15, 30), pelicula3, sala3, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(17, 30), pelicula3, sala3, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(19, 30), pelicula3, sala3, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(15, 30), pelicula3, sala3, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(17, 30), pelicula3, sala3, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(19, 30), pelicula3, sala3, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(15, 30), pelicula3, sala3, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(17, 30), pelicula3, sala3, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(19, 30), pelicula3, sala3, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(15, 30), pelicula3, sala3, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(17, 30), pelicula3, sala3, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(19, 30), pelicula3, sala3, 70));
            }
            else
            {
                Console.WriteLine("La película 'Elevation' no ha sido encontrada");
            }

            //Sesiones para El Cuervo
            var pelicula4 = peliculas.FirstOrDefault(p => p.Titulo == "El Cuervo");
            var sala4 = salas.FirstOrDefault(p => p.Id == 4);
            if (pelicula4 != null && sala4 != null)
            {   
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(16, 30), pelicula4, sala4, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(18, 30), pelicula4, sala4, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(20, 30), pelicula4, sala4, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(14, 30), pelicula4, sala4, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(16, 30), pelicula4, sala4, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(18, 30), pelicula4, sala4, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(16, 30), pelicula4, sala4, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(18, 30), pelicula4, sala4, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(20, 30), pelicula4, sala4, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(16, 30), pelicula4, sala4, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(18, 30), pelicula4, sala4, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 08), new TimeOnly(20, 30), pelicula4, sala4, 80));
            }
            else
            {
                Console.WriteLine("La película 'El Cuervo' no ha sido encontrada");
            }

            //Sesiones para Alien: Romulus
            var pelicula5 = peliculas.FirstOrDefault(p => p.Titulo == "Alien: Romulus");
            var sala5 = salas.FirstOrDefault(p => p.Id == 5);
            if (pelicula5 != null && sala5 != null)
            {   

                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(16, 00), pelicula5, sala5, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(18, 00), pelicula5, sala5, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(20, 00), pelicula5, sala5, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(16, 00), pelicula5, sala5, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(18, 00), pelicula5, sala5, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(20, 00), pelicula5, sala5, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(16, 00), pelicula5, sala5, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(18, 00), pelicula5, sala5, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(20, 00), pelicula5, sala5, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(16, 00), pelicula5, sala5, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(18, 00), pelicula5, sala5, 70));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(20, 00), pelicula5, sala5, 70));
            }
            else
            {
                Console.WriteLine("La película 'Alien: Romulus' no ha sido encontrada");
            }

            //Sesiones para Dune: Part II
            var pelicula6 = peliculas.FirstOrDefault(p => p.Titulo == "Dune: Part II");
            var sala6 = salas.FirstOrDefault(p => p.Id == 6);
            if (pelicula6 != null && sala6 != null)
            {   
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(18, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(20, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(22, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(18, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(20, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(22, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(18, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(20, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(22, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(18, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(20, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(22, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(18, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(20, 00), pelicula6, sala6, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(22, 00), pelicula6, sala6, 80));
            }
            else
            {
                Console.WriteLine("La película 'Dune: Part II' no ha sido encontrada");
            }

            //Sesiones para Emilia Pérez
            var pelicula7 = peliculas.FirstOrDefault(p => p.Titulo == "Emilia Pérez");
            var sala7 = salas.FirstOrDefault(p=> p.Id == 7);
            if (pelicula7 != null && sala7 != null)
            {   
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(17, 00), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(18, 30), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(22, 00), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(17, 00), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(18, 30), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(22, 00), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(17, 00), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(18, 30), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 05), new TimeOnly(22, 00), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(17, 00), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(18, 30), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(22, 00), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(17, 00), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(18, 30), pelicula7, sala7, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(22, 00), pelicula7, sala7, 90));
            }
            else
            {
                Console.WriteLine("La película 'Emilia Pérez' no ha sido encontrada");
            }

            //Sesiones para Robot Salvaje
            var pelicula8 = peliculas.FirstOrDefault(p => p.Titulo == "Robot Salvaje");
            var sala8 = salas.FirstOrDefault(p => p.Id == 8);
            if (pelicula8 != null && sala8 != null)
            {
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(16, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(18, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(20, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(16, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(18, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(20, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(16, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(18, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(20, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(16, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(18, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(20, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(16, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(18, 00), pelicula8, sala8, 80));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(20, 00), pelicula8, sala8, 80));
            }
            else
            {
                Console.WriteLine("La película 'Robot Salvaje' no ha sido encontrada");
            }

            //Sesiones para Minecraftt
            var pelicula9 = peliculas.FirstOrDefault(p => p.Titulo == "Minecraft");
            var sala9 = salas.FirstOrDefault(p => p.Id == 9);
            if (pelicula9 != null && sala9!= null)
            {
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(16, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(18, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 02), new TimeOnly(20, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(16, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(18, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 03), new TimeOnly(20, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(16, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(18, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 04), new TimeOnly(20, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(16, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(18, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 06), new TimeOnly(20, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(16, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(18, 00), pelicula9, sala9, 90));
                sesiones.Add(new Sesion(new DateOnly(2024, 12, 07), new TimeOnly(20, 00), pelicula9, sala9, 90));
            }
            else
            {
                Console.WriteLine("La película 'Minecraft' no ha sido encontrada");
            }
        }

        //Devuelve la lista sesiones y se puede llamar fuera de la clase
        public static List<Sesion> GetSesionesList()
        {
        return sesiones;
        }
    }
}