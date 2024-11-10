using Microsoft.AspNetCore.Mvc;
using Models;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PeliculaController : ControllerBase 
    {
        private static List<Pelicula> peliculas = new List<Pelicula>();

        [HttpGet]
        public ActionResult<IEnumerable<Pelicula>> GetPeliculas()
        {
           return Ok(peliculas);
        }

        [HttpGet("{id}")]
        public ActionResult<Pelicula> GetPelicula(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpPost]
        public ActionResult<Pelicula> CreatePlato(Pelicula pelicula)
        {
           peliculas.Add(pelicula);
           return CreatedAtAction(nameof(GetPelicula), new { id = pelicula.Id }, pelicula);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePelicula(int id, Pelicula updatePelicula)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            pelicula.Titulo = updatePelicula.Titulo;
            pelicula.Sinopsis = updatePelicula.Sinopsis;
            pelicula.Duracion = updatePelicula.Duracion;
            pelicula.Clasificacion = updatePelicula.Clasificacion;
            pelicula.Genero = updatePelicula.Genero;
            pelicula.Direccion = updatePelicula.Direccion;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePelicula(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            peliculas.Remove(pelicula);
            return NoContent();
        }

        public static void InicializarDatos()
        {
            peliculas.Add(new Pelicula("Speal No Evil", "Una familia danesa visita a una familia holandesa que conocieron en unas vacaciones. Lo que se suponía que iba a ser un fin de semana idílico comienza a desmoronarse lentamente mientras los daneses intentan ser educados ante lo desagradables que empiezan a ser los neerlandeses.", 109, 16, "Thriller", "James Watkins"));
            peliculas.Add(new Pelicula("Buffalo Kids", "Tom y Mary, dos hermanos huérfanos, desembarcan en Nueva York a finales del siglo XIX. Para reunirse con su tío, se aventuran como polizones en un tren por el Salvaje Oeste donde conocerán a Nick, un nuevo y extraordinario amigo que cambiará sus vidas para siempre. Juntos se embarcarán en un peligroso viaje, enfrentándose a malvados villanos, haciendo inesperados amigos y viviendo situaciones únicas.",93, 0, "Animación", "Pedro Solís"));
            peliculas.Add(new Pelicula("Elevation", "Un padre soltero y dos mujeres se aventuran desde la seguridad de sus hogares a enfrentarse a criaturas monstruosas para salvar la vida de un niño.", 90, 16, "Acción", "George Nolfi"));
            peliculas.Add(new Pelicula("El Cuervo", "Eric Draven y Shelly Webster son asesinados de forma brutal cuando los demonios de su tormentoso pasado los alcanzan. Al recibir la oportunidad de sacrificarse para salvar a su gran amor, Eric decide vengarse sin piedad de sus asesinos, cruzando entre el mundo de los vivos y los muertos para ajustar cuentas.", 111, 18, "Acción", "Rupert Sanders"));
            peliculas.Add(new Pelicula("Alien: Romulus", "En 2142, una sonda espacial de la corporación Weyland-Yutani investiga los restos del USCSS Nostromo y recoge un objeto orgánico que contiene un Xenomorfo. Tiempo después, en la colonia minera Jackson's Star, la joven Rain Carradine, una huérfana que trabaja con su hermano adoptivo Andy, un humano sintético reprogramado, acepta unirse a su ex-novio Tyler para viajar a una nave espacial abandonada a intentar recuperar unas cámaras de criostasis. Éstas les permitirán a ellos y a sus amigos (la hermana de Tyler, Kay, su primo Bjorn y la novia de este, Navarro) escapar todos al planeta Yvaga.", 119, 16, "Terror", "Fede Alvarez"));
            peliculas.Add(new Pelicula("Dune: Part II", "Tras los sucesos de la primera parte acontecidos en el planeta Arrakis, el joven Paul Atreides se une a la tribu de los Fremen y comienza un viaje espiritual y marcial para convertirse en mesías, mientras intenta evitar el horrible pero inevitable futuro que ha presenciado: una Guerra Santa en su nombre, que se extiende por todo el universo conocido.", 166, 12, "Ciencia Ficción", "Denis Villeneuve"));
            peliculas.Add(new Pelicula("Emilia Pérez", "Sobrecualificada e infravalorada, Rita es una abogada de un gran bufete que un día recibe una oferta inesperada: ayudar al temido jefe de un cartel a retirarse de su negocio y desaparecer para siempre convirtiéndose en la mujer que él siempre ha soñado ser.", 130, 16, "Drama", "Jacques Audiard"));
            peliculas.Add(new Pelicula("Robot Salvaje", "La robot Roz, que ha naufragado en una isla deshabitada, debe aprender a adaptarse al duro entorno, forjando poco a poco relaciones con la fauna local y convirtiéndose en madre adoptiva de una cría de ganso huérfana.", 102, 0, "Animación", "Chris Sanders"));
        }
    }
}