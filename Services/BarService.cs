using BirrasBares.Models;
using BirrasBares.Repositories;
using BirrasBares.ViewModel;

namespace BirrasBares.Services
{
    public class BarService : IBarService
    {
        private readonly IBarRepository _barRepository;

        public BarService(IBarRepository barRepository)
        {
            _barRepository = barRepository;
        }

        public async Task<IEnumerable<BarListViewModel>> GetAllBarsAsync()
        {
            var bares = await _barRepository.GetAllBarsAsync();
            return bares.Select(b => new BarListViewModel
            {
                Id = b.Id,
                Nombre = b.Nombre,
                Direccion = b.Direccion,
                TipoBar = b.TipoBar,
                CalificacionPromedio = b.CalificacionPromedio
            });
        }

        public async Task<BarDetailsViewModel> GetBarDetailsAsync(int id)
        {
            var bar = await _barRepository.GetBarByIdAsync(id);
            if (bar == null) return null;

            return new BarDetailsViewModel
            {
                Id = bar.Id,
                Nombre = bar.Nombre,
                Direccion = bar.Direccion,
                TipoBar = bar.TipoBar,
                Descripcion = bar.Descripcion,
                Capacidad = bar.Capacidad,
                AñoApertura = bar.AñoApertura,
                TieneTerraza = bar.TieneTerraza,
                PermiteReservas = bar.PermiteReservas,
                ServiciosAdicionales = bar.ServiciosAdicionales,
                Ambiente = bar.Ambiente,
                RangoPrecios = bar.RangoPrecios,
                CalificacionPromedio = bar.CalificacionPromedio,
                ImagenUrl = bar.ImagenUrl,
                Horarios = bar.Horarios.Select(h => new HorarioViewModel
                {
                    DiaSemana = h.DiaSemana,
                    HoraApertura = h.HoraApertura,
                    HoraCierre = h.HoraCierre
                }).ToList(),
                Cervezas = bar.BaresCervezas.Select(bc => new CervezaEnBarViewModel
                {
                    CervezaId = bc.Cerveza.Id,
                    Nombre = bc.Cerveza.Nombre,
                    Estilo = bc.Cerveza.Estilo,
                    Graduacion = bc.Cerveza.Graduacion,
                    Precio = bc.Precio
                }).ToList(),
                PlatosMenu = bar.PlatosMenu.Select(p => new PlatoMenuViewModel
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    Categoria = p.Categoria
                }).ToList()
            };
        }

        public async Task<Bar> GetBarByIdAsync(int id)
        {
            return await _barRepository.GetBarByIdAsync(id);
        }

        public async Task<Bar> CreateBarAsync(Bar bar)
        {
            return await _barRepository.AddBarAsync(bar);
        }

        public async Task UpdateBarAsync(Bar bar)
        {
            await _barRepository.UpdateBarAsync(bar);
        }

        public async Task DeleteBarAsync(int id)
        {
            await _barRepository.DeleteBarAsync(id);
        }

        public async Task ClasificarBarAsync(int barId, string userId, int puntuacion)
        {
            var clasificacion = new BarClasificacion
            {
                BarId = barId,
                UserId = userId,
                Puntuacion = puntuacion
            };
            await _barRepository.AddOrUpdateBarClasificacionAsync(clasificacion);
        }
    }
}