using BirrasBares.Models;
using BirrasBares.Repositories;
using BirrasBares.ViewModel;

namespace BirrasBares.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }
        public async Task<IEnumerable<MarcaViewModel>> GetAllMarcasAsync()
        {
            var marcas = await _marcaRepository.GetAllMarcasAsync();
            return marcas.Select(m => new MarcaViewModel
            {
                Id = m.Id,
                Nombre = m.Nombre,
                PaisOrigen = m.PaisOrigen
                // Mapea otras propiedades según sea necesario
            });
        }

        public async Task<MarcaViewModel> GetMarcaByIdAsync(int id)
        {
            var marca = await _marcaRepository.GetMarcaByIdAsync(id);
            if (marca == null) return null;

            return new MarcaViewModel
            {
                Id = marca.Id,
                Nombre = marca.Nombre,
                PaisOrigen = marca.PaisOrigen
                // Mapea otras propiedades según sea necesario
            };
        }

        public async Task<Marca> CreateMarcaAsync(Marca marca)
        {
            return await _marcaRepository.CreateMarcaAsync(marca);
        }

        public async Task UpdateMarcaAsync(Marca marca)
        {
            await _marcaRepository.UpdateMarcaAsync(marca);
        }

        public async Task DeleteMarcaAsync(int id)
        {
            await _marcaRepository.DeleteMarcaAsync(id);
        }
    }
}