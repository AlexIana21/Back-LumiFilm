using Models;

namespace Reto_Back.Services
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllAsync();
        Task<Review?> GetByIdAsync(int id);
        Task AddAsync(Review review);
        Task UpdateAsync(Review review);
        Task DeleteAsync(int id);

        //Task GetComentarioByPeliculaAsync(int idPelicula);
        //Para filtrar las opiniones por peliculas 
    }
}
