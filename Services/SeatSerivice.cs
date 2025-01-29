using Models;
using Reto_Back.Repositories;
using Reto_Back.Services;

namespace Reto_Back.Service
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<List<Seat>> GetAllAsync()
        {
            return await _seatRepository.GetAllAsync();
        }

        public async Task<Seat?> GetByIdAsync(int id)
        {
            return await _seatRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Seat seat)
        {
            await _seatRepository.AddAsync(seat);
        }

        public async Task UpdateAsync(Seat seat)
        {
            await _seatRepository.UpdateAsync(seat);
        }

        public async Task DeleteAsync(int id)
        {
           var seat = await _seatRepository.GetByIdAsync(id);
           if (seat == null)
           {
               //return NotFound();
           }
           await _seatRepository.DeleteAsync(id);
           //return NoContent();
        }
        
    }
}