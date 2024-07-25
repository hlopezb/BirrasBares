using BirrasBares.Data;
using BirrasBares.Models;
using Microsoft.EntityFrameworkCore;

namespace BirrasBares.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly ApplicationDbContext _context;

        public MarcaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Marca>> GetAllMarcasAsync()
        {
            return await _context.Marcas.ToListAsync();
        }

        public async Task<Marca> GetMarcaByIdAsync(int id)
        {
            return await _context.Marcas.FindAsync(id);
        }

        public async Task<Marca> CreateMarcaAsync(Marca marca)
        {
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();
            return marca;
        }

        public async Task UpdateMarcaAsync(Marca marca)
        {
            _context.Entry(marca).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMarcaAsync(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca != null)
            {
                _context.Marcas.Remove(marca);
                await _context.SaveChangesAsync();
            }
        }
    }
}