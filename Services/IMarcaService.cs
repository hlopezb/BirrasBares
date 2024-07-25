using BirrasBares.Models;
using BirrasBares.ViewModel;

namespace BirrasBares.Services
{
    public interface IMarcaService
    {
        Task<IEnumerable<MarcaViewModel>> GetAllMarcasAsync();
        Task<MarcaViewModel> GetMarcaByIdAsync(int id);
        Task<Marca> CreateMarcaAsync(Marca marca);
        Task UpdateMarcaAsync(Marca marca);
        Task DeleteMarcaAsync(int id);
    }
}