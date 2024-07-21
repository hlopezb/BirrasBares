using BirrasBares.Models;
using BirrasBares.Repositories;

namespace BirrasBares.Services
{
    public class PlatoMenuService : IPlatoMenuService
    {
        private readonly IPlatoMenuRepository _platoMenuRepository;

        public PlatoMenuService(IPlatoMenuRepository platoMenuRepository)
        {
            _platoMenuRepository = platoMenuRepository;
        }

        public async Task<IEnumerable<PlatoMenu>> GetAllPlatosMenuAsync()
        {
            return await _platoMenuRepository.GetAllPlatosMenuAsync();
        }

        public async Task<PlatoMenu> GetPlatoMenuByIdAsync(int id)
        {
            return await _platoMenuRepository.GetPlatoMenuByIdAsync(id);
        }

        public async Task<PlatoMenu> CreatePlatoMenuAsync(PlatoMenu platoMenu)
        {
            return await _platoMenuRepository.AddPlatoMenuAsync(platoMenu);
        }

        public async Task UpdatePlatoMenuAsync(PlatoMenu platoMenu)
        {
            await _platoMenuRepository.UpdatePlatoMenuAsync(platoMenu);
        }

        public async Task DeletePlatoMenuAsync(int id)
        {
            await _platoMenuRepository.DeletePlatoMenuAsync(id);
        }

        public async Task<IEnumerable<PlatoMenu>> GetPlatosMenuByBarIdAsync(int barId)
        {
            return await _platoMenuRepository.GetPlatosMenuByBarIdAsync(barId);
        }
    }
}