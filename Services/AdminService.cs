using Models;
using Reto_Back.Repositories;
using Reto_Back.Services;

namespace Reto_Back.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRespository _adminRepository;

        public AdminService(IAdminRespository adminRespository)
        {
            _adminRepository = adminRespository;
        }

        public async Task<List<Admin>> GetAllAsync()
        {
            return await _adminRepository.GetAllAsync();
        }

        public async Task<Admin?> GetByIdAsync(int id)
        {
            return await _adminRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Admin admin)
        {
            await _adminRepository.AddAsync(admin);
        }

        public async Task UpdateAsync(Admin admin)
        {
            await _adminRepository.UpdateAsync(admin);
        }

        public async Task DeleteAsync(int id)
        {
            var admin = await _adminRepository.GetByIdAsync(id);
            if (admin == null)
            {
                // Manejar el caso de no encontrado
            }
            await _adminRepository.DeleteAsync(id);
        }
    }
}
