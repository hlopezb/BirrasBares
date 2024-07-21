using Microsoft.AspNetCore.Mvc;
using BirrasBares.Services;
using BirrasBares.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BirrasBares.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaresApiController : ControllerBase
    {
        private readonly IBarService _barService;

        public BaresApiController(IBarService barService)
        {
            _barService = barService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bar>>> GetBares()
        {
            var bares = await _barService.GetAllBarsAsync();
            return Ok(bares);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bar>> GetBar(int id)
        {
            var bar = await _barService.GetBarByIdAsync(id);
            if (bar == null)
            {
                return NotFound();
            }
            return Ok(bar);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Bar>> PostBar(Bar bar)
        {
            var createdBar = await _barService.CreateBarAsync(bar);
            return CreatedAtAction(nameof(GetBar), new { id = createdBar.Id }, createdBar);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutBar(int id, Bar bar)
        {
            if (id != bar.Id)
            {
                return BadRequest();
            }
            await _barService.UpdateBarAsync(bar);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBar(int id)
        {
            await _barService.DeleteBarAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/clasificar")]
        [Authorize]
        public async Task<IActionResult> ClasificarBar(int id, [FromBody] int puntuacion)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _barService.ClasificarBarAsync(id, userId, puntuacion);
            return NoContent();
        }
    }
}