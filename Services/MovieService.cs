using Models;
using Reto_Back.Repositories;
using Reto_Back.Service;
using Reto_Back.Services;

namespace Reto_Back.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository) 
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }


        public async Task AddAsync(Movie movie)
        {
            await _movieRepository.AddAsync(movie);
        }

        public async Task UpdateAsync(Movie movie)
        {
            await _movieRepository.UpdateAsync(movie);
        }

        public async Task DeleteAsync(int id)
        {
           var plato = await _movieRepository.GetByIdAsync(id);
           if (plato == null)
           {
               //return NotFound();
           }
           await _movieRepository.DeleteAsync(id);
           //return NoContent();
        }
        
    }
}