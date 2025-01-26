using Models;

namespace Reto_Back.Services
{
    public interface IAsientoService
    {
        Task<List<Asiento>> GetAllAsync();
        Task<Asiento?> GetByIdAsync(int id);
        Task AddAsync(Asiento asiento);
        Task UpdateAsync(Asiento asiento);
        Task DeleteAsync(int id);
    }
}
