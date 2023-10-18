using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInstituteRepository : IBaseRepository<Institute>
    {
        Task CreateAsync(Institute entity);
    }
}