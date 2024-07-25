using BirrasBares.Models;
using BirrasBares.Services;
using BirrasBares.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace BirrasBares.Controllers
{
    public class CervezasController : Controller
    {
        private readonly ICervezaService _cervezaService;
        private readonly IMarcaService _marcaService;

        public CervezasController(ICervezaService cervezaService, IMarcaService marcaService)
        {
            _cervezaService = cervezaService;
            _marcaService = marcaService;
        }

        public async Task<IActionResult> Index(CervezaSearchViewModel searchModel)
        {
            var cervezas = await _cervezaService.SearchCervezasAsync(
                searchModel.MarcaNombre,
                searchModel.Estilo,
                searchModel.GraduacionMin,
                searchModel.GraduacionMax,
                searchModel.IBUMin,
                searchModel.IBUMax,
                searchModel.EsArtesanal
            );

            var marcas = await _marcaService.GetAllMarcasAsync();
            var estilos = await _cervezaService.GetAllEstilosAsync();

            var viewModel = new CervezaSearchViewModel
            {
                Cervezas = cervezas.ToList(),
                Marcas = new SelectList(marcas, "Nombre", "Nombre", searchModel.MarcaNombre),
                Estilos = new SelectList(estilos, searchModel.Estilo),
                MarcaNombre = searchModel.MarcaNombre,
                Estilo = searchModel.Estilo,
                GraduacionMin = searchModel.GraduacionMin,
                GraduacionMax = searchModel.GraduacionMax,
                IBUMin = searchModel.IBUMin,
                IBUMax = searchModel.IBUMax,
                EsArtesanal = searchModel.EsArtesanal
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cerveza = await _cervezaService.GetCervezaDetailsAsync(id);
            if (cerveza == null)
            {
                return NotFound();
            }
            return PartialView("_CervezaDetails", cerveza);
        }

        public IActionResult LimpiarFiltros()
        {
            return RedirectToAction(nameof(Index));
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