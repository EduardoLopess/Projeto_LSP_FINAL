using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class InstituteRepository : IInstituteRepository
    {
        public readonly DataContext _context;
        public InstituteRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Institute entity)
        {
            _context.Add(entity);
            await
                _context.SaveChangesAsync();   

        }

        public async Task<IList<Institute>> GetAllAsync()
        {
            return
                await _context.Institutes
                    .Include(a => a.Address )
                    .Include(v => v.Volunteerings)
                    .ToListAsync();
        }

        public async Task<Institute> GetByIdAsync(int entityId)
        {
            return
                await _context.Institutes
                    .Include(v => v.Volunteerings)
                    .Include(a => a.Address)
                    .FirstOrDefaultAsync(i => i.Id == entityId);
        }

        public async Task UpdateAsync(Institute entity)
        {
            var existInstitute = await _context.Institutes
                                .Include(v => v.Volunteerings)
                                .Include(a => a.Address)
                                .FirstOrDefaultAsync(i => i.Id == entity.Id);
            if(existInstitute != null)
            {
                _context.Entry(existInstitute).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int entityId)
        {
            var existInstitute = await _context.Institutes
                                .Include(v => v.Volunteerings)
                                .Include(a => a.Address)
                                .FirstOrDefaultAsync(i => i.Id == entityId);
            if(existInstitute != null)
            {
                _context.Institutes.Remove(existInstitute);
                await
                    _context.SaveChangesAsync();
            }
        }

    }
}