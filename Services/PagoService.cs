using Models;
using Reto_Back.Repositories;
using Reto_Back.Services;

namespace Reto_Back.Service
{
    public class PagoService : IPagoService
    {
        private readonly IPagoRepository _pagoRepository;

        public PagoService(IPagoRepository pagoRepository)
        {
            _pagoRepository = pagoRepository;
        }

        public async Task<List<Pago>> GetAllAsync()
        {
            return await _pagoRepository.GetAllAsync();
        }

        public async Task<Pago?> GetByIdAsync(int id)
        {
            return await _pagoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Pago pago)
        {
            await _pagoRepository.AddAsync(pago);
        }
    }
}
