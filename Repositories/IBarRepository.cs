using BirrasBares.Models;

namespace BirrasBares.Repositories
{
    public interface IBarRepository
    {
        Task<IEnumerable<Bar>> GetAllBarsAsync();
        Task<Bar> GetBarByIdAsync(int id);
        Task<Bar> AddBarAsync(Bar bar);
        Task UpdateBarAsync(Bar bar);
        Task DeleteBarAsync(int id);
        Task<BarClasificacion> GetBarClasificacionAsync(int barId, string userId);
        Task AddOrUpdateBarClasificacionAsync(BarClasificacion clasificacion);
    }
}