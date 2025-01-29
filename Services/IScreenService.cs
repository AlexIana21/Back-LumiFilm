using Models;

namespace Reto_Back.Services
{
    public interface IScreenService
    {
        Task<List<Screen>> GetAllAsync();
        Task<Screen?> GetByIdAsync(int id);
        Task AddAsync(Screen screen);
        Task UpdateAsync(Screen screen);
        Task DeleteAsync(int id);
    }
}
