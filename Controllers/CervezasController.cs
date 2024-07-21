using Microsoft.AspNetCore.Mvc;
using BirrasBares.Services;
using BirrasBares.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BirrasBares.Controllers
{
    public class CervezasController : Controller
    {
        private readonly ICervezaService _cervezaService;

        public CervezasController(ICervezaService cervezaService)
        {
            _cervezaService = cervezaService;
        }

        public async Task<IActionResult> Index()
        {
            var cervezas = await _cervezaService.GetAllCervezasAsync();
            return View(cervezas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cerveza = await _cervezaService.GetCervezaByIdAsync(id);
            if (cerveza == null)
            {
                return NotFound();
            }
            return View(cerveza);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cerveza cerveza)
        {
            if (ModelState.IsValid)
            {
                await _cervezaService.CreateCervezaAsync(cerveza);
                return RedirectToAction(nameof(Index));
            }
            return View(cerveza);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var cerveza = await _cervezaService.GetCervezaByIdAsync(id);
            if (cerveza == null)
            {
                return NotFound();
            }
            return View(cerveza);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cerveza cerveza)
        {
            if (id != cerveza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _cervezaService.UpdateCervezaAsync(cerveza);
                return RedirectToAction(nameof(Index));
            }
            return View(cerveza);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _cervezaService.DeleteCervezaAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clasificar(int id, int puntuacion)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _cervezaService.ClasificarCervezaAsync(id, userId, puntuacion);
            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}