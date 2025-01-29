using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _serviceOrder;

        public OrderController(IOrderService serviceOrder)
        {
            _serviceOrder = serviceOrder;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrder()
        {
            var orders = await _serviceOrder.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _serviceOrder.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound($"Pedido con ID {id} no encontrado.");
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            var existingOrder = await _serviceOrder.GetByIdAsync(order.Id);
            if (existingOrder != null)
            {
                return Conflict($"Ya existe un pedido con el ID {order.Id}.");
            }

            await _serviceOrder.AddAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }
    }
}
