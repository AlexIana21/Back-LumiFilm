using Models;

namespace Reto_Back.Services
{
    public interface IComentarioService
    {
        Task<List<Comentario>> GetAllAsync();
        Task<Comentario?> GetByIdAsync(int id);
        Task AddAsync(Comentario comentario);
        Task UpdateAsync(Comentario comentario);
        Task DeleteAsync(int id);

        //Task GetComentarioByPeliculaAsync(int idPelicula);
        //Para filtrar las opiniones por peliculas 
    }
}
