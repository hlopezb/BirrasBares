using BirrasBares.Models;
using BirrasBares.Repositories;
using BirrasBares.ViewModel;

namespace BirrasBares.Services
{
    public class CervezaService : ICervezaService
    {
        private readonly ICervezaRepository _cervezaRepository;

        public CervezaService(ICervezaRepository cervezaRepository)
        {
            _cervezaRepository = cervezaRepository;
        }

        public async Task<IEnumerable<Cerveza>> GetAllCervezasAsync()
        {
            return await _cervezaRepository.GetAllCervezasAsync();
        }

        public async Task<Cerveza> GetCervezaByIdAsync(int id)
        {
            return await _cervezaRepository.GetCervezaByIdAsync(id);
        }

        public async Task<Cerveza> CreateCervezaAsync(Cerveza cerveza)
        {
            return await _cervezaRepository.AddCervezaAsync(cerveza);
        }

        public async Task UpdateCervezaAsync(Cerveza cerveza)
        {
            await _cervezaRepository.UpdateCervezaAsync(cerveza);
        }

        public async Task DeleteCervezaAsync(int id)
        {
            await _cervezaRepository.DeleteCervezaAsync(id);
        }

        public async Task ClasificarCervezaAsync(int cervezaId, string userId, int puntuacion)
        {
            var clasificacion = new CervezaClasificacion
            {
                CervezaId = cervezaId,
                UserId = userId,
                Puntuacion = puntuacion
            };
            await _cervezaRepository.AddOrUpdateCervezaClasificacionAsync(clasificacion);
        }

        public async Task<IEnumerable<CervezaListViewModel>> SearchCervezasAsync(string marcaNombre, string estilo, decimal? graduacionMin, decimal? graduacionMax, int? ibuMin, int? ibuMax, bool? esArtesanal)
        {
            var cervezas = await _cervezaRepository.SearchCervezasAsync(marcaNombre, estilo, graduacionMin, graduacionMax, ibuMin, ibuMax, esArtesanal);
            return cervezas.Select(c => new CervezaListViewModel
            {
                Id = c.Id,
                Nombre = c.Nombre,
                MarcaNombre = c.Marca.Nombre,
                Estilo = c.Estilo,
                Graduacion = c.Graduacion
            });
        }

        public async Task<CervezaDetailsViewModel> GetCervezaDetailsAsync(int id)
        {
            var cerveza = await _cervezaRepository.GetCervezaByIdAsync(id);
            if (cerveza == null) return null;

            return new CervezaDetailsViewModel
            {
                Id = cerveza.Id,
                Nombre = cerveza.Nombre,
                MarcaNombre = cerveza.Marca.Nombre,
                Estilo = cerveza.Estilo,
                Graduacion = cerveza.Graduacion,
                IBU = cerveza.IBU,
                Descripcion = cerveza.Descripcion,
                Color = cerveza.Color,
                Aroma = cerveza.Aroma,
                Sabor = cerveza.Sabor,
                Maridaje = cerveza.Maridaje,
                EsArtesanal = cerveza.EsArtesanal,
                DisponibleTodoElAño = cerveza.DisponibleTodoElAño,
                ImagenUrl = cerveza.ImagenUrl
            };
        }

        public async Task<IEnumerable<string>> GetAllEstilosAsync()
        {
            return await _cervezaRepository.GetAllEstilosAsync();
        }
    }
}