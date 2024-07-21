using BirrasBares.Models;

namespace BirrasBares.Repositories
{
    public interface IPlatoMenuRepository
    {
        Task<IEnumerable<PlatoMenu>> GetAllPlatosMenuAsync();
        Task<PlatoMenu> GetPlatoMenuByIdAsync(int id);
        Task<PlatoMenu> AddPlatoMenuAsync(PlatoMenu platoMenu);
        Task UpdatePlatoMenuAsync(PlatoMenu platoMenu);
        Task DeletePlatoMenuAsync(int id);
        Task<IEnumerable<PlatoMenu>> GetPlatosMenuByBarIdAsync(int barId);
    }
}