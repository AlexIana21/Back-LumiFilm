using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Repositories;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();

        private readonly IMovieService _serviceMovie;

        public MovieController(IMovieService service)
        {
            _serviceMovie = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovie()
        {
            var movie = await _serviceMovie.GetAllAsync();
            return Ok(movie);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _serviceMovie.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
        {
            await _serviceMovie.AddAsync(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, Movie updatedMovie)
        {
            var existingMovie = await _serviceMovie.GetByIdAsync(id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            existingMovie.Title = updatedMovie.Title;
            existingMovie.Synopsis = updatedMovie.Synopsis;
            existingMovie.Duration = updatedMovie.Duration;
            existingMovie.Rating = updatedMovie.Rating;
            existingMovie.Genre = updatedMovie.Genre;
            existingMovie.Director = updatedMovie.Director;
            existingMovie.Poster = updatedMovie.Poster;

            await _serviceMovie.UpdateAsync(existingMovie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _serviceMovie.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            await _serviceMovie.DeleteAsync(id);
            return NoContent();
        }
    }
}