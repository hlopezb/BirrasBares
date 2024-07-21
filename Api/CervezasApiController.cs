using Microsoft.AspNetCore.Mvc;
using BirrasBares.Services;
using BirrasBares.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BirrasBares.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CervezasApiController : ControllerBase
    {
        private readonly ICervezaService _cervezaService;

        public CervezasApiController(ICervezaService cervezaService)
        {
            _cervezaService = cervezaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cerveza>>> GetCervezas()
        {
            var cervezas = await _cervezaService.GetAllCervezasAsync();
            return Ok(cervezas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cerveza>> GetCerveza(int id)
        {
            var cerveza = await _cervezaService.GetCervezaByIdAsync(id);
            if (cerveza == null)
            {
                return NotFound();
            }
            return Ok(cerveza);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Cerveza>> PostCerveza(Cerveza cerveza)
        {
            var createdCerveza = await _cervezaService.CreateCervezaAsync(cerveza);
            return CreatedAtAction(nameof(GetCerveza), new { id = createdCerveza.Id }, createdCerveza);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCerveza(int id, Cerveza cerveza)
        {
            if (id != cerveza.Id)
            {
                return BadRequest();
            }
            await _cervezaService.UpdateCervezaAsync(cerveza);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCerveza(int id)
        {
            await _cervezaService.DeleteCervezaAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/clasificar")]
        [Authorize]
        public async Task<IActionResult> ClasificarCerveza(int id, [FromBody] int puntuacion)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _cervezaService.ClasificarCervezaAsync(id, userId, puntuacion);
            return NoContent();
        }
    }
}