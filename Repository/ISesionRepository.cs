using Models;

namespace Reto_Back.Repositories
{
    public interface ISesionRepository
    {
        Task<List<Sesion>> GetAllAsync();
        Task<Sesion?> GetByIdAsync(int id);
        Task<List<Sesion>> GetByMovieAsync(int movieId);
        Task AddAsync(Sesion sesion);
        Task UpdateAsync(Sesion sesion);
        Task DeleteAsync(int id);
}
}
