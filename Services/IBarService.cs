using BirrasBares.Models;
using BirrasBares.ViewModel;

namespace BirrasBares.Services
{
    public interface IBarService
    {
        Task<IEnumerable<BarListViewModel>> GetAllBarsAsync();
        Task<BarDetailsViewModel> GetBarDetailsAsync(int id);
        Task<Bar> GetBarByIdAsync(int id);
        Task<Bar> CreateBarAsync(Bar bar);
        Task UpdateBarAsync(Bar bar);
        Task DeleteBarAsync(int id);
        Task ClasificarBarAsync(int barId, string userId, int puntuacion);
    }
}