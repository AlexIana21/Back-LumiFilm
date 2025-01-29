using Models;

namespace Reto_Back.Services
{
    public interface ISessionService
    {
        Task<List<Session>> GetAllAsync();
        Task<Session?> GetByIdAsync(int id);
        Task<List<Session?>> GetByMovieAsync(int movieId);
        Task AddAsync(Session session);
        Task UpdateAsync(Session session);
        Task DeleteAsync(int id);
    }
}
