using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Repositories;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class PeliculaController : ControllerBase
   {
    private static List<Pelicula> peliculas = new List<Pelicula>();

    private readonly IPeliculaService _servicePelicula;

    public PeliculaController(IPeliculaService service)
        {
            _servicePelicula = service;
        }
    
        [HttpGet]
        public async Task<ActionResult<List<Pelicula>>> GetPeliculas()
        {
            var pelicula = await _servicePelicula.GetAllAsync();
            return Ok(pelicula);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> GetPlicula(int id)
        {
            var pelicula = await _servicePelicula.GetByIdAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpPost]
        public async Task<ActionResult<Pelicula>> CreatePelicula(Pelicula pelicula)
        {
            await _servicePelicula.AddAsync(pelicula);
            return CreatedAtAction(nameof(GetPlicula), new { id = pelicula.Id }, pelicula);
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePelicula(int id, Pelicula updatedPelicula)
        {
            var existingPelicula = await _servicePelicula.GetByIdAsync(id);
            if (existingPelicula == null)
            {
                return NotFound();
            }

            // Actualizar el peli existente
            existingPelicula.Titulo = updatedPelicula.Titulo;
            existingPelicula.Sinopsis = updatedPelicula.Sinopsis;
            existingPelicula.Duracion = updatedPelicula.Duracion;
            existingPelicula.Clasificacion = updatedPelicula.Clasificacion;
            existingPelicula.Genero = updatedPelicula.Genero;
            existingPelicula.Direccion = updatedPelicula.Direccion;
            existingPelicula.Imagen = updatedPelicula.Imagen;

            await _servicePelicula.UpdateAsync(existingPelicula);
            return NoContent();
        }
  
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeletePelicula(int id)
       {
           var pelicula = await _servicePelicula.GetByIdAsync(id);
           if (pelicula == null)
           {
               return NotFound();
           }
           await _servicePelicula.DeleteAsync(id);
           return NoContent();
       }
   }
}