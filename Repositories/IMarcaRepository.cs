using BirrasBares.Models;

namespace BirrasBares.Repositories
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> GetAllMarcasAsync();
        Task<Marca> GetMarcaByIdAsync(int id);
        Task<Marca> CreateMarcaAsync(Marca marca);
        Task UpdateMarcaAsync(Marca marca);
        Task DeleteMarcaAsync(int id);
    }
}