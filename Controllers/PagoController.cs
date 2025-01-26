using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _servicePago;

        public PagoController(IPagoService servicePago)
        {
            _servicePago = servicePago;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pago>>> GetPagos()
        {
            var pagos = await _servicePago.GetAllAsync();
            return Ok(pagos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pago>> GetPago(int id)
        {
            var pago = await _servicePago.GetByIdAsync(id);
            if (pago == null)
            {
                return NotFound($"Pago con ID {id} no encontrado.");
            }
            return Ok(pago);
        }

        [HttpPost]
        public async Task<ActionResult<Pago>> CreatePago(Pago pago)
        {
            var existingPago = await _servicePago.GetByIdAsync(pago.Id);
            if (existingPago != null)
            {
                return Conflict($"Ya existe un pago con el ID {pago.Id}.");
            }

            await _servicePago.AddAsync(pago);
            return CreatedAtAction(nameof(GetPago), new { id = pago.Id }, pago);
        }
    }
}
