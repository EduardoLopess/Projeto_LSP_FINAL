using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repository
{
    public class DonationPointRepository : IDonationPointRepository
    {
        private readonly DataContext _context;
        public DonationPointRepository(DataContext context)
        {
            _context = context;
        }
        
        public Task CreateAsync(DonationPoint entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<DonationPoint>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DonationPoint> GetByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DonationPoint entity)
        {
            throw new NotImplementedException();
        }

    }
}