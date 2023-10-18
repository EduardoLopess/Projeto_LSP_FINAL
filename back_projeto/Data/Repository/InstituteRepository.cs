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

        public Task UpdateAsync(Institute entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }

    }
}