using Microsoft.AspNetCore.Mvc;
using BirrasBares.Services;
using BirrasBares.Models;
using Microsoft.AspNetCore.Authorization;

namespace BirrasBares.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatosMenuApiController : ControllerBase
    {
        private readonly IPlatoMenuService _platoMenuService;

        public PlatosMenuApiController(IPlatoMenuService platoMenuService)
        {
            _platoMenuService = platoMenuService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatoMenu>>> GetPlatosMenu()
        {
            var platosMenu = await _platoMenuService.GetAllPlatosMenuAsync();
            return Ok(platosMenu);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlatoMenu>> GetPlatoMenu(int id)
        {
            var platoMenu = await _platoMenuService.GetPlatoMenuByIdAsync(id);
            if (platoMenu == null)
            {
                return NotFound();
            }
            return Ok(platoMenu);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PlatoMenu>> PostPlatoMenu(PlatoMenu platoMenu)
        {
            var createdPlatoMenu = await _platoMenuService.CreatePlatoMenuAsync(platoMenu);
            return CreatedAtAction(nameof(GetPlatoMenu), new { id = createdPlatoMenu.Id }, createdPlatoMenu);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutPlatoMenu(int id, PlatoMenu platoMenu)
        {
            if (id != platoMenu.Id)
            {
                return BadRequest();
            }
            await _platoMenuService.UpdatePlatoMenuAsync(platoMenu);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePlatoMenu(int id)
        {
            await _platoMenuService.DeletePlatoMenuAsync(id);
            return NoContent();
        }

        [HttpGet("bar/{barId}")]
        public async Task<ActionResult<IEnumerable<PlatoMenu>>> GetPlatosMenuByBar(int barId)
        {
            var platosMenu = await _platoMenuService.GetPlatosMenuByBarIdAsync(barId);
            return Ok(platosMenu);
        }
    }
}