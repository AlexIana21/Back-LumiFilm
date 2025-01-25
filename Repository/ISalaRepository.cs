using Models;

namespace Reto_Back.Repositories
{
    public interface ISalaRepository
    {
        Task<List<Sala>> GetAllAsync();
        Task<Sala?> GetByIdAsync(int id);
        Task AddAsync(Sala sala);
        Task UpdateAsync(Sala sala);
        Task DeleteAsync(int id);
    }
}
