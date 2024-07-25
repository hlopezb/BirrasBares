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
                .Include(c => c.Marca)
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

        public async Task<IEnumerable<Cerveza>> SearchCervezasAsync(string marcaNombre, string estilo, decimal? graduacionMin, decimal? graduacionMax, int? ibuMin, int? ibuMax, bool? esArtesanal)
        {
            var query = _context.Cervezas.Include(c => c.Marca).AsQueryable();

            if (!string.IsNullOrEmpty(marcaNombre))
                query = query.Where(c => c.Marca.Nombre.Equals(marcaNombre));

            if (!string.IsNullOrEmpty(estilo))
                query = query.Where(c => c.Estilo.Equals(estilo));

            if (graduacionMin.HasValue)
                query = query.Where(c => c.Graduacion >= graduacionMin.Value);

            if (graduacionMax.HasValue)
                query = query.Where(c => c.Graduacion <= graduacionMax.Value);

            if (ibuMin.HasValue)
                query = query.Where(c => c.IBU >= ibuMin.Value);

            if (ibuMax.HasValue)
                query = query.Where(c => c.IBU <= ibuMax.Value);

            if (esArtesanal.HasValue)
                query = query.Where(c => c.EsArtesanal == esArtesanal.Value);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllEstilosAsync()
        {
            return await _context.Cervezas.Select(c => c.Estilo).Distinct().OrderBy(e => e).ToListAsync();
        }
    }
}