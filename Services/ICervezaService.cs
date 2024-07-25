using BirrasBares.Models;
using BirrasBares.ViewModel;

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
        Task<IEnumerable<CervezaListViewModel>> SearchCervezasAsync(string marcaNombre, string estilo, decimal? graduacionMin, decimal? graduacionMax, int? ibuMin, int? ibuMax, bool? esArtesanal);
        Task<CervezaDetailsViewModel> GetCervezaDetailsAsync(int id);
        Task<IEnumerable<string>> GetAllEstilosAsync();
    }
}