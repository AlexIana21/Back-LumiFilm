using Models;

namespace Reto_Back.Services
{
    public interface ISeatService
    {
        Task<List<Seat>> GetAllAsync();
        Task<Seat?> GetByIdAsync(int id);
        Task AddAsync(Seat seat);
        Task UpdateAsync(Seat seat);
        Task DeleteAsync(int id);
    }
}
