using Microsoft.AspNetCore.Mvc;
using BirrasBares.Services;
using BirrasBares.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BirrasBares.Controllers
{
    public class BaresController : Controller
    {
        private readonly IBarService _barService;

        public BaresController(IBarService barService)
        {
            _barService = barService;
        }

        public async Task<IActionResult> Index()
        {
            var bares = await _barService.GetAllBarsAsync();
            return View(bares);
        }

        public async Task<IActionResult> Details(int id)
        {
            var bar = await _barService.GetBarByIdAsync(id);
            if (bar == null)
            {
                return NotFound();
            }
            return View(bar);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bar bar)
        {
            if (ModelState.IsValid)
            {
                await _barService.CreateBarAsync(bar);
                return RedirectToAction(nameof(Index));
            }
            return View(bar);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var bar = await _barService.GetBarByIdAsync(id);
            if (bar == null)
            {
                return NotFound();
            }
            return View(bar);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Bar bar)
        {
            if (id != bar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _barService.UpdateBarAsync(bar);
                return RedirectToAction(nameof(Index));
            }
            return View(bar);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _barService.DeleteBarAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clasificar(int id, int puntuacion)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _barService.ClasificarBarAsync(id, userId, puntuacion);
            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}