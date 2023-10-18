using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class VolunteeringRepository : IVolunteeringRepository
    {
        private readonly DataContext _context;
        public VolunteeringRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Volunteering entity, Responsibility responsibility, Benefit benefit)
        {
           entity.Responsibility = new List<Responsibility> { responsibility };
           entity.Benefits = new List<Benefit> { benefit };

           _context.Add(entity);
           await
            _context.SaveChangesAsync();
        }
        
        public async Task<IList<Volunteering>> GetAllAsync()
        {
            return
                await _context.Volunteerings
                    .Include(b => b.Benefits)
                    .Include(r => r.Responsibility)
                    .ToListAsync();
        }

        public async Task<Volunteering> GetByIdAsync(int entityId)
        {
            return
                await _context.Volunteerings
                    .Include(b => b.Benefits)
                    .Include(r => r.Responsibility)
                    .SingleOrDefaultAsync(v => v.Id == entityId);
        }

        public async Task UpdateAsync(Volunteering entity)
        {
            var existeVolunteering = await _context.Volunteerings
                                    .Include(b => b.Benefits)
                                    .Include(r => r.Responsibility)
                                    .FirstOrDefaultAsync(a => a.Id == entity.Id);
            if(existeVolunteering != null)
            {
                _context.Entry(existeVolunteering).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int entityId)
        {
            var existeVolunteering = await _context.Volunteerings
                                    .Include(b => b.Benefits)
                                    .Include(r => r.Responsibility)
                                    .FirstOrDefaultAsync(a => a.Id == entityId);

            if(existeVolunteering != null)
            {
                _context.Volunteerings.Remove(existeVolunteering);
                await
                    _context.SaveChangesAsync();
            }                         
        }

        
    }
}