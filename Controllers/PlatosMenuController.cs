using Microsoft.AspNetCore.Mvc;
using BirrasBares.Services;
using BirrasBares.Models;
using Microsoft.AspNetCore.Authorization;

namespace BirrasBares.Controllers
{
    public class PlatosMenuController : Controller
    {
        private readonly IPlatoMenuService _platoMenuService;

        public PlatosMenuController(IPlatoMenuService platoMenuService)
        {
            _platoMenuService = platoMenuService;
        }

        public async Task<IActionResult> Index()
        {
            var platosMenu = await _platoMenuService.GetAllPlatosMenuAsync();
            return View(platosMenu);
        }

        public async Task<IActionResult> Details(int id)
        {
            var platoMenu = await _platoMenuService.GetPlatoMenuByIdAsync(id);
            if (platoMenu == null)
            {
                return NotFound();
            }
            return View(platoMenu);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlatoMenu platoMenu)
        {
            if (ModelState.IsValid)
            {
                await _platoMenuService.CreatePlatoMenuAsync(platoMenu);
                return RedirectToAction(nameof(Index));
            }
            return View(platoMenu);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var platoMenu = await _platoMenuService.GetPlatoMenuByIdAsync(id);
            if (platoMenu == null)
            {
                return NotFound();
            }
            return View(platoMenu);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PlatoMenu platoMenu)
        {
            if (id != platoMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _platoMenuService.UpdatePlatoMenuAsync(platoMenu);
                return RedirectToAction(nameof(Index));
            }
            return View(platoMenu);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _platoMenuService.DeletePlatoMenuAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PlatosByBar(int barId)
        {
            var platosMenu = await _platoMenuService.GetPlatosMenuByBarIdAsync(barId);
            return View(platosMenu);
        }
    }
}