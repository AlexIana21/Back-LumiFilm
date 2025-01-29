using Models;

namespace Reto_Back.Repositories
{
    public interface ISessionRepository
    {
        Task<List<Session>> GetAllAsync();
        Task<Session?> GetByIdAsync(int id);
        Task<List<Session>> GetByMovieAsync(int movieId);
        Task AddAsync(Session sesion);
        Task UpdateAsync(Session sesion);
        Task DeleteAsync(int id);
}
}
