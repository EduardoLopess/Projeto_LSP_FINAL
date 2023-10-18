using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repository
{
    public class DonationMaterialRepository : IDonationMaterialRepository
    {
        public readonly DataContext _context;
        public DonationMaterialRepository(DataContext context)
        {
            _context = context;
        }
        public Task CreateAsync(DonationMaterial entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<DonationMaterial>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DonationMaterial> GetByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DonationMaterial entity)
        {
            throw new NotImplementedException();
        }

    }
}