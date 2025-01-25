using Models;
using Reto_Back.Repositories;
using Reto_Back.Service;
using Reto_Back.Services;

namespace Reto_Back.Service
{
    public class SesionService : ISesionService
    {
        private readonly ISesionRepository _sesionRepository;

        public SesionService(ISesionRepository sesionRepository) 
        {
            _sesionRepository = sesionRepository;
        }

        public async Task<List<Sesion>> GetAllAsync()
        {
            return await _sesionRepository.GetAllAsync();
        }

        public async Task<Sesion?> GetByIdAsync(int id)
        {
            return await _sesionRepository.GetByIdAsync(id);
        }

        public async Task<List<Sesion>> GetByMovieAsync(int movieId)
        {
            
            return await _sesionRepository.GetByMovieAsync(movieId);
        }


        public async Task AddAsync(Sesion sesion)
        {
            await _sesionRepository.AddAsync(sesion);
        }

        public async Task UpdateAsync(Sesion sesion)
        {
            await _sesionRepository.UpdateAsync(sesion);
        }

        public async Task DeleteAsync(int id)
        {
           var plato = await _sesionRepository.GetByIdAsync(id);
           if (plato == null)
           {
               //return NotFound();
           }
           await _sesionRepository.DeleteAsync(id);
           //return NoContent();
        }

     
    }
}