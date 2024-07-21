using BirrasBares.Models;
using BirrasBares.Repositories;

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
    }
}