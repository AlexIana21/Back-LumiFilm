using Models;
using Reto_Back.Repositories;
using Reto_Back.Service;
using Reto_Back.Services;

namespace Reto_Back.Service
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository) 
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<List<Session>> GetAllAsync()
        {
            return await _sessionRepository.GetAllAsync();
        }

        public async Task<Session?> GetByIdAsync(int id)
        {
            return await _sessionRepository.GetByIdAsync(id);
        }

        public async Task<List<Session>> GetByMovieAsync(int movieId)
        {
            
            return await _sessionRepository.GetByMovieAsync(movieId);
        }


        public async Task AddAsync(Session session)
        {
            await _sessionRepository.AddAsync(session);
        }

        public async Task UpdateAsync(Session session)
        {
            await _sessionRepository.UpdateAsync(session);
        }

        public async Task DeleteAsync(int id)
        {
           var session = await _sessionRepository.GetByIdAsync(id);
           if (session == null)
           {
               //return NotFound();
           }
           await _sessionRepository.DeleteAsync(id);
           //return NoContent();
        }

     
    }
}