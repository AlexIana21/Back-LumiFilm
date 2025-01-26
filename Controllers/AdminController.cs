using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _serviceAdmin;

        public AdminController(IAdminService serviceAdmin)
        {
            _serviceAdmin = serviceAdmin;
        }

        [HttpGet]
        public async Task<ActionResult<List<Admin>>> GetAdmins()
        {
            var admins = await _serviceAdmin.GetAllAsync();
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var admin = await _serviceAdmin.GetByIdAsync(id);
            if (admin == null)
            {
                return NotFound($"Admin con ID {id} no encontrado.");
            }
            return Ok(admin);
        }

        [HttpPost]
        public async Task<ActionResult<Sala>> CreateSala(Admin admin)
        {
            var existindAdmin = await _serviceAdmin.GetByIdAsync(admin.Id);
            if (existindAdmin != null)
            {
                return Conflict($"Ya existe un admin con el ID {admin.Id}.");
            }

            await _serviceAdmin.AddAsync(admin);
            return CreatedAtAction(nameof(GetAdmin), new { id = admin.Id }, admin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(int id, Admin updateAdmin)
        {
            var existindAdmin = await _serviceAdmin.GetByIdAsync(id);
            if (existindAdmin == null)
            {
                return NotFound($"Admin con ID {id} no encontrada.");
            }
            // Actualizar el admin existente
            existindAdmin.Nombre = updateAdmin.Nombre;
            existindAdmin.Apellido = updateAdmin.Apellido;
            existindAdmin.Mail = updateAdmin.Mail;
            existindAdmin.Password = updateAdmin.Password;

            await _serviceAdmin.UpdateAsync(existindAdmin);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = await _serviceAdmin.GetByIdAsync(id);
            if (admin == null)
            {
                return NotFound($"Admin con ID {id} no encontrado.");
            }

            await _serviceAdmin.DeleteAsync(id);
            return NoContent();
        }
    }
}
