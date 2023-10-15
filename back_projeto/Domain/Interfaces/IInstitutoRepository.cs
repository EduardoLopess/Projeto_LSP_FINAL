using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInstitutoRepository : IBaseRepository<Instituto>
    {
        Task CreateAsync(Instituto entity, Endereco endereco);


        //Criar os Voluntariados
        bool CriarVoluntariado(int institutoId, Voluntariado voluntariado);
        bool AtualizarVoluntariado(int institutoId, Voluntariado voluntariado);
        bool ExcluirVoluntariado(int institutoId, int voluntariadoId);
    }
}