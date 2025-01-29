using Models;
using Reto_Back.Repositories;
using Reto_Back.Service;
using Reto_Back.Services;

namespace Reto_Back.Service
{
    public class ScreenService : IScreenService
    {
        private readonly IScreenRepository _screenRepository;

        public ScreenService(IScreenRepository screenRepository)
        {
            _screenRepository = screenRepository;
        }

        public async Task<List<Screen>> GetAllAsync()
        {
            return await _screenRepository.GetAllAsync();
        }

        public async Task<Screen?> GetByIdAsync(int id)
        {
            return await _screenRepository.GetByIdAsync(id);
        }


        public async Task AddAsync(Screen screen)
        {
            await _screenRepository.AddAsync(screen);
        }

        public async Task UpdateAsync(Screen screen)
        {
            await _screenRepository.UpdateAsync(screen);
        }

        public async Task DeleteAsync(int id)
        {
           var sala = await _screenRepository.GetByIdAsync(id);
           if (sala == null)
           {
               //return NotFound();
           }
           await _screenRepository.DeleteAsync(id);
           //return NoContent();
        }
        
    }
}