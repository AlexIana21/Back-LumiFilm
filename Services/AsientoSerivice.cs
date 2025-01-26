using Models;
using Reto_Back.Repositories;
using Reto_Back.Services;

namespace Reto_Back.Service
{
    public class AsientoService : IAsientoService
    {
        private readonly IAsientoRepository _asientoRepository;

        public AsientoService(IAsientoRepository asientoRepository)
        {
            _asientoRepository = asientoRepository;
        }

        public async Task<List<Asiento>> GetAllAsync()
        {
            return await _asientoRepository.GetAllAsync();
        }

        public async Task<Asiento?> GetByIdAsync(int id)
        {
            return await _asientoRepository.GetByIdAsync(id);
        }


        public async Task AddAsync(Asiento asiento)
        {
            await _asientoRepository.AddAsync(asiento);
        }

        public async Task UpdateAsync(Asiento asiento)
        {
            await _asientoRepository.UpdateAsync(asiento);
        }

        public async Task DeleteAsync(int id)
        {
           var asiento = await _asientoRepository.GetByIdAsync(id);
           if (asiento == null)
           {
               //return NotFound();
           }
           await _asientoRepository.DeleteAsync(id);
           //return NoContent();
        }
        
    }
}