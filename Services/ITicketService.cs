using Models;

namespace Reto_Back.Services
{
    public interface ITicketService
    {
    Task<List<Ticket>> GetAllAsync();
    Task<Ticket?> GetByIdAsync(int id);
    Task<Ticket?> CreateTicketAsync(Ticket ticket);
    Task<bool> CancelTicketAsync(int id);
    Task UpdateAsync(int id, Ticket ticket);
    Task DeleteAsync(int id);
    }
}
