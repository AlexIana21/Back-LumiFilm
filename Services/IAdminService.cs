using Models;
namespace Reto_Back.Services
{
    public interface IAdminService
    {
        Task<List<Admin>> GetAllAsync();
        Task<Admin?> GetByIdAsync(int id);
        Task AddAsync(Admin admin);
        Task UpdateAsync(Admin admin);
        Task DeleteAsync(int id);
    }
}
