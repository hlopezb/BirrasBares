using BirrasBares.Models;
using BirrasBares.Repositories;

namespace BirrasBares.Services
{
    public class BarService : IBarService
    {
        private readonly IBarRepository _barRepository;

        public BarService(IBarRepository barRepository)
        {
            _barRepository = barRepository;
        }

        public async Task<IEnumerable<Bar>> GetAllBarsAsync()
        {
            return await _barRepository.GetAllBarsAsync();
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