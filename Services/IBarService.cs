using BirrasBares.Models;

namespace BirrasBares.Services
{
    public interface IBarService
    {
        Task<IEnumerable<Bar>> GetAllBarsAsync();
        Task<Bar> GetBarByIdAsync(int id);
        Task<Bar> CreateBarAsync(Bar bar);
        Task UpdateBarAsync(Bar bar);
        Task DeleteBarAsync(int id);
        Task ClasificarBarAsync(int barId, string userId, int puntuacion);
    }
}