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
        private readonly IPlatoMenuService _platoMenuService;

        public BaresController(IBarService barService, IPlatoMenuService platoMenuService)
        {
            _barService = barService;
            _platoMenuService = platoMenuService;
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

        public async Task<IActionResult> Menu(int id)
        {
            var bar = await _barService.GetBarByIdAsync(id);
            if (bar == null)
            {
                return NotFound();
            }

            var platosMenu = await _platoMenuService.GetPlatosMenuByBarIdAsync(id);
            ViewBag.BarNombre = bar.Nombre;
            ViewBag.BarId = bar.Id;
            return View(platosMenu);
        }

        [HttpGet]
        public IActionResult CreatePlato(int barId)
        {
            ViewBag.BarId = barId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlato(PlatoMenu platoMenu)
        {
            if (ModelState.IsValid)
            {
                await _platoMenuService.CreatePlatoMenuAsync(platoMenu);
                return RedirectToAction(nameof(Menu), new { id = platoMenu.BarId });
            }
            return View(platoMenu);
        }

        [HttpGet]
        public async Task<IActionResult> EditPlato(int id)
        {
            var plato = await _platoMenuService.GetPlatoMenuByIdAsync(id);
            if (plato == null)
            {
                return NotFound();
            }
            return View(plato);
        }

        [HttpPost]
        public async Task<IActionResult> EditPlato(int id, PlatoMenu platoMenu)
        {
            if (id != platoMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _platoMenuService.UpdatePlatoMenuAsync(platoMenu);
                return RedirectToAction(nameof(Menu), new { id = platoMenu.BarId });
            }
            return View(platoMenu);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePlato(int id)
        {
            var plato = await _platoMenuService.GetPlatoMenuByIdAsync(id);
            if (plato == null)
            {
                return NotFound();
            }

            await _platoMenuService.DeletePlatoMenuAsync(id);
            return RedirectToAction(nameof(Menu), new { id = plato.BarId });
        }
    }
}