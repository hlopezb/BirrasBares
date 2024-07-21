using BirrasBares.Models;

namespace BirrasBares.Services
{
    public interface ICervezaService
    {
        Task<IEnumerable<Cerveza>> GetAllCervezasAsync();
        Task<Cerveza> GetCervezaByIdAsync(int id);
        Task<Cerveza> CreateCervezaAsync(Cerveza cerveza);
        Task UpdateCervezaAsync(Cerveza cerveza);
        Task DeleteCervezaAsync(int id);
        Task ClasificarCervezaAsync(int cervezaId, string userId, int puntuacion);
    }
}