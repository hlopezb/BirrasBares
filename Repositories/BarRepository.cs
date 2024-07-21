using BirrasBares.Data;
using BirrasBares.Models;
using Microsoft.EntityFrameworkCore;

namespace BirrasBares.Repositories
{
    public class BarRepository : IBarRepository
    {
        private readonly ApplicationDbContext _context;

        public BarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bar>> GetAllBarsAsync()
        {
            return await _context.Bares.Include(b => b.Clasificaciones).ToListAsync();
        }

        public async Task<Bar> GetBarByIdAsync(int id)
        {
            return await _context.Bares
                .Include(b => b.Clasificaciones)
                .Include(b => b.BaresCervezas)
                    .ThenInclude(bc => bc.Cerveza)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Bar> AddBarAsync(Bar bar)
        {
            _context.Bares.Add(bar);
            await _context.SaveChangesAsync();
            return bar;
        }

        public async Task UpdateBarAsync(Bar bar)
        {
            _context.Entry(bar).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBarAsync(int id)
        {
            var bar = await _context.Bares.FindAsync(id);
            if (bar != null)
            {
                _context.Bares.Remove(bar);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<BarClasificacion> GetBarClasificacionAsync(int barId, string userId)
        {
            return await _context.BarClasificaciones
                .FirstOrDefaultAsync(bc => bc.BarId == barId && bc.UserId == userId);
        }

        public async Task AddOrUpdateBarClasificacionAsync(BarClasificacion clasificacion)
        {
            var existingClasificacion = await GetBarClasificacionAsync(clasificacion.BarId, clasificacion.UserId);
            if (existingClasificacion == null)
            {
                _context.BarClasificaciones.Add(clasificacion);
            }
            else
            {
                existingClasificacion.Puntuacion = clasificacion.Puntuacion;
                _context.BarClasificaciones.Update(existingClasificacion);
            }
            await _context.SaveChangesAsync();
        }
    }
}