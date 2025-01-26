using Models;

namespace Reto_Back.Repositories
{
    public interface IAsientoRepository
    {
        Task<List<Asiento>> GetAllAsync();
        Task<Asiento?> GetByIdAsync(int id);
        Task AddAsync(Asiento asiento);
        Task UpdateAsync(Asiento asiento);
        Task DeleteAsync(int id);
    }
}
