using BirrasBares.Data;
using BirrasBares.Models;
using Microsoft.EntityFrameworkCore;

namespace BirrasBares.Repositories
{
    public class CervezaRepository : ICervezaRepository
    {
        private readonly ApplicationDbContext _context;

        public CervezaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cerveza>> GetAllCervezasAsync()
        {
            return await _context.Cervezas.Include(c => c.Clasificaciones).ToListAsync();
        }

        public async Task<Cerveza> GetCervezaByIdAsync(int id)
        {
            return await _context.Cervezas
                .Include(c => c.Clasificaciones)
                .Include(c => c.BaresCervezas)
                    .ThenInclude(bc => bc.Bar)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cerveza> AddCervezaAsync(Cerveza cerveza)
        {
            _context.Cervezas.Add(cerveza);
            await _context.SaveChangesAsync();
            return cerveza;
        }

        public async Task UpdateCervezaAsync(Cerveza cerveza)
        {
            _context.Entry(cerveza).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCervezaAsync(int id)
        {
            var cerveza = await _context.Cervezas.FindAsync(id);
            if (cerveza != null)
            {
                _context.Cervezas.Remove(cerveza);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CervezaClasificacion> GetCervezaClasificacionAsync(int cervezaId, string userId)
        {
            return await _context.CervezaClasificaciones
                .FirstOrDefaultAsync(cc => cc.CervezaId == cervezaId && cc.UserId == userId);
        }

        public async Task AddOrUpdateCervezaClasificacionAsync(CervezaClasificacion clasificacion)
        {
            var existingClasificacion = await GetCervezaClasificacionAsync(clasificacion.CervezaId, clasificacion.UserId);
            if (existingClasificacion == null)
            {
                _context.CervezaClasificaciones.Add(clasificacion);
            }
            else
            {
                existingClasificacion.Puntuacion = clasificacion.Puntuacion;
                _context.CervezaClasificaciones.Update(existingClasificacion);
            }
            await _context.SaveChangesAsync();
        }
    }
}