using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDonationPointRepository : IBaseRepository<DonationPoint>
    {
        Task CreateAsync(DonationPoint entity);

    }
}