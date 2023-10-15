using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Intarfaces
{
    public interface IVoluntariadoRepository : IBaseRepository<Voluntariado>
    {
        Task CreateAsync(Voluntariado entity, Instituto instituto);
        Task InscreverUsuarioAsync(int voluntariadoId, int usuarioId);
        Task CancelarInscricaoUsuarioAsync(int voluntariadoId, int usuarioId);
    }
}