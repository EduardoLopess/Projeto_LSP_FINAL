using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {
        Task CreateAsync(Endereco entity, int usuarioId);
    }
}