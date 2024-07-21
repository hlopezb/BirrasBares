using BirrasBares.Data;
using BirrasBares.Models;
using Microsoft.EntityFrameworkCore;

namespace BirrasBares.Repositories
{
    public class PlatoMenuRepository : IPlatoMenuRepository
    {
        private readonly ApplicationDbContext _context;

        public PlatoMenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlatoMenu>> GetAllPlatosMenuAsync()
        {
            return await _context.PlatosMenu.Include(p => p.Bar).ToListAsync();
        }

        public async Task<PlatoMenu> GetPlatoMenuByIdAsync(int id)
        {
            return await _context.PlatosMenu
                .Include(p => p.Bar)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PlatoMenu> AddPlatoMenuAsync(PlatoMenu platoMenu)
        {
            _context.PlatosMenu.Add(platoMenu);
            await _context.SaveChangesAsync();
            return platoMenu;
        }

        public async Task UpdatePlatoMenuAsync(PlatoMenu platoMenu)
        {
            _context.Entry(platoMenu).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlatoMenuAsync(int id)
        {
            var platoMenu = await _context.PlatosMenu.FindAsync(id);
            if (platoMenu != null)
            {
                _context.PlatosMenu.Remove(platoMenu);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PlatoMenu>> GetPlatosMenuByBarIdAsync(int barId)
        {
            return await _context.PlatosMenu
                .Where(p => p.BarId == barId)
                .ToListAsync();
        }
    }
}