using Models;
using Reto_Back.Repositories;
using Reto_Back.Services;

namespace Reto_Back.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _ticketRepository.GetAllAsync();
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _ticketRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Ticket ticket)
        {
            await _ticketRepository.AddAsync(ticket);
        }

        public async Task UpdateAsync(int id, Ticket ticket)
        {
            var existingTicket = await _ticketRepository.GetByIdAsync(id);
            if (existingTicket != null)
            {
                await _ticketRepository.UpdateAsync(ticket);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket != null)
            {
                await _ticketRepository.DeleteAsync(id);
            }
        }

        public async Task<Ticket?> CreateTicketAsync(Ticket ticket)
        {
            await _ticketRepository.AddAsync(ticket);
            return ticket;
        }

        public async Task<bool> CancelTicketAsync(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket != null)
            {
                await _ticketRepository.DeleteAsync(id);
                return true;
            }
            return false;
        }
    }
}
