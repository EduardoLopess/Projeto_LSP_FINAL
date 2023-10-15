using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task CreateAsync(Usuario entity, Endereco endereco);

        bool InscreverUsuarioEmVoluntariado(int usuarioId, int voluntariadoId);
        bool CancelarInscricaoUsuarioEmVoluntariado(int usuarioId, int voluntariadoId);
    }
}