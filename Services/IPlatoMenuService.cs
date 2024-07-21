using BirrasBares.Models;

namespace BirrasBares.Services
{
    public interface IPlatoMenuService
    {
        Task<IEnumerable<PlatoMenu>> GetAllPlatosMenuAsync();
        Task<PlatoMenu> GetPlatoMenuByIdAsync(int id);
        Task<PlatoMenu> CreatePlatoMenuAsync(PlatoMenu platoMenu);
        Task UpdatePlatoMenuAsync(PlatoMenu platoMenu);
        Task DeletePlatoMenuAsync(int id);
        Task<IEnumerable<PlatoMenu>> GetPlatosMenuByBarIdAsync(int barId);
    }
}