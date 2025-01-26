using Models;

namespace Reto_Back.Services
{
    public interface IPagoService
    {
        Task<List<Pago>> GetAllAsync();
        Task<Pago?> GetByIdAsync(int id);
        Task AddAsync(Pago pago);
    }
}
