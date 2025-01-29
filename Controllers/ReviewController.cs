using Microsoft.AspNetCore.Mvc;
using Models;
using Reto_Back.Services;

namespace Reto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

    private readonly IReviewService _serviceReview;

    public ReviewController(IReviewService serviceReview)
        {
            _serviceReview = serviceReview;
        }

        [HttpGet]
        public async Task<ActionResult<List<Review>>> GetReview()
        {
            var reviews = await _serviceReview.GetAllAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _serviceReview.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        /*[HttpGet("pelicula/{idPelicula}")]
        public async Task<ActionResult<List<Comentario>>> GetComentarioByMovie(int idPelicula)
        {
            var opinionesFiltradas = await _serviceComentario.GetOpinionesByPeliculaAsync(idPelicula);
            if (opinionesFiltradas == null || !opinionesFiltradas.Any())
            {
                return NotFound();
            }
            return Ok(opinionesFiltradas);
        }
        */

        [HttpPost]
        public async Task<ActionResult<Review>> CreateReview(Review review)
        {
            await _serviceReview.AddAsync(review);
            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _serviceReview.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            await _serviceReview.DeleteAsync(id);
            return NoContent();
        }
    }
}
