using Models;
using Reto_Back.Repositories;
using Reto_Back.Service;
using Reto_Back.Services;

namespace Reto_Back.Service
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _salaRepository;

        public SalaService(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public async Task<List<Sala>> GetAllAsync()
        {
            return await _salaRepository.GetAllAsync();
        }

        public async Task<Sala?> GetByIdAsync(int id)
        {
            return await _salaRepository.GetByIdAsync(id);
        }


        public async Task AddAsync(Sala sala)
        {
            await _salaRepository.AddAsync(sala);
        }

        public async Task UpdateAsync(Sala sala)
        {
            await _salaRepository.UpdateAsync(sala);
        }

        public async Task DeleteAsync(int id)
        {
           var sala = await _salaRepository.GetByIdAsync(id);
           if (sala == null)
           {
               //return NotFound();
           }
           await _salaRepository.DeleteAsync(id);
           //return NoContent();
        }
        
    }
}