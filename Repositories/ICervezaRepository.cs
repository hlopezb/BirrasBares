using BirrasBares.Models;

namespace BirrasBares.Repositories
{
    public interface ICervezaRepository
    {
        Task<IEnumerable<Cerveza>> GetAllCervezasAsync();
        Task<Cerveza> GetCervezaByIdAsync(int id);
        Task<Cerveza> AddCervezaAsync(Cerveza cerveza);
        Task UpdateCervezaAsync(Cerveza cerveza);
        Task DeleteCervezaAsync(int id);
        Task<CervezaClasificacion> GetCervezaClasificacionAsync(int cervezaId, string userId);
        Task AddOrUpdateCervezaClasificacionAsync(CervezaClasificacion clasificacion);
        Task<IEnumerable<Cerveza>> SearchCervezasAsync(string marcaNombre, string estilo, decimal? graduacionMin, decimal? graduacionMax, int? ibuMin, int? ibuMax, bool? esArtesanal);
        Task<IEnumerable<string>> GetAllEstilosAsync();
    }
}