using Models;

namespace Reto_Back.Repositories
{
    public interface IPagoRepository
    {
        Task<List<Admin>> GetAllAsync();
        Task<Admin?> GetByIdAsync(int id);
        Task AddAsync(Admin admin);
    }
}
